using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class AuthorControl : UserControl
    {
        private AuthorService _service = new AuthorService();
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
            selectedAuthorID = -1;
        }

        private void AuthorControl_Load(object sender, EventArgs e)
        {
            BeautyDGV();
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

        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

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
