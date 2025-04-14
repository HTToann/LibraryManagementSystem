using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DTOs;
using Guna.UI2.WinForms;

namespace LibrarySystem.FormControl
{
    public partial class Book_AuthorControl : UserControl
    {
        private BookAuthorService _service = new BookAuthorService();
        private BookService _bookService = new BookService();
        private AuthorService _authorService = new AuthorService();
        private Guna2DataGridView dgv = new Guna2DataGridView();


        private int selectedBookAuthorID = -1;
        public Book_AuthorControl()
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
                HeaderText = "ID",
                Name = "ID",
                DataPropertyName = "ID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "AuthorID",
                Name = "AuthorID",
                DataPropertyName = "AuthorID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BookID",
                Name = "BookID",
                DataPropertyName = "BookID"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "AuthorName",
                Name = "AuthorName",
                DataPropertyName = "AuthorName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "BookName",
                Name = "BookName",
                DataPropertyName = "BookName"
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
            dgv.DataSource = _service.GetAllBookAuthors();
        }

        private void LoadComboBoxes()
        {
            cbAuthor.DataSource = _authorService.GetAllAuthors();
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "AuthorID";
            cbAuthor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAuthor.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbBook.DataSource = _bookService.GetAllBooks();
            cbBook.DisplayMember = "Name";
            cbBook.ValueMember = "BookID";
            cbBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBook.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
      
        private void ResetForm()
        {
        }

        private void Book_AuthorControl_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            InitDataGridView();
            LoadData();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
           
            var bookAuthor = new BookAuthorDTO
            {
                AuthorID = (int)cbAuthor.SelectedValue,
                BookID = (int)cbBook.SelectedValue,
            };
            if (_service.InsertBookAuthor(bookAuthor))
            {
                MessageBox.Show("BookAuthor has been added successfully!");
                LoadData();
            }
            else
                MessageBox.Show("Failed!!.");
            ResetForm();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookAuthorID == -1)
            {
                MessageBox.Show("Please select a row to update!");
                return;
            }

            var bookAuthor = new BookAuthorDTO
            {
                ID=selectedBookAuthorID,
                AuthorID = (int)cbAuthor.SelectedValue,
                BookID = (int)cbBook.SelectedValue,
            };

            var success = _service.UpdateBookAuthor(bookAuthor);
            MessageBox.Show(success ? "Update succesfully!! " : "Failled!");
            LoadData();
            ResetForm();

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookAuthorID == -1)
            {
                MessageBox.Show("Please select a rowdata to delete!");
                return;
            }

            var confirm = MessageBox.Show("Do you want to delete this row?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var success = _service.DeleteBookAuthor(selectedBookAuthorID);
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
                if (!int.TryParse(tbKw.Text, out int bookAuthorId))
                {
                    MessageBox.Show("BookAuthor ID must be a number!");
                    return;
                }

                var bookAuthor = _service.GetBookAuthorById(bookAuthorId);
                if (bookAuthor == null)
                {
                    MessageBox.Show("BookAuthor not found!");
                    return;
                }

                tbKw.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = new List<BookAuthorDTO> { bookAuthor };
            }
            else if (rdName.Checked)
            {
                var authorResults = _service.GetBookAuthorByAuthorName(tbKw.Text);

                if (authorResults != null && authorResults.Count > 0)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = authorResults;
                }
                else
                {
                    // Không tìm thấy theo tác giả, thử theo tên sách
                    var bookResults = _service.GetBookAuthorByBookName(tbKw.Text);

                    if (bookResults != null && bookResults.Count > 0)
                    {
                        dgv.DataSource = null;
                        dgv.DataSource = bookResults;
                    }
                    else
                    {
                        MessageBox.Show("No matching author or book found!");
                    }
                }

                tbKw.Text = "";
            }
            else
            {
                MessageBox.Show("Please select search type: ID or Name.");
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                cbAuthor.Text = row.Cells["AuthorID"].Value.ToString();
                cbBook.Text = row.Cells["BookID"].Value.ToString();
                // Lưu ID để sử dụng khi update/delete
                selectedBookAuthorID = Convert.ToInt32(row.Cells["BookID"].Value);
            }
        }
    }
}
