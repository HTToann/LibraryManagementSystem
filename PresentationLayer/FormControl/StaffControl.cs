using BusinessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace LibrarySystem.FormControl
{
    public partial class StaffControl : UserControl
    {
        private UserService _service = new UserService();
        private int selectedUserID = -1;
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
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            cbRole.SelectedIndex = 0;
            selectedUserID = -1;
        }

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
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
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
            }
            else
                MessageBox.Show("Failed! Username already exists.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to update!");
                return;
            }

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
            MessageBox.Show(success ? "Update succesfully!! ": "Failled!");
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
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
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
                txtGmail.Text = row.Cells["Gmail"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                cbRole.Text = row.Cells["Role"].Value.ToString();

                // Lưu ID để sử dụng khi update/delete
                selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
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
                if (!int.TryParse(tbKw.Text, out int userId))
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

                tbKw.Text = "";
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else if (rdName.Checked)
            {
                var user = _service.GetUserByUsername(tbKw.Text);
                if (user == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                }
                tbKw.Text = "";
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = new List<UserDTO> { user };
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Username.");
            }
        }

    }
}
