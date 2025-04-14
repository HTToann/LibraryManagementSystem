using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class CategoryControl : UserControl
    {
        private CategoryService _service = new CategoryService();
        private int selectedCategoryID = -1;
        private Guna2DataGridView dgv = new Guna2DataGridView();

        public CategoryControl()
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
                HeaderText = "CategoryID",
                Name = "CategoryID",
                DataPropertyName = "CategoryID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Namee",
                DataPropertyName = "Name"
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
            dgv.DataSource = _service.GetAllCategories();
        }


        private void ResetForm()
        {
            txtName.Text = "";

        }
        private void CategoryControl_Load(object sender, System.EventArgs e)
        {
            LoadData();
            InitDataGridView();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }
            return true;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (!ValidateForm())
                return;

            var category = new CategoryDTO
            {
                Name = txtName.Text,
            };
            if (_service.InsertCategory(category))
            {
                MessageBox.Show("Category has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCategoryID == -1)
            {
                MessageBox.Show("Please select a category to update!");
                return;
            }
            if (!ValidateForm())
                return;


            var category = new CategoryDTO
            {
                CategoryID=selectedCategoryID,
                Name = txtName.Text,

            };

            var success = _service.UpdateCategory(category);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryID == -1)
            {
                MessageBox.Show("Please select a category to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this category?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteCategory(selectedCategoryID);
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

            if (string.IsNullOrWhiteSpace(tbKw.Text))
            {
                MessageBox.Show("Keyword cannot be empty!");
                return;
            }
            if (rdID.Checked)
            {
                if (!int.TryParse(tbKw.Text, out int categoryId))
                {
                    MessageBox.Show("Category ID must be a number!");
                    return;
                }

                var category = _service.GetCategoryById(categoryId);
                if (category == null)
                {
                    MessageBox.Show("Category not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<CategoryDTO> { category };
            }
            else if (rdName.Checked)
            {
                var category = _service.GetCategoryByName(tbKw.Text);
                if (category == null)
                {
                    MessageBox.Show("Category not found!");
                    return;
                }
                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = category;
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtName.Text = row.Cells["Namee"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedCategoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
            }
        }
    }
}
