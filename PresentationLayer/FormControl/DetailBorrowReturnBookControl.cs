using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class DetailBorrowReturnBookControl : UserControl
    {
        private DetailBorrowReturnBookService _service = new DetailBorrowReturnBookService();
        private BorrowReturnBookService _borrowReturnBookService = new BorrowReturnBookService();
        private BookService _bookService = new BookService();
        private int selectedID = -1;

        public DetailBorrowReturnBookControl()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllDetails();
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
                txtCount.Text = "";
        }
        private void LoadComboboxs()
        {
            cbBorrowReturnBook.DataSource = _borrowReturnBookService.GetAllBorrowReturnBooks();
            cbBorrowReturnBook.DisplayMember = "ReaderID";
            cbBorrowReturnBook.ValueMember = "ID";
            cbBorrowReturnBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBorrowReturnBook.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbBook.DataSource = _bookService.GetAllBooks();
            cbBook.DisplayMember = "NameBook";
            cbBook.ValueMember = "BookID";
            cbBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBook.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void DetailBorrowReturnBookControl_Load(object sender, System.EventArgs e)
        {
            txtCount.Text = "1";
            LoadData();
            LoadComboboxs();
            BeautyDGV();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                cbBorrowReturnBook.Text=row.Cells["BorrowReturnBookID"].Value.ToString();
                cbBook.Text = row.Cells["BookName"].Value.ToString();
                txtCount.Text = row.Cells["Count"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedID = Convert.ToInt32(row.Cells["ID"].Value);
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCount.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var detail = new DetailBorrowReturnBookDTO
            {
                BookID = (int)cbBook.SelectedValue,
                BorrowReturnBookID = (int)cbBorrowReturnBook.SelectedValue,
                Count = int.Parse(txtCount.Text)
            };
            if (_service.Insert(detail))
            {
                MessageBox.Show("Detail has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a data row to update!");
                return;
            }

            var detail = new DetailBorrowReturnBookDTO
            {
                ID= selectedID,
                BookID = (int)cbBook.SelectedValue,
                BorrowReturnBookID = (int)cbBorrowReturnBook.SelectedValue,
                Count = int.Parse(txtCount.Text)
            };

            var success = _service.Update(detail);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a row data to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this row?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.Delete(selectedID);
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
                if (!int.TryParse(tbKw.Text, out int detailID))
                {
                    MessageBox.Show("ID must be a number!");
                    return;
                }

                var detail = _service.GetDetailsByBorrowReturnID(detailID);
                if (detail == null)
                {
                    MessageBox.Show("Not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = detail;
            }  
            else
            {
                MessageBox.Show("Please select search type: ID");
            }
        }
    }
}
