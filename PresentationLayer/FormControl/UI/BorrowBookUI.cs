using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;
namespace LibrarySystem.FormControl
{
    public partial class BorrowBookUI : UserControl
    {
        private Guna2DataGridView dgv = new Guna2DataGridView();
        private ReaderService _readerService = new ReaderService();
        private BookService _bookService = new BookService();
        private BorrowReturnBookService _borrowReturnBookService = new BorrowReturnBookService();
        private DetailBorrowReturnBookService _detailService = new DetailBorrowReturnBookService();
        private List<DetailBorrowReturnBookDTO> selectedBooks = new List<DetailBorrowReturnBookDTO>();
        private UserDTO _currentUser;

        public BorrowBookUI()
        {
            InitializeComponent();
        }
        public BorrowBookUI(UserDTO user)
        {
            _currentUser = user;
            InitializeComponent();
        }
        private void InitDataGridView()
        {
            // ❌ Không cho người dùng thao tác
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;

            // ✅ Tự động co giãn
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // ✅ Tổng thể
            dgv.Dock = DockStyle.Bottom; // 👈 Gắn vào đáy Form
            dgv.Height = 300;            // 👈 Đặt chiều cao nếu muốn
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;
            dgv.EnableHeadersVisualStyles = false;

            // ✅ Header style
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(72, 133, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgv.ColumnHeadersHeight = 40;

            // ✅ Cell style
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(0, 120, 215),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            // ✅ Dòng xen kẽ
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 249, 255)
            };

            // ✅ Xóa và tạo lại cột
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookID",               // 👈 Bắt buộc nếu bạn truy cập bằng tên cột
                HeaderText = "Book ID",
                DataPropertyName = "BookID",   // để bind dữ liệu nếu dùng DataSource
                Visible = false                // ẩn nếu bạn không muốn hiển thị cột ID
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BookName",
                Name = "BookName",
                DataPropertyName = "BookName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Count",
                Name = "Count",
                DataPropertyName = "Count"
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "X",
                UseColumnTextForButtonValue = true, // 👈 Phải có dòng này để hiện Text
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,// 👈 canh giữa
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                }
            });
            dgv.CellContentClick += dgv_CellContentClick;

            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }
        private void LoadComboboxes()
        {
            cbReader.DataSource = _readerService.GetReaders();
            cbReader.DisplayMember = "FullName"; // bạn có thể dùng property phụ FullName = First + Last
            cbReader.ValueMember = "ReaderID";

            cbBook.DataSource = _bookService.GetAllBooks();
            cbBook.DisplayMember = "NameBook";
            cbBook.ValueMember = "BookID";

            cbStatus.DataSource = _borrowReturnBookService.GetAllStatuses();
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "StatusID";

            dtpDateBorrow.Value = DateTime.Today;
            dtpDateReturn.Value = DateTime.Today;
        }
        private void SettingDGV()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
        }

        private void BorrowBookUI_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            SettingDGV();
            LoadComboboxes();
            txtCount.Text = "1";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a book.");
                return;
            }
            if (!int.TryParse(txtCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.");
                return;
            }
            int bookId = (int)cbBook.SelectedValue;
            string bookName = ((BookDTO)cbBook.SelectedItem).NameBook;

            var existing = selectedBooks.FirstOrDefault(x => x.BookID == bookId);
            if (existing != null)
            {
                existing.Count += count;
            }
            else
            {
                selectedBooks.Add(new DetailBorrowReturnBookDTO
                {
                    BookID = bookId,
                    BookName = bookName,
                    Count = count
                });
            }

            dgv.DataSource = null;
            dgv.DataSource = selectedBooks;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int bookId = (int)dgv.Rows[e.RowIndex].Cells["BookID"].Value;
                selectedBooks.RemoveAll(b => b.BookID == bookId);

                dgv.DataSource = null;
                dgv.DataSource = selectedBooks;
            }
        }
        private bool CheckOutOfStock()
        {
            // 1. Kiểm tra số lượng tồn kho
            var book = _bookService.GetBookById((int)cbBook.SelectedValue);
            if (book.Count < int.Parse(txtCount.Text) || book.Count == 1)
            {
                return false;
            }
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbReader.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reader.");
                return;
            }
            if (cbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a borrow status.");
                return;
            }
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("No books selected for borrowing.");
                return;
            }
            if (dtpDateReturn.Value.Date < dtpDateBorrow.Value.Date)
            {
                MessageBox.Show("Return date must be later than or equal to borrow date.");
                return;
            }
            if (!CheckOutOfStock())
            {
                MessageBox.Show($"This book is out of stock.");
                return;
            }
           

           

          

          
            var borrow = new BorrowReturnBookDTO
            {
                ReaderID = (int)cbReader.SelectedValue,
                UserID = _currentUser.UserID,  // nhân viên đăng nhập
                DateBorrow = dtpDateBorrow.Value,
                //DateReturn = dtpDateBorrow.Value.AddDays(7), // mặc định 7 ngày hoặc chọn
                DateReturn = dtpDateReturn.Value,
                StatusID = (int)cbStatus.SelectedValue
            };

            int borrowID = _borrowReturnBookService.InsertAndGetId(borrow);
            foreach (var item in selectedBooks)
            {
                item.BorrowReturnBookID = borrowID;
                _detailService.Insert(item);
                // Trừ số lượng sách đã mượn
                _bookService.DecreaseStock(item.BookID, item.Count);
            }
            MessageBox.Show("Borrow successfully!");
            ResetForm();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbReader.SelectedIndex = 0;
            cbBook.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            txtCount.Text = "1";
            selectedBooks.Clear();
            dgv.DataSource = null;
            dtpDateBorrow.Value = DateTime.Today;
        }
        private void ResetForm()
        {
            // Đặt lại combobox chọn bạn đọc
            cbReader.SelectedIndex = -1;

            // Đặt lại ngày mượn là hôm nay
            dtpDateBorrow.Value = DateTime.Today;
            dtpDateReturn.Value = DateTime.Today;
            // Đặt lại trạng thái (ví dụ mặc định là "Borrowing")
            cbStatus.SelectedIndex = 0;

            // Đặt lại combobox chọn sách
            cbBook.SelectedIndex = -1;

            // Đặt lại số lượng sách
            txtCount.Text = "1";

            // Xóa toàn bộ dữ liệu trong DataGridView (danh sách sách được mượn)
            selectedBooks.Clear(); // 🔥 Quan trọng: xóa danh sách sau khi đã lưu
            dgv.DataSource = null;
        }
    }
}
