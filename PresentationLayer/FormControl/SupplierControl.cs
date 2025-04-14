using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class SupplierControl : UserControl
    {
        private SupplierService _service = new SupplierService();
        private int selectedSupplierID = -1;
        private Guna2DataGridView dgv = new Guna2DataGridView();
        public SupplierControl()
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
                HeaderText = "SupplierID",
                Name = "SupplierID",
                DataPropertyName = "SupplierID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Namee",
                DataPropertyName = "Name"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Address",
                Name = "Address",
                DataPropertyName = "Address"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone",
                Name = "Phone",
                DataPropertyName = "Phone"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Gmail",
                Name = "Gmail",
                DataPropertyName = "Gmail"
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
            dgv.DataSource = _service.GetAllSuppliers();
        }
        private void ResetForm()
        {
            txtName.Clear();
            txtGmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            selectedSupplierID = -1;
        }
        private bool ValidateInput(out string message)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                message = "Please fill in all required fields.";
                return false;
            }

            if (!txtGmail.Text.Contains("@") || !txtGmail.Text.Contains("."))
            {
                message = "Invalid email format.";
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{9,11}$"))
            {
                message = "Phone number must be numeric and 9 to 11 digits long.";
                return false;
            }

            return true;
        }
        private void btInsert_Click(object sender, System.EventArgs e)
        {
            if (!ValidateInput(out string message))
            {
                MessageBox.Show(message);
                return;
            }
            var supplier = new SupplierDTO
            {
                Name = txtName.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
            };
            if (_service.InsertSupplier(supplier))
            {
                MessageBox.Show("Supplier has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();

        }

        private void SupplierControl_Load(object sender, System.EventArgs e)
        {
            InitDataGridView();
            LoadData();
        }

        private void btUpdate_Click(object sender, System.EventArgs e)
        {
            if (selectedSupplierID == -1)
            {
                MessageBox.Show("Please select a supplier to update!");
                return;
            }

            if (!ValidateInput(out string message))
            {
                MessageBox.Show(message);
                return;
            }
            var supplier = new SupplierDTO
            {
                SupplierID = selectedSupplierID,
                Name = txtName.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
            };

            var success = _service.UpdateSupplier(supplier);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                txtName.Text = row.Cells["Namee"].Value.ToString();
                txtGmail.Text = row.Cells["Gmail"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();

                // Lưu ID để sử dụng khi update/delete
                selectedSupplierID = Convert.ToInt32(row.Cells["SupplierID"].Value);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierID == -1)
            {
                MessageBox.Show("Please select a supplier to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteSupplier(selectedSupplierID);
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
            string keyword = tbKw.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }
            dgv.DataSource = null;
            if (rdID.Checked)
            {
                if (!int.TryParse(keyword, out int supplierId))
                {
                    MessageBox.Show("Supplier ID must be a number!");
                    return;
                }

                var supplier = _service.GetSupplierById(supplierId);
                if (supplier == null)
                {
                    MessageBox.Show("Supplier not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = new List<SupplierDTO> { supplier };
            }
            else if (rdName.Checked)
            {
                var supplier = _service.GetSupplierByName(tbKw.Text);
                if (supplier == null )
                {
                    MessageBox.Show("Supplier not found!");
                    return;
                }
                dgv.DataSource = supplier;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
            tbKw.Clear();
        }
    }
    }
