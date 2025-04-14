using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
<<<<<<< HEAD
using Guna.UI2.WinForms;

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
namespace LibrarySystem.FormControl
{
    public partial class PenaltyControl : UserControl
    {
        private HistoryBorrowService _historyService = new HistoryBorrowService();
        private PenaltyService _service = new PenaltyService();
        private int selectedID = -1;
<<<<<<< HEAD
        private Guna2DataGridView dgv = new Guna2DataGridView();

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
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
<<<<<<< HEAD
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
                HeaderText = "ID",
                Name = "ID",
                DataPropertyName = "ID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "HistoryBorrowId",
                Name = "HistoryBorrowId",
                DataPropertyName = "HistoryBorrowId"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "PenaltyDate",
                Name = "PenaltyDate",
                DataPropertyName = "PenaltyDate"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Days",
                Name = "NumberOfPenaltyDays",
                DataPropertyName = "NumberOfPenaltyDays"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "FineAmount",
                Name = "FineAmount",
                DataPropertyName = "FineAmount"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                Name = "Status",
                DataPropertyName = "Status"
            });
            dgv.CellClick += dgv_CellClick;


            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFineAmount.Text) ||
                 string.IsNullOrWhiteSpace(txtDays.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }
            return true;
        }

        private void ResetForm()
        {
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                cbHistory.Text = row.Cells["HistoryBorrowId"].Value.ToString();
                dtpPenaltyDate.Text = row.Cells["PenaltyDate"].Value.ToString();
                txtDays.Text = row.Cells["NumberOfPenaltyDays"].Value.ToString();
                txtFineAmount.Text = row.Cells["FineAmount"].Value.ToString();
                cbIsPaid.Text = row.Cells["Status"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedID = Convert.ToInt32(row.Cells["ID"].Value);
            }
        }
=======

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
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
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
<<<<<<< HEAD
            InitDataGridView();
=======
            BeautyDGV();
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
        }

        private void btUpdate_Click(object sender, System.EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a data row to update!");
                return;
            }
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======

>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
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
<<<<<<< HEAD
            if (!ValidateForm())
                return; 
=======
            if (string.IsNullOrWhiteSpace(txtFineAmount.Text) ||
                 string.IsNullOrWhiteSpace(txtDays.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
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
