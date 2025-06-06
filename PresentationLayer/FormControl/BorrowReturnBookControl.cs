﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class BorrowReturnBookControl : UserControl
    {
        private BorrowReturnBookService _service = new BorrowReturnBookService();
        private UserService _userService = new UserService();
        private ReaderService __readerService = new ReaderService();
        private Guna2DataGridView dgv = new Guna2DataGridView();

        private int selectedID = -1;
        public BorrowReturnBookControl()
        {
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
                HeaderText = "ID",
                Name = "ID",
                DataPropertyName = "ID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ReaderID",
                Name = "ReaderID",
                DataPropertyName = "ReaderID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "UserID",
                Name = "UserID",
                DataPropertyName = "UserID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ReaderName",
                Name = "ReaderName",
                DataPropertyName = "ReaderName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "UserName",
                Name = "UserName",
                DataPropertyName = "UserName"
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
                HeaderText = "StatusName",
                Name = "StatusName",
                DataPropertyName = "StatusName"
            });
            dgv.CellClick += dgv_CellClick;
            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
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
            InitDataGridView();
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
