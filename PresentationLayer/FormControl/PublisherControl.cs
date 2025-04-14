using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class PublisherControl : UserControl
    {
        private PublisherService _service = new PublisherService();
        private int selectedPublisherID = -1;
        private Guna2DataGridView dgv = new Guna2DataGridView();

        public PublisherControl()
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
                HeaderText = "PublisherID",
                Name = "PublisherID",
                DataPropertyName = "PublisherID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Namee",
                DataPropertyName = "Name"
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

            dgv.CellClick += dgv_CellClick;

            // ✅ Thêm vào form hoặc container
            if (!this.Controls.Contains(dgv))
                this.Controls.Add(dgv);
        }
        private void LoadReaderData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllPublishers();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
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
            txtName.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            selectedPublisherID = -1;
        }

        private void PublisherControl_Load(object sender, System.EventArgs e)
        {
            InitDataGridView();
            LoadReaderData();
        }

        private void btInsert_Click(object sender, System.EventArgs e)
        {
            // Kiểm tra rỗng
            if (!ValidateForm())
                return;
            var publish = new PublisherDTO
            {
                Name = txtName.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
            };
            if (_service.InsertPublisher(publish))
            {
                MessageBox.Show("Publish has been added successfully!");
                LoadReaderData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, System.EventArgs e)
        {
            if (selectedPublisherID == -1)
            {
                MessageBox.Show("Please select a publish to update!");
                return;
            }
            if (!ValidateForm())
                return;

            var publish = new PublisherDTO
            {
                PublisherID = selectedPublisherID,
                Name = txtName.Text,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
            };

            var success = _service.UpdatePublisherr(publish);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadReaderData();
            ResetForm();
        }

        private void btDelete_Click(object sender, System.EventArgs e)
        {
            if (selectedPublisherID == -1)
            {
                MessageBox.Show("Please select a publisher to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this publisher?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeletePublisher(selectedPublisherID);
                MessageBox.Show(success ? "Delete successfull" : "Delete failed");
                LoadReaderData();
                ResetForm();
            }
        }

        private void btReset_Click(object sender, System.EventArgs e)
        {
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
                selectedPublisherID = Convert.ToInt32(row.Cells["PublisherID"].Value);
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
                if (!int.TryParse(tbKw.Text, out int publisherId))
                {
                    MessageBox.Show("Publisher ID must be a number!");
                    return;
                }

                var publisher = _service.GetPublisherById(publisherId);
                if (publisher == null)
                {
                    MessageBox.Show("Publisher not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<PublisherDTO> { publisher };
            }
            else if (rdName.Checked)
            {
                var publisher = _service.GetPublisherByName(tbKw.Text);
                if (publisher == null)
                {
                    MessageBox.Show("Publisher not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = publisher;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
        }
    }
}
