using BusinessLayer;
using DTOs;
<<<<<<< HEAD
using Guna.UI2.WinForms;
=======
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
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace LibrarySystem.FormControl
{
    public partial class ReaderControl : UserControl
    {
        private ReaderService _service = new ReaderService();
        private int selectedReaderID = -1;
<<<<<<< HEAD
        private Guna2DataGridView dgv = new Guna2DataGridView();
=======
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
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535

        public ReaderControl()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
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
                HeaderText = "ReaderID",
                Name = "ReaderID",
                DataPropertyName = "ReaderID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "First Name",
                Name = "FirstName",
                DataPropertyName = "FirstName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Name",
                Name = "LastName",
                DataPropertyName = "LastName"
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
                HeaderText = "Gender",
                Name = "Gender",
                DataPropertyName = "Gender"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date",
                Name = "DateOfBirth",
                DataPropertyName = "DateOfBirth"
            });
            dgv.CellClick += dgv_CellClick; 


            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535

        private void LoadReaderData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetReaders();
        }
        private void LoadGenderCombobox()
        {
            cbGender.DataSource = new List<string> { "Male", "Female" };
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            if (!txtGmail.Text.Contains("@") || !txtGmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{9,11}$"))
            {
                MessageBox.Show("Phone number must be numeric and 9 to 11 digits long.");
                return false;
            }

            return true;
        }
        private void ResetForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtGmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
<<<<<<< HEAD
=======
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
        private void ResetForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
            cbGender.SelectedIndex = 0;
            dptDate.Value = DateTime.Today;
            selectedReaderID = -1;
        }

        private void ReaderControl_Load(object sender, EventArgs e)
        {
            LoadGenderCombobox();
<<<<<<< HEAD
            InitDataGridView();
=======
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
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
            LoadReaderData();
            dptDate.Value = DateTime.Today;

        }

        private void btInsert_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======
<<<<<<< HEAD
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
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
                return;
            }
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
            var reader = new ReaderDTO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gmail = txtGmail.Text,
                Gender=cbGender.SelectedItem.ToString(),
                DateOfBirth=dptDate.Value,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
            };
            if (_service.InsertReader(reader))
            {
                MessageBox.Show("Reader has been added successfully!");
                LoadReaderData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

      
        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedReaderID == -1)
            {
                MessageBox.Show("Please select a reader to update!");
                return;
            }
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======
<<<<<<< HEAD
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======
<<<<<<< HEAD
            if (!ValidateForm()) return;
=======

>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======

>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
            var reader = new ReaderDTO
            {
                ReaderID = selectedReaderID,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Gender = cbGender.SelectedItem.ToString(),
                DateOfBirth=dptDate.Value
            };

            var success = _service.UpdateReader(reader);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadReaderData();
            ResetForm();
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtGmail.Text = row.Cells["Gmail"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                cbGender.Text = row.Cells["Gender"].Value.ToString();
                dptDate.Text = row.Cells["DateOfBirth"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedReaderID = Convert.ToInt32(row.Cells["ReaderID"].Value);
            }

        }
        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedReaderID == -1)
            {
                MessageBox.Show("Please select a reader to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this reader?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteReader(selectedReaderID);
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
                LoadReaderData();
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
                if (!int.TryParse(tbKw.Text, out int readerId))
                {
                    MessageBox.Show("Reader ID must be a number!");
                    return;
                }

                var reader = _service.SearchReaderById(readerId);
                if (reader == null)
                {
                    MessageBox.Show("Reader not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<ReaderDTO> { reader };
            }
            else if (rdName.Checked)
            {
                var reader = _service.SearchReaderByName(tbKw.Text);
                if (reader == null)
                {
                    MessageBox.Show("Reader not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = reader;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
        }
    }
    }
