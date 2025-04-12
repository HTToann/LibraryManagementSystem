using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class BookControl : UserControl
    {
        private BookService _service = new BookService();
        private CategoryService _categoryService = new CategoryService();
        private PublisherService _publisherService = new PublisherService();
        private SupplierService _supplierService = new SupplierService();

        private int selectedBookID = -1;
        public BookControl()
        {
            InitializeComponent();
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
            BeautyDGV();
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
