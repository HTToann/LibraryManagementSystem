using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class PenaltyControl : UserControl
    {
        private HistoryBorrowService _historyService = new HistoryBorrowService();
        private PenaltyService _service = new PenaltyService();
        private int selectedID = -1;
        public PenaltyControl()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllPenalties();
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
            var statusList = new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>("True", 1),
                    new KeyValuePair<string, int>("False", 0)
                };

            cbIsPaid.DataSource = statusList;
            cbIsPaid.DisplayMember = "Key";
            cbIsPaid.ValueMember = "Value";


            cbHistory.DataSource = _historyService.GetAllHistory();
            cbHistory.DisplayMember = "ID";
            cbHistory.ValueMember = "ID";
            cbHistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbHistory.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void PenaltyControl_Load(object sender, System.EventArgs e)
        {
            txtFineAmount.Text = "0";
            txtDays.Text = "1";
            LoadData();
            LoadComboboxs();
            BeautyDGV();
        }

        private void btUpdate_Click(object sender, System.EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a data row to update!");
                return;
            }

            var penalty = new PenaltyDTO
            {
                ID = selectedID,
                HistoryBorrowID = (int)cbHistory.SelectedValue,
                PenaltyDate = dtpPenaltyDate.Value,
                NumberOfPenaltyDays = int.Parse(txtDays.Text),
                FineAmount= (decimal)double.Parse(txtFineAmount.Text),
                Status = (bool)cbIsPaid.SelectedValue,
            };

            var success = _service.UpdatePenalty(penalty);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btInsertReader_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFineAmount.Text) ||
                 string.IsNullOrWhiteSpace(txtDays.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            var penalty = new PenaltyDTO
            {
                HistoryBorrowID = (int)cbHistory.SelectedValue,
                PenaltyDate = dtpPenaltyDate.Value,
                NumberOfPenaltyDays = int.Parse(txtDays.Text),
                FineAmount = decimal.Parse(txtFineAmount.Text),
                Status = (int)cbIsPaid.SelectedValue == 1
             };
            if (_service.InsertPenalty(penalty))
            {
                MessageBox.Show("Penalty has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            txtFineAmount.Text = "0";
            txtDays.Text = "1";
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
                var success = _service.DeletePenalty(selectedID);
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
                LoadData();
                ResetForm();
            }
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
                if (!int.TryParse(tbKw.Text, out int historyBorrowID))
                {
                    MessageBox.Show("ID must be a number!");
                    return;
                }

                var history = _service.GetPenaltiesByHistoryBorrowID(historyBorrowID);
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
