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
    public partial class SupplierControl : UserControl
    {
        private SupplierService _service = new SupplierService();
        private int selectedSupplierID = -1;
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
        public SupplierControl()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
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
      
<<<<<<< HEAD
=======
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
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllSuppliers();
        }
        private void ResetForm()
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            txtName.Clear();
            txtGmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            selectedSupplierID = -1;
        }
        private bool ValidateInput(out string message)
        {
            message = "";

<<<<<<< HEAD
=======
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            txtName.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            selectedSupplierID = -1;
        }
        private void btInsert_Click(object sender, System.EventArgs e)
        {
            // Kiểm tra rỗng
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
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
<<<<<<< HEAD
=======
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Kiểm tra email hợp lệ (rất cơ bản)
            if (!txtGmail.Text.Contains("@") || !txtGmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }
            // Kiểm tra số điện thoại là số và có độ dài hợp lý (VD: 9-11 số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{9,11}$"))
            {
                MessageBox.Show("Phone number must be numeric and 9 to 11 digits long.");
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
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

        private void btUpdate_Click(object sender, System.EventArgs e)
        {
            if (selectedSupplierID == -1)
            {
                MessageBox.Show("Please select a supplier to update!");
                return;
            }

<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            if (!ValidateInput(out string message))
            {
                MessageBox.Show(message);
                return;
            }
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
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

<<<<<<< HEAD
<<<<<<< HEAD
                txtName.Text = row.Cells["Namee"].Value.ToString();
=======
<<<<<<< HEAD
                txtName.Text = row.Cells["Namee"].Value.ToString();
=======
                txtName.Text = row.Cells["Name"].Value.ToString();
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
                txtName.Text = row.Cells["Name"].Value.ToString();
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
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
<<<<<<< HEAD
<<<<<<< HEAD
            string keyword = tbKw.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
=======
<<<<<<< HEAD
            string keyword = tbKw.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
=======
            if (string.IsNullOrWhiteSpace(tbKw.Text))
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
            if (string.IsNullOrWhiteSpace(tbKw.Text))
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            dgv.DataSource = null;
            if (rdID.Checked)
            {
                if (!int.TryParse(keyword, out int supplierId))
<<<<<<< HEAD
=======
=======
            if (rdID.Checked)
            {
                if (!int.TryParse(tbKw.Text, out int supllierId))
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
            if (rdID.Checked)
            {
                if (!int.TryParse(tbKw.Text, out int supllierId))
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                {
                    MessageBox.Show("Supplier ID must be a number!");
                    return;
                }

<<<<<<< HEAD
<<<<<<< HEAD
                var supplier = _service.GetSupplierById(supplierId);
=======
<<<<<<< HEAD
                var supplier = _service.GetSupplierById(supplierId);
=======
                var supplier = _service.GetSupplierById(supllierId);
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
                var supplier = _service.GetSupplierById(supllierId);
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                if (supplier == null)
                {
                    MessageBox.Show("Supplier not found!");
                    return;
                }

                tbKw.Text = "";
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
                dgv.DataSource = null;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
                dgv.DataSource = null;
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                dgv.DataSource = new List<SupplierDTO> { supplier };
            }
            else if (rdName.Checked)
            {
                var supplier = _service.GetSupplierByName(tbKw.Text);
<<<<<<< HEAD
<<<<<<< HEAD
                if (supplier == null )
=======
<<<<<<< HEAD
                if (supplier == null )
=======
                if (supplier == null)
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
                if (supplier == null)
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                {
                    MessageBox.Show("Supplier not found!");
                    return;
                }
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
                tbKw.Text = "";
                dgv.DataSource = null;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
                tbKw.Text = "";
                dgv.DataSource = null;
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
                dgv.DataSource = supplier;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
<<<<<<< HEAD
<<<<<<< HEAD
            tbKw.Clear();
=======
<<<<<<< HEAD
            tbKw.Clear();
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
        }
    }
    }
