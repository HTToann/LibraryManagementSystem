<<<<<<< HEAD
﻿// ModernMainForm.cs - Cải tiến giao diện theo thiết kế hiện đại với Guna2 + icon
using System;
using System.Drawing;
using System.Windows.Forms;
using DTOs;
using Guna.UI2.WinForms;
using Guna.UI2.AnimatorNS;
using LibrarySystem.FormControl;
using FontAwesome.Sharp; // Thêm thư viện FontAwesome.WinForms (qua NuGet)
using BusinessLayer.Gmail;
using DTOs;
using System.Collections.Generic;
=======
﻿using LibrarySystem.FormControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a

namespace LibrarySystem
{
    public partial class MainForm : Form
    {
<<<<<<< HEAD
        private Guna2GradientPanel panelSidebar;
        private FlowLayoutPanel sidebarFlow;
        private Guna2Panel panelHeader;
        private Guna2CirclePictureBox avatar;
        private Guna2HtmlLabel userLabel;
        private Panel panelMain;
        private Guna2Transition transition = new Guna2Transition();
        private UserDTO _currentUser;

        public MainForm(UserDTO user)
        {
            InitializeComponent();
            _currentUser = user;
            InitUI();
        }

        private void InitUI()
        {
            this.Text = "Library System";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            transition.AnimationType = AnimationType.Scale;
            transition.Interval = 200;

            // --- Sidebar
            panelSidebar = new Guna2GradientPanel
            {
                Dock = DockStyle.Left,
                Width = 400,
                FillColor = Color.FromArgb(0, 102, 204),
                FillColor2 = Color.FromArgb(0, 80, 180),
                GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
            };

            // --- Label menu
            var sidebarHeader = new Panel
            {
                Height = 80,
                Dock = DockStyle.Top,
                BackColor=Color.Transparent,
            };

            var lblMenu = new Label
            {
                Text = "📚 Menu",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter, // 👈 Căn giữa cả ngang và dọc
                BackColor = Color.Transparent
            };
            sidebarHeader.Controls.Add(lblMenu);
            //sidebarHeader.Controls.Add(lblMenu);

            // --- FlowLayout chứa các nút
            sidebarFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.Transparent
            };
            panelSidebar.Controls.Add(sidebarFlow); // THÊM SAU header để nằm dưới
            panelSidebar.Controls.Add(sidebarHeader);
            var isAdmin = _currentUser.RoleName == "Admin";

            var menus = new List<(string label, IconChar icon)>
            {
                ("Reader", IconChar.Users),
                ("Return", IconChar.Reply),
                ("Borrow", IconChar.Book),
                ("Send Gmail", IconChar.Envelope)
            };
            if (isAdmin)
            {
                menus.Insert(0, ("Stats", IconChar.ChartLine));
                menus.AddRange(new[]
                {
                    ("Stats", IconChar.ChartLine),
                    ("Penalty", IconChar.MoneyBillAlt),
                    ("History", IconChar.History),
                    ("Detail", IconChar.ClipboardList),
                    ("Return Book", IconChar.UserClock),
                    ("Book-Author", IconChar.BookOpen),
                    ("Book", IconChar.BookReader),
                    ("Author", IconChar.User),
                    ("Category", IconChar.List),
                    ("Publisher", IconChar.Building),
                    ("Supplier", IconChar.Truck),
                    ("Staff", IconChar.UserTie),
                });
            }
            int y = 60;

            foreach (var (name, icon) in menus)
            {
                AddSidebarButton(name, icon, y += 50, () => HandleMenuClick(name));
            }

            // Header
            panelHeader = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                FillColor = Color.FromArgb(5, 47, 80)
            };

            var headerLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            panelHeader.Controls.Add(headerLayout);

