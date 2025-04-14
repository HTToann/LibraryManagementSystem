// Optimized and validated version of StaffControl.cs
using BusinessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class StaffControl : UserControl
    {
        private UserService _service = new UserService();
        private int selectedUserID = -1;
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
                HeaderText = "Password",
                Name = "Password",
                DataPropertyName = "Password"
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

        private void LoadUsersData()
        {
            dgvUsers.DataSource = null;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = _service.GetAllUsers();
        }

        private void LoadRolesCombobox()
        {
            cbRole.DataSource = _service.GellAllRoles();
            cbRole.DisplayMember = "RoleName";
            cbRole.ValueMember = "RoleId";
        }

        private void ResetForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtGmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbRole.SelectedIndex = 0;
            selectedUserID = -1;
        }

        private bool ValidateInput(out string message, bool isInsert = true)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                (isInsert && string.IsNullOrWhiteSpace(txtPassword.Text)) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
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

            if (_service.Register(user))
            {
                MessageBox.Show("User has been added successfully!");
                LoadUsersData();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Failed! Username already exists.");
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to update!");
                return;
            }

            if (!ValidateInput(out string message, false))
            {
                MessageBox.Show(message);
                return;
            }

            var user = new UserDTO
            {
                UserID = selectedUserID,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Password= txtPassword.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                RoleID = (int)cbRole.SelectedValue
            };

            var success = _service.UpdateUser(user);
            MessageBox.Show(success ? "Updated successfully!" : "Update failed.");
            LoadUsersData();
            ResetForm();
        }

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
                MessageBox.Show(success ? "Delete successful" : "Delete failed");
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
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtGmail.Text = row.Cells["Gmail"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                cbRole.Text = row.Cells["RoleName"].Value.ToString();
                selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbKw.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }

            dgvUsers.DataSource = null;

            if (rdID.Checked)
            {
                if (!int.TryParse(keyword, out int userId))
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
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else if (rdName.Checked)
            {
                var user = _service.GetUserByUsername(keyword);
                if (user == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                }
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Username.");
                return;
            }

            tbKw.Clear();
        }
    }
}
