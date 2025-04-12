using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class HistoryBorrowControl : UserControl
    {
        private DetailBorrowReturnBookService _detailservice = new DetailBorrowReturnBookService();
        private HistoryBorrowService _service = new HistoryBorrowService();
        private int selectedID = -1;

        public HistoryBorrowControl()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllHistory();
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
        private void LoadComboboxs()
        {
            cbDetail.DataSource = _detailservice.GetAllDetails();
            cbDetail.DisplayMember = "ID";
            cbDetail.ValueMember = "ID";
            cbDetail.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDetail.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbStatus.DataSource = _service.GetAllStatuses();
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "StatusID";
            cbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                cbDetail.Text = row.Cells["DetailBorrowReturnBookID"].Value.ToString();
                cbStatus.Text = row.Cells["StatusName"].Value.ToString();
                dtpBookReturnDate.Text = row.Cells["BookReturnDate"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedID = Convert.ToInt32(row.Cells["ID"].Value);
            }
        }

        private void HistoryBorrowControl_Load(object sender, EventArgs e)
        {
            LoadData();
            BeautyDGV();
            LoadComboboxs();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {

            var history = new HistoryBorrowDTO
            {
                DetailBorrowReturnBookID = (int)cbDetail.SelectedValue,
                StatusID = (int)cbStatus.SelectedValue,
                BookReturnDate = dtpBookReturnDate.Value
            };
            if (_service.Insert(history))
            {
                MessageBox.Show("History has been added successfully!");
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

            var history = new HistoryBorrowDTO
            {
                ID=selectedID,
                DetailBorrowReturnBookID = (int)cbDetail.SelectedValue,
                StatusID = (int)cbStatus.SelectedValue,
                BookReturnDate = dtpBookReturnDate.Value
            };

            var success = _service.Update(history);
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

                var history = _service.GetHistoryByDetailID(detailID);
                if (history == null)
                {
                    MessageBox.Show("Not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = history;
            }
            else
            {
                MessageBox.Show("Please select search type: ID");
            }
        }
    }
}
