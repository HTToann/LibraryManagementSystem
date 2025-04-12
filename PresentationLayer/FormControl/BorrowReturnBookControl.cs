using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class BorrowReturnBookControl : UserControl
    {
        private BorrowReturnBookService _service = new BorrowReturnBookService();
        private UserService _userService = new UserService();
        private ReaderService __readerService = new ReaderService();
        private int selectedID = -1;
        public BorrowReturnBookControl()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllBorrowReturnBooks();
        }
        private void LoadComboboxs()
        {
            cbReader.DataSource = __readerService.GetReaders();
            cbReader.DisplayMember = "FullName";
            cbReader.ValueMember = "ReaderID";
            cbReader.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbReader.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbStaff.DataSource = _userService.GetAllUsers();
            cbStaff.DisplayMember = "FullName";
            cbStaff.ValueMember = "UserID";
            cbStaff.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbStaff.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbStatus.DataSource = _service.GetAllStatuses();
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "StatusID";
            cbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        }
        private void btInsert_Click(object sender, System.EventArgs e)
        {

            var borrowReturnBook = new BorrowReturnBookDTO
            {
                ReaderID = (int)cbReader.SelectedValue,
                UserID = (int)cbStaff.SelectedValue,
                DateBorrow = dtpBorrow.Value,
                DateReturn = dtpReturn.Value,
                StatusID = (int)cbStatus.SelectedValue
            };
            if (_service.Insert(borrowReturnBook))
            {
                MessageBox.Show("BorrowReturnBook has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                cbReader.Text = row.Cells["ReaderName"].Value.ToString();
                cbStaff.Text = row.Cells["UserName"].Value.ToString();
                dtpBorrow.Text = row.Cells["DateBorrow"].Value.ToString();
                dtpReturn.Text = row.Cells["DateReturn"].Value.ToString();
                cbStatus.Text = row.Cells["StatusName"].Value.ToString();


                // Lưu ID để sử dụng khi update/delete
                selectedID = Convert.ToInt32(row.Cells["ID"].Value);
            }
        }

        private void BorrowReturnBookControl_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboboxs();
            BeautyDGV();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a book to update!");
                return;
            }

            var borrowReturnBook = new BorrowReturnBookDTO
            {
                ID=selectedID,
                ReaderID = (int)cbReader.SelectedValue,
                UserID = (int)cbStaff.SelectedValue,
                DateBorrow = dtpBorrow.Value,
                DateReturn = dtpReturn.Value,
                StatusID = (int)cbStatus.SelectedValue
            };

            var success = _service.Update(borrowReturnBook);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a rowdata to delete!");
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
                if (!int.TryParse(tbKw.Text, out int readerID))
                {
                    MessageBox.Show("ID must be a number!");
                    return;
                }

                var result = _service.GetBorrowReturnByReaderID(readerID);
                if (result == null)
                {
                    MessageBox.Show("ReaderID not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = result;
            }
            else if (rdName.Checked)
            {
                var result = _service.GetBorrowReturnByReaderName(tbKw.Text);
                if (result == null)
                {
                    MessageBox.Show("Reader Name not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = result;
            }
            else
            {
                MessageBox.Show("Please select search type: Reader ID or Reader Name.");
            }
        }
    }
}