            Label lblTitle = new Label
            {
                Text = "\uD83D\uDCDA Library Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
            headerLayout.Controls.Add(lblTitle, 1, 0);

            var userInfoPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 10, 10, 0),
                Padding = new Padding(0),
                Dock = DockStyle.Right
            };

            userLabel = new Guna2HtmlLabel
            {
                Text = _currentUser.FirstName + " " + _currentUser.LastName,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };

            avatar = new Guna2CirclePictureBox
            {
                Size = new Size(60, 60),
                Image = Image.FromFile(@"D:\\LibraryManagementSystem\\PresentationLayer\\Static\\default.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            avatar.Click += Avatar_Click;

            userInfoPanel.Controls.Add(userLabel);
            userInfoPanel.Controls.Add(avatar);
            headerLayout.Controls.Add(userInfoPanel, 2, 0);

=======
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
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

<<<<<<< HEAD
            this.Controls.Add(panelMain);
            this.Controls.Add(panelSidebar);
            this.Controls.Add(panelHeader);
        }

        private void AddSidebarButton(string text, IconChar icon, int top, Action action)
        {
            var iconBtn = new IconButton
            {
                Text = "  " + text,
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(230, 60),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(5, 4, 5, 4),
                FlatAppearance = { BorderSize = 0 }
            };

            iconBtn.MouseEnter += (s, e) => iconBtn.BackColor = Color.FromArgb(0, 120, 215);
            iconBtn.MouseLeave += (s, e) => iconBtn.BackColor = Color.Transparent;

            iconBtn.Click += (s, e) => action();

            sidebarFlow.Controls.Add(iconBtn); // Thêm vào flow
        }

        private void ShowControl(Control ctrl)
        {
            panelMain.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            ctrl.AutoSize = false;
            panelMain.Controls.Add(ctrl);
            transition.ShowSync(ctrl);
        }

        private void HandleMenuClick(string name)
        {
            switch (name)
            {
                case "Stats": ShowStatisticsForm(); break;
                case "Return": ShowControl(new BorrowReturnUI()); break;
                case "Borrow": ShowControl(new BorrowBookUI(_currentUser)); break;
                case "Penalty": ShowControl(new PenaltyControl()); break;
                case "History": ShowControl(new HistoryBorrowControl()); break;
                case "Detail": ShowControl(new DetailBorrowReturnBookControl()); break;
                case "Return Book": ShowControl(new BorrowReturnBookControl()); break;
                case "Book-Author": ShowControl(new Book_AuthorControl()); break;
                case "Book": ShowControl(new BookControl()); break;
                case "Author": ShowControl(new AuthorControl()); break;
                case "Category": ShowControl(new CategoryControl()); break;
                case "Publisher": ShowControl(new PublisherControl()); break;
                case "Reader": ShowControl(new ReaderControl()); break;
                case "Supplier": ShowControl(new SupplierControl()); break;
                case "Staff": ShowControl(new StaffControl()); break;
                case "Send gmail":SendReminder(); break;
                default: MessageBox.Show("Chưa xử lý chức năng này!"); break;
            }
        }
       
        private void Avatar_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Update Profile", null, (s, ev) => MessageBox.Show("Go to profile update screen."));
            menu.Items.Add("Change Password", null, (s, ev) => MessageBox.Show("Go to password change screen."));
            menu.Items.Add("Logout", null, (s, ev) => Logout());
            menu.Show(avatar, new Point(0, avatar.Height));
        }
        private void SendReminder()
        {
            GmailService _service = new GmailService();
            var list = _service.GetReadersToNotify(3); // Gửi trước 1 ngày

            foreach (var (reader, borrow) in list)
            {
                string subject = "📚 Reminder: Book Return Due Soon";
                string body = $"Hello {reader.FullName},\n\nThis is a reminder that your borrowed book(s) are due to be returned on {borrow.DateReturn:dd/MM/yyyy}.\n\nPlease return them on time to avoid penalties.\n\nThanks,\nLibrary System";

                try
                {
                    _service.SendEmailReminder(reader.Gmail, subject, body);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send to {reader.Gmail}: {ex.Message}");
                }
            }

            MessageBox.Show("Reminders sent successfully!");
        }
        private void Logout()
        {
            LoginFrom login = new LoginFrom();
            this.Hide();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.FormClosed += (s, args) => this.Close(); // Đảm bảo đóng hẳn app nếu login form bị tắt
            login.ShowDialog();
        }
        private void ShowStatisticsForm()
        {
            var statsForm = new StatisticsForm();
            statsForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            statsForm.MaximizeBox = false;
            statsForm.MinimizeBox = false;
            statsForm.StartPosition = FormStartPosition.CenterScreen;
            statsForm.Size = new Size(1600, 1000); // hoặc theo kích thước mong muốn
            statsForm.ShowDialog(this); // ✅ dùng ShowDialog để focus
=======
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
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
        }
    }
}
