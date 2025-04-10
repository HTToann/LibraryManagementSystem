using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
namespace LibrarySystem.FormControl
{
    public partial class ReaderControl : UserControl
    {
        private ReaderService _service = new ReaderService();
        public ReaderControl()
        {
            InitializeComponent();
        }

        private void btInsertReader_Click(object sender, EventArgs e)
        {
            var reader = new ReaderDTO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gender = cbGender.SelectedItem?.ToString() ?? "",
                DateOfBirth = dtpDate.Value,
                Gmail = txtGmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bool success = _service.AddReader(reader);
            if (success)
            {
                MessageBox.Show("Thêm độc giả thành công!");
                LoadReaderData(); // gọi hàm load lại danh sách (tự viết bên dưới)
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Kiểm tra dữ liệu.");
            }
        }
        private void LoadReaderData()
        {

            dgvReaders.DataSource = null;
            dgvReaders.Columns.Clear();
            dgvReaders.AutoGenerateColumns = true;
            dgvReaders.DataSource = _service.GetReaders();
            BeautifyGrid(); // 👈 gọi ở đây
        }
        private void BeautifyGrid()
        {
            dgvReaders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvReaders.RowHeadersVisible = false;

            dgvReaders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReaders.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReaders.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvReaders.ReadOnly = true;
            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReaders.ScrollBars = ScrollBars.Both;

            dgvReaders.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvReaders.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvReaders.Columns["ReaderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReaders.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void ReaderForm_Load(object sender, EventArgs e)
        {
            LoadReaderData();
        }
    }
}
