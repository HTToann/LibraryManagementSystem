<<<<<<< HEAD
﻿// Optimized and validated version of StaffControl.cs
using BusinessLayer;
=======
<<<<<<< HEAD
﻿// Optimized and validated version of StaffControl.cs
using BusinessLayer;
=======
﻿using BusinessLayer;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
<<<<<<< HEAD
using Guna.UI2.WinForms;

=======
<<<<<<< HEAD
using Guna.UI2.WinForms;

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
namespace LibrarySystem.FormControl
{
    public partial class StaffControl : UserControl
    {
        private UserService _service = new UserService();
        private int selectedUserID = -1;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        private Guna2DataGridView dgvUsers = new Guna2DataGridView();

        public StaffControl()
        {
            InitializeComponent();
        }


        private void InitDataGridView()
        {
            var dgv = dgvUsers;
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
                HeaderText = "UserID",
                Name = "UserID",
                DataPropertyName = "UserID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "FirstName",
                Name = "FirstName",
                DataPropertyName = "FirstName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "LastName",
                Name = "LastName",
                DataPropertyName = "LastName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Username",
                Name = "Username",
                DataPropertyName = "Username"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Gmail",
                Name = "Gmail",
                DataPropertyName = "Gmail"
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
                HeaderText = "RoleName",
                Name = "RoleName",
                DataPropertyName = "RoleName"
            });
            dgv.CellClick += dgvUsers_CellClick;
            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }


        private void StaffControl_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            LoadRolesCombobox();
            LoadUsersData();
        }

<<<<<<< HEAD
=======
=======
        public StaffControl()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }
        private void BeautyDGV()
        {
            // Không cho người dùng chỉnh cột
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            // Không cho thêm dòng mới
            dgvUsers.AllowUserToAddRows = false;
            // Tự động resize
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Chỉnh header đẹp
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.EnableHeadersVisualStyles = false;

            // Chỉnh cell
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.DefaultCellStyle.BackColor = Color.White;
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Canh giữa cho header
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Canh lề trái cho cell
            dgvUsers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        private void LoadUsersData()
        {
            dgvUsers.DataSource = null;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = _service.GetAllUsers();
        }
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        private void LoadRolesCombobox()
        {
            cbRole.DataSource = _service.GellAllRoles();
            cbRole.DisplayMember = "RoleName";
            cbRole.ValueMember = "RoleId";
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2

        private void ResetForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtGmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
<<<<<<< HEAD
=======
=======
        private void ResetForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            cbRole.SelectedIndex = 0;
            selectedUserID = -1;
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        private bool ValidateInput(out string message, bool isInsert = true)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                (isInsert && string.IsNullOrWhiteSpace(txtPassword.Text)) ||
<<<<<<< HEAD
=======
=======
        private void StaffControl_Load(object sender, EventArgs e)
        {
            BeautyDGV();
            LoadRolesCombobox();
            LoadUsersData();
        }
   

        private void btInsertReader_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                message = "Please fill in all required fields.";
                return false;
            }

            if (isInsert && txtPassword.Text.Length < 6)
            {
                message = "Password must be at least 6 characters long.";
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

        private void btInsertReader_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string message))
            {
                MessageBox.Show(message);
                return;
            }

<<<<<<< HEAD
=======
=======
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
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
                return;
            }
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            var user = new UserDTO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                RoleID = (int)cbRole.SelectedValue
            };
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            if (_service.Register(user))
            {
                MessageBox.Show("User has been added successfully!");
                LoadUsersData();
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                ResetForm();
            }
            else
            {
                MessageBox.Show("Failed! Username already exists.");
            }
<<<<<<< HEAD
=======
=======
            }
            else
                MessageBox.Show("Failed! Username already exists.");
            ResetForm();
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to update!");
                return;
            }

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            if (!ValidateInput(out string message, false))
            {
                MessageBox.Show(message);
                return;
            }

<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            var user = new UserDTO
            {
                UserID = selectedUserID,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                RoleID = (int)cbRole.SelectedValue
            };

            var success = _service.UpdateUser(user);
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            MessageBox.Show(success ? "Updated successfully!" : "Update failed.");
            LoadUsersData();
            ResetForm();
        }
<<<<<<< HEAD
=======
=======
            MessageBox.Show(success ? "Update succesfully!! ": "Failled!");
            LoadUsersData();
            ResetForm();
        }
 
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteUser(selectedUserID);
<<<<<<< HEAD
                MessageBox.Show(success ? "Delete successful" : "Delete failed");
=======
<<<<<<< HEAD
                MessageBox.Show(success ? "Delete successful" : "Delete failed");
=======
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                LoadUsersData();
                ResetForm();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtGmail.Text = row.Cells["Gmail"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                cbRole.Text = row.Cells["RoleName"].Value.ToString();
                selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbKw.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
<<<<<<< HEAD
=======
=======
                cbRole.Text = row.Cells["Role"].Value.ToString();

                // Lưu ID để sử dụng khi update/delete
                selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKw.Text))
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2

            dgvUsers.DataSource = null;

            if (rdID.Checked)
            {
                if (!int.TryParse(keyword, out int userId))
<<<<<<< HEAD
=======
=======
            if (rdID.Checked)
            {
                if (!int.TryParse(tbKw.Text, out int userId))
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                {
                    MessageBox.Show("User ID must be a number!");
                    return;
                }

                var user = _service.GetUserByUserId(userId);
                if (user == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

                tbKw.Text = "";
                dgvUsers.DataSource = null;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else if (rdName.Checked)
            {
<<<<<<< HEAD
                var user = _service.GetUserByUsername(keyword);
=======
<<<<<<< HEAD
                var user = _service.GetUserByUsername(keyword);
=======
                var user = _service.GetUserByUsername(tbKw.Text);
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                if (user == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
                tbKw.Text = "";
                dgvUsers.DataSource = null;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Username.");
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
                return;
            }

            tbKw.Clear();
        }
<<<<<<< HEAD
=======
=======
            }
        }

>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
    }
}
