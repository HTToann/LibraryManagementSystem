﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
namespace LibrarySystem.FormControl
{
    public partial class AuthorControl : UserControl
    {
        private AuthorService _service = new AuthorService();
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
        private int selectedAuthorID = -1;
        public AuthorControl()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllAuthors();
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
                HeaderText = "AuthorID",
                Name = "AuthorID",
                DataPropertyName = "AuthorID"
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
                HeaderText = "DateOfBirth",
                Name = "DateOfBirth",
                DataPropertyName = "DateOfBirth"
            });

            dgv.CellClick += dgv_CellClick;
            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
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
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
        }
        private void ResetForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            selectedAuthorID = -1;
        }

        private void AuthorControl_Load(object sender, EventArgs e)
        {
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
            LoadData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                dtpDate.Text = row.Cells["DateOfBirth"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedAuthorID = Convert.ToInt32(row.Cells["AuthorID"].Value);
            }
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
               string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            return true;
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

        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
<<<<<<< HEAD
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535

            var author = new AuthorDTO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = dtpDate.Value
            };
            if (_service.InsertAuthor(author))
            {
                MessageBox.Show("Author has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAuthorID == -1)
            {
                MessageBox.Show("Please select a author to update!");
                return;
            }
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
<<<<<<< HEAD
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
<<<<<<< HEAD
            if (!ValidateForm())
                return;
=======
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535

            var author = new AuthorDTO
            {
                AuthorID=selectedAuthorID,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = dtpDate.Value
            };

            var success = _service.UpdateAuthor(author);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedAuthorID == -1)
            {
                MessageBox.Show("Please select a author to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this author?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteAuthor(selectedAuthorID);
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
                if (!int.TryParse(tbKw.Text, out int authorId))
                {
                    MessageBox.Show("Author ID must be a number!");
                    return;
                }

                var author = _service.GetAuthorById(authorId);
                if (author == null)
                {
                    MessageBox.Show("Author not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<AuthorDTO> { author };
            }
            else if (rdName.Checked)
            {
                var author = _service.GetAuthorByName(tbKw.Text);
                if (author == null)
                {
                    MessageBox.Show("Author not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = author;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
        }
    }
}
