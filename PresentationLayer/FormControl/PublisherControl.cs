using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class PublisherControl : UserControl
    {
        private PublisherService _service = new PublisherService();
        private int selectedPublisherID = -1;
        public PublisherControl()
        {
            InitializeComponent();
        }
        private void LoadReaderData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllPublishers();
        }

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
            txtName.Text = "";
            txtGmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            selectedPublisherID = -1;
        }

        private void PublisherControl_Load(object sender, System.EventArgs e)
        {
            BeautyDGV();
            LoadReaderData();
        }

        private void btInsert_Click(object sender, System.EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
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
