using LibrarySystem.FormControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class MainForm : Form
    {
        private Panel panelSidebar;
        private Panel panelHeader;
        private Panel panelMain;
        private UserControl currentControl;
        public MainForm()
        {
            InitializeComponent();
            InitLayout();
        }

        private void ShowControl(UserControl control)
        {
            panelMain.Controls.Clear(); // Xóa control cũ (nếu có)
            control.Dock = DockStyle.Fill; // Tự động lấp đầy panel
            panelMain.Controls.Add(control); // Thêm vào đúng panelMain
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelSidebar.AutoScroll = true;
            CreateDynamicButtons();
        }


        private void InitLayout()
        {
            this.Text = "Library Management";
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Sidebar
            panelSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.FromArgb(5, 47, 80),
                AutoScroll = true
            };

            // Header
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(0, 122, 204)
            };
            Label lblTitle = new Label
            {
                Text = "Library Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Resize += (s, e) =>
            {
                lblTitle.Location = new Point(
                    (panelHeader.ClientSize.Width - lblTitle.Width) / 2,
                    (panelHeader.ClientSize.Height - lblTitle.Height) / 2
                );
            };

            // Main panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // ✅ Quan trọng: thêm panelMain TRƯỚC
            this.Controls.Add(panelMain);
            this.Controls.Add(panelSidebar);
            this.Controls.Add(panelHeader);

            // Gọi thủ công căn giữa ban đầu
            panelHeader.PerformLayout();
            lblTitle.Location = new Point(
                (panelHeader.ClientSize.Width - lblTitle.Width) / 2,
                (panelHeader.ClientSize.Height - lblTitle.Height) / 2
            );
        }

        private void CreateDynamicButtons()
        {
            string[] buttonNames = {
        "Staff", "Supplier", "Reader",
        "Publisher", "Category", "Author",
        "Book", "Book-Author", "Borrow Return Book", "Detail Borrow Return","History Borrow","Penalty"
             };

            panelSidebar.Controls.Clear();

            foreach (string name in buttonNames)
            {
                Button btn = new Button
                {
                Text = name,
                Height = 45,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Tag = name // Gắn tên để xử lý về sau
               };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += DynamicButton_Click;

                // Hover hiệu ứng
                btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(30, 144, 255); };
                btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(0, 120, 215); };

                panelSidebar.Controls.Add(btn);
            }
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string tag = clickedButton.Tag.ToString();

            //MessageBox.Show($"Bạn vừa nhấn: {tag}");

            switch (tag)
            {
                case "Staff":
                    ShowControl(new StaffControl());
                    break;
                case "Reader":
                    ShowControl(new ReaderControl());
                    break;
                case "Supplier":
                    ShowControl(new SupplierControl());
                    break;
                case "Publisher":
                    ShowControl(new PublisherControl());
                    break;
                case "Category":
                    ShowControl(new CategoryControl());
                    break;
                case "Author":
                    ShowControl(new AuthorControl());
                    break;
                case "Book":
                    ShowControl(new BookControl());
                    break;
                case "Book-Author":
                    ShowControl(new Book_AuthorControl());
                    break;
                case "Borrow Return Book":
                    ShowControl(new BorrowReturnBookControl());
                    break;
                case "Detail Borrow Return":
                    ShowControl(new DetailBorrowReturnBookControl());
                    break;
                case "History Borrow":
                    ShowControl(new HistoryBorrowControl());
                    break;
                case "Penalty":
                    ShowControl(new PenaltyControl());
                    break;
                // thêm các case còn lại...
                default:
                    MessageBox.Show("Chưa xử lý chức năng này!");
                    break;
            }
        }
    }
}
