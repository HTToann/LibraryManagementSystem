using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class CategoryControl : UserControl
    {
        private CategoryService _service = new CategoryService();
        private int selectedCategoryID = -1;
        public CategoryControl()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv.DataSource = null;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _service.GetAllCategories();
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

        }
        private void CategoryControl_Load(object sender, System.EventArgs e)
        {
            LoadData();
            BeautyDGV();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

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
