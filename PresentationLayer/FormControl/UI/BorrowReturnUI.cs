using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class BorrowReturnUI : UserControl
    {
        private Timer searchTimer;
        private const string GmailPlaceholder = "Enter Gmail...";
        private const string PhonePlaceholder = "Enter Phone...";
        private const int FinePerDay = 3000; // 3,000 VND per overdue day
        private Guna2DataGridView dgv = new Guna2DataGridView();

        private BorrowReturnBookService _borrowReturnService = new BorrowReturnBookService();
        private DetailBorrowReturnBookService _detailService = new DetailBorrowReturnBookService();
        private HistoryBorrowService _historyService = new HistoryBorrowService();
        private PenaltyService _penaltyService = new PenaltyService();
        private ReaderService _readerService = new ReaderService();
        private BookService _bookService = new BookService();

        private List<BorrowedBookInfoDTO> borrowedBooks = new List<BorrowedBookInfoDTO>();
        public BorrowReturnUI()
        {
            InitializeComponent();
            searchTimer = new Timer();
            searchTimer.Interval = 2000; // 2 giây
            searchTimer.Tick += (s, e) =>
            {
                searchTimer.Stop(); // Ngừng timer sau khi chạy
                SearchReader();     // Thực hiện truy vấn
            };
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
                HeaderText = "BookName",
                Name = "BookName",
                DataPropertyName = "BookName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "DateBorrow",
                Name = "DateBorrow",
                DataPropertyName = "DateBorrow"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "DateReturn",
                Name = "DateReturn",
                DataPropertyName = "DateReturn"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "OverdueDays",
                Name = "OverdueDays",
                DataPropertyName = "OverdueDays"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "FineAmount",
                Name = "FineAmount",
                DataPropertyName = "FineAmount"
            });


            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }
        private void LoadReaders()
        {
            var readers = _readerService.GetReaders();
            cbReader.DataSource = readers;
            cbReader.DisplayMember = "FullName";
            cbReader.ValueMember = "ReaderID";
        }
        private void LoadStatus()
        {
            var status = _historyService.GetAllStatuses();
            cbStatus.DataSource = status;
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "StatusID";
        }
        private void SearchReader()
        {
            string gmail = txtGmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (gmail == GmailPlaceholder) gmail = "";
            if (phone == PhonePlaceholder) phone = "";
            if (string.IsNullOrWhiteSpace(gmail) && string.IsNullOrWhiteSpace(phone))
                return;
            //
            var reader = _readerService.FindByGmailOrPhone(gmail, phone);
            if (reader != null)
            {
                cbReader.SelectedValue = reader.ReaderID;
                LoadBorrowedBooks(reader.ReaderID);
            }
            else
            {
                MessageBox.Show("Not fount this reader!!.");
            }
        }
        private void LoadBorrowedBooks(int readerId)
        {
            var books = _borrowReturnService.GetBorrowedBooksByReader(readerId);
            foreach (var b in books)
            {
                int overdueDays = (DateTime.Today - b.DateReturn).Days;
                if (overdueDays > 0)
                {
                    b.OverdueDays = overdueDays;
                    b.FineAmount = overdueDays * FinePerDay;
                }
                else
                {
                    b.OverdueDays = 0;
                    b.FineAmount = 0;
                }
            }

            borrowedBooks = books;
            dgv.DataSource = borrowedBooks;

            lblTotalBorrowed.Text = $"Total borrowed books: {books.Count}";
            lblOverdue.Text = $"Overdue books: {books.Count(b => b.OverdueDays > 0)}";
            lblTotalFine.Text = $"Total fine: {books.Sum(b => b.FineAmount):n0}";
        }
        private void BorrowReturnUI_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtGmail, GmailPlaceholder);
            SetPlaceholder(txtPhone, PhonePlaceholder);
            InitDataGridView();
            LoadReaders();
            LoadStatus();
        }
     
        private void cbReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReader.SelectedValue is int readerId)
            {
                LoadBorrowedBooks(readerId);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!chkConfirmPayment.Checked)
            {
                MessageBox.Show("Please checked payment!!");
                return;
            }
            else
            {
                foreach (var item in borrowedBooks)
                {
                    int historyId = _historyService.InsertAndGetId(new HistoryBorrowDTO
                    {
                        DetailBorrowReturnBookID = item.DetailID,
                        BookReturnDate = DateTime.Today,
                        StatusID = (int)cbStatus.SelectedValue
                    });

                    if (item.OverdueDays > 0)
                    {
                        _penaltyService.InsertPenalty(new PenaltyDTO
                        {
                            HistoryBorrowID = historyId,
                            PenaltyDate = DateTime.Today,
                            NumberOfPenaltyDays = item.OverdueDays,
                            FineAmount = item.FineAmount,
                            Status = chkConfirmPayment.Checked
                        });
                    }

                    _bookService.IncreaseStock(item.BookID, item.Count);
                }

                if (borrowedBooks.Any())
                {
                    _borrowReturnService.MarkAsReturnedByDetailBookIDs(borrowedBooks.Select(b => b.DetailID).ToList());
                }

                MessageBox.Show("Books returned successfully!");
                ResetForm();
            }
        }
        private void ResetForm()
        {
            cbReader.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            txtGmail.Clear();
            txtPhone.Clear();
            dgv.DataSource = null;
            lblTotalBorrowed.Text = "";
            lblTotalFine.Text = "";
            lblOverdue.Text = "";
            chkConfirmPayment.Checked = false;
        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {
            HandleSearchTimer();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            HandleSearchTimer();
        }
        private bool IsValidSearchInput()
        {
            string gmail = txtGmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            return !(string.IsNullOrWhiteSpace(gmail) || gmail == GmailPlaceholder)
                || !(string.IsNullOrWhiteSpace(phone) || phone == PhonePlaceholder);
        }
        private void HandleSearchTimer()
        {
            searchTimer.Stop();

            if (!IsValidSearchInput())
            {
                // Hủy truy vấn nếu không còn dữ liệu hợp lệ
                return;
            }

            searchTimer.Start();
        }
        private void SetPlaceholder(TextBox textbox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeholder;
                textbox.Tag = "placeholder";
            }
        }
        private void RemovePlaceholder(TextBox textbox, string placeholder)
        {
            if ((string)textbox.Tag == "placeholder")
            {
                textbox.Text = "";
                textbox.ForeColor = Color.Black;
                textbox.Tag = null;
            }
        }

        private void txtGmail_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtGmail, "Enter Gmail...");
        }

        private void txtGmail_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(txtGmail, "Enter Gmail...");
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPhone, "Enter Phone...");
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(txtPhone, "Enter Phone...");
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
