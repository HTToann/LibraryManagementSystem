using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
<<<<<<< HEAD
<<<<<<< HEAD
using Guna.UI2.WinForms;

=======
<<<<<<< HEAD
using Guna.UI2.WinForms;

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
namespace LibrarySystem.FormControl
{
    public partial class BookControl : UserControl
    {
        private BookService _service = new BookService();
        private CategoryService _categoryService = new CategoryService();
        private PublisherService _publisherService = new PublisherService();
        private SupplierService _supplierService = new SupplierService();
<<<<<<< HEAD
<<<<<<< HEAD
        private Guna2DataGridView dgv = new Guna2DataGridView();

=======
<<<<<<< HEAD
        private Guna2DataGridView dgv = new Guna2DataGridView();

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4

        private int selectedBookID = -1;
        public BookControl()
        {
            InitializeComponent();
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2

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
                HeaderText = "BookID",
                Name = "BookID",
                DataPropertyName = "BookID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "CodeBook",
                Name = "CodeBook",
                DataPropertyName = "CodeBook"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NameBook",
                Name = "NameBook",
                DataPropertyName = "NameBook"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "YearOfPublication",
                Name = "YearOfPublication",
                DataPropertyName = "YearOfPublication"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "CategoryName",
                Name = "CategoryName",
                DataPropertyName = "CategoryName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "PublisherName",
                Name = "PublisherName",
                DataPropertyName = "PublisherName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SupplierName",
                Name = "SupplierName",
                DataPropertyName = "SupplierName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Count",
                Name = "Count",
                DataPropertyName = "Count"
            });
            dgv.CellClick += dgv_CellClick;
            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllBooks();
        }

        private void LoadComboBoxes()
        {
            cbCategory.DataSource = _categoryService.GetAllCategories();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryID";
            cbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbPublisher.DataSource = _publisherService.GetAllPublishers();
            cbPublisher.DisplayMember = "Name";
            cbPublisher.ValueMember = "PublisherID";
            cbPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbSupplier.DataSource = _supplierService.GetAllSuppliers();
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
        private void BeautyDGV()
        {
            // Không cho người dùng chỉnh cột
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            // Không cho thêm dòng mới
            dgv.AllowUserToAddRows = false;
            // Tự động resize
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Chỉnh header đẹp
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;

            // Chỉnh cell
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Canh giữa cho header
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Canh lề trái cho cell
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
        private void ResetForm()
        {
            txtCodeBook.Text = "";
            txtNameBook.Text = "";
            txtCount.Text = "";
            txtYear.Text = "";     
        }
        private void BookControl_Load(object sender, System.EventArgs e)
        {
            LoadComboBoxes();
<<<<<<< HEAD
<<<<<<< HEAD
            InitDataGridView();
=======
<<<<<<< HEAD
            InitDataGridView();
=======
            BeautyDGV();
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
            BeautyDGV();
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            LoadData();
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtCodeBook.Text = row.Cells["CodeBook"].Value.ToString();
                txtNameBook.Text = row.Cells["NameBook"].Value.ToString();
                txtYear.Text = row.Cells["YearOfPublication"].Value.ToString();
                txtCount.Text = row.Cells["Count"].Value.ToString();
                cbCategory.Text = row.Cells["CategoryName"].Value.ToString();
                cbPublisher.Text = row.Cells["PublisherName"].Value.ToString();
                cbSupplier.Text = row.Cells["SupplierName"].Value.ToString();


                // Lưu ID để sử dụng khi update/delete
                selectedBookID = Convert.ToInt32(row.Cells["BookID"].Value);
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCodeBook.Text) ||
               string.IsNullOrWhiteSpace(txtNameBook.Text) ||
               string.IsNullOrWhiteSpace(txtCount.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            return true;
        }
        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (!ValidateForm())
                return;
<<<<<<< HEAD
=======
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4

        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtCodeBook.Text) ||
                string.IsNullOrWhiteSpace(txtNameBook.Text) ||
                string.IsNullOrWhiteSpace(txtCount.Text) ||
                 string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4

            var book = new BookDTO
            {
                CodeBook = txtCodeBook.Text,
                NameBook = txtNameBook.Text,
                Count = int.Parse(txtCount.Text),
                YearOfPublication = int.Parse(txtYear.Text),
                CategoryID = (int)cbCategory.SelectedValue,
                SupplierID = (int)cbSupplier.SelectedValue,
                PublisherID = (int)cbPublisher.SelectedValue
            };
            if (_service.InsertBook(book))
            {
                MessageBox.Show("Book has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to update!");
                return;
            }
<<<<<<< HEAD
<<<<<<< HEAD
            // Kiểm tra rỗng
            if (!ValidateForm())
                return;
=======
<<<<<<< HEAD
            // Kiểm tra rỗng
            if (!ValidateForm())
                return;
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4

            var book = new BookDTO
            {
               BookID=selectedBookID,
               CodeBook=txtCodeBook.Text,
               NameBook=txtNameBook.Text,
               Count=int.Parse(txtCount.Text),
               YearOfPublication=int.Parse(txtCount.Text),
               CategoryID=(int)cbCategory.SelectedValue,
               PublisherID=(int)cbPublisher.SelectedValue,
               SupplierID=(int)cbSupplier.SelectedValue
            };

            var success = _service.UpdateBook(book);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this author?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteBook(selectedBookID);
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
                LoadData();
                ResetForm();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKw.Text))
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }
            if (rdID.Checked)
            {
                if (!int.TryParse(tbKw.Text, out int bookId))
                {
                    MessageBox.Show("Book ID must be a number!");
                    return;
                }

                var book = _service.GetBookById(bookId);
                if (book == null)
                {
                    MessageBox.Show("Book not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<BookDTO> { book };
            }
            else if (rdName.Checked)
            {
                var book = _service.GetBookByName(tbKw.Text);
                if (book == null)
                {
                    MessageBox.Show("Book not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = book;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
    }
    }
}
