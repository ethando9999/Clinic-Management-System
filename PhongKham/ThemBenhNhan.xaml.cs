using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for ThemBenhNhan.xaml
    /// </summary>
    public partial class ThemBenhNhan : Window
    {

        public ThemBenhNhan()
        {
            InitializeComponent();
            FormLoad();
        }
        // Set tooltip visibility
        BenhNhan bn;
        // string sql = @"Data Source = MQTOAN; Initial Catalog = ProductOrder; Integrated Security = True";
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-E9KG6CQS\SQLEXPRESS ; Initial Catalog = QL_PhongKham; Integrated Security = True");
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_staffs.Visibility = Visibility.Collapsed;
                tt_patient.Visibility = Visibility.Collapsed;
                tt_department.Visibility = Visibility.Collapsed;
                tt_pills.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
                tt_document.Visibility = Visibility.Collapsed;
                tt_bill.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_staffs.Visibility = Visibility.Visible;
                tt_patient.Visibility = Visibility.Visible;
                tt_department.Visibility = Visibility.Visible;
                tt_pills.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
                tt_document.Visibility = Visibility.Visible;
                tt_bill.Visibility = Visibility.Visible;
            }
        }
        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow f = new MainWindow();
            this.Close();
            f.ShowDialog();
        }
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan f = new TaiKhoan();
            this.Close();
            f.ShowDialog();
        }

        private void Staff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Staffs f = new Staffs();
            this.Close();
            f.ShowDialog();
        }

        private void Department_Mousedown(object sender, MouseButtonEventArgs e)
        {
            Department f = new Department();
            this.Close();
            f.ShowDialog();
        }

        private void Pill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pills f = new Pills();
            this.Close();
            f.ShowDialog();
        }

        private void Registration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UserInfo.Maphongban == "4" && UserInfo.Maphongban == "1")
            {
                Registration f = new Registration();
                this.Close();
                f.ShowDialog();
            }
            return;
        }

        private void Bill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UserInfo.Maphongban == "4" && UserInfo.Maphongban == "1")
            {
                Bill f = new Bill();
                this.Close();
                f.ShowDialog();
            }
            return;
        }

        private void SignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        void show_NT()
        {
            cbbNguoithan.Items.Clear();
            conn.Open();
            string a = "SELECT [MaNguoithan],[Tennguoithan],[Sodienthoai]FROM[QL_PhongKham].[dbo].[Nguoithan]";
            SqlCommand sql = new SqlCommand(a, conn);
            SqlDataReader rd = sql.ExecuteReader();
            while (rd.Read())
            {
                string ma = rd.GetString(0);
                string ten = rd.GetString(1);
                string ma_ten = ma + "-" + ten;
                cbbNguoithan.Items.Add(ma_ten);
            }
            rd.Close();
            conn.Close();

        }
        void show_PB()
        {
            cbbPhongbenh.Items.Clear();
            conn.Open();
            string a = "SELECT [MaPhongbenh],[TenPhongbenh] FROM[QL_PhongKham].[dbo].[Phongbenh]";
            SqlCommand sql = new SqlCommand(a, conn);
            SqlDataReader rd = sql.ExecuteReader();
            while (rd.Read())
            {
                string ma = rd.GetString(0);
                string ten = rd.GetString(1);
                string ma_ten = ma + "-" + ten;
                cbbPhongbenh.Items.Add(ma_ten);
            }
            rd.Close();
            conn.Close();
        }
        #region Xử lý hiệu ứng Comboxbox giới tính
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbbGioitinh_DropDownOpened(object sender, EventArgs e)
        {
            cbbGioitinh.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void cbbGioitinh_DropDownClosed(object sender, EventArgs e)
        {
            cbbGioitinh.Background = Brushes.Transparent;
        }
        #endregion


        #region Xử lý hiệu ứng Comboxbox Nguoi thân
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbbNguoithan_DropDownOpened(object sender, EventArgs e)
        {
            cbbNguoithan.Background = Brushes.LightGray;
            cbbGioitinh.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void cbbNguoithan_DropDownClosed(object sender, EventArgs e)
        {
            cbbNguoithan.Background = Brushes.Transparent;
            cbbGioitinh.Background = Brushes.Transparent;
        }
        #endregion

        #region Xử lý hiệu ứng Comboxbox phòng bệnh
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbbPhongbenh_DropDownOpened(object sender, EventArgs e)
        {
            cbbPhongbenh.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        /// 

        /// <summary>
        /// Xử lý ô giá chỉ nhận giá trị số
        /// </summary>
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void cbbPhongbenh_DropDownClosed(object sender, EventArgs e)
        {
            cbbPhongbenh.Background = Brushes.Transparent;
        }
        #endregion

        public void FormLoad()
        {
            add_cbbGioitinh();
            show_NT();
            show_PB();
        }
        // Add item combobox giới tính 
        public void add_cbbGioitinh()
        {
            cbbGioitinh.Items.Add("Nam");
            cbbGioitinh.Items.Add("Nữ");
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();

            bn = new BenhNhan();
            int mabn = Convert.ToInt32(txt_Mabenhnhan.Text);
            bn.TenBn = txt_TenBN.Text;
            bn.GT = cbbGioitinh.SelectedItem.ToString();
            bn.NgaySinh = DateNgaysinh.DisplayDate;
            bn.SDT = txt_SDT.Text;
            bn.ngaykham = DateTime.Today;
            string mnt = cbbNguoithan.SelectedItem.ToString();
            string[] ma = mnt.Split('-');
            bn.MaNT = ma[0];
            string mpb = cbbPhongbenh.SelectedItem.ToString();
            string[] map = mpb.Split('-');
            bn.MaPB = map[0];
            string insert = @"insert into BenhNhan (MaBN,TenBN,GioiTinh,NgaySinh,Sodienthoai,NgayKham,MaNguoithan,MaPhongbenh)	 values "
                                   + "(" + mabn + ", N'" + bn.TenBn + "', N'" + bn.GT + "', '" + bn.NgaySinh + "', '" + bn.SDT + "', '" + bn.ngaykham + "', '" + bn.MaNT + "', '" + bn.MaPB + "')";
            SqlCommand sqlcmd = new SqlCommand(insert, conn);

            sqlcmd.ExecuteNonQuery();
            MessageBox.Show("Them Thanh Cong");
        }
        class BenhNhan
        {
            public string TenBn { get; set; }
            public string GT { get; set; }
            public DateTime NgaySinh { get; set; }
            public string SDT { get; set; }
            public DateTime ngaykham { get; set; }
            public string MaNT { get; set; }
            public string MaPB { get; set; }
        }
        private void BtnRefesh_Click(object sender, RoutedEventArgs e)
        {
            txt_Mabenhnhan.Text = "";
            txt_SDT.Text = "";
            txt_TenBN.Text = "";
            DateNgaysinh.Text = "";
            cbbGioitinh.SelectedIndex = -1;
            cbbNguoithan.SelectedIndex = -1;
            cbbPhongbenh.SelectedIndex = -1;
        }

        private void BtnAddNguoiThan_Click(object sender, RoutedEventArgs e)
        {
            NguoiThan f = new NguoiThan();
           // this.Close();
            f.ShowDialog();
        }

        private void BtnAddPhongBenh_Click(object sender, RoutedEventArgs e)
        {
            PhongBenh f = new PhongBenh();
            //this.Close();
            f.ShowDialog();
        }

        private void load_cbb_Click(object sender, RoutedEventArgs e)
        {
            show_NT();
            show_PB();
        }

        private void BtnTrove_Click(object sender, RoutedEventArgs e)
        {
            Patient f = new Patient();
            this.Close();
            f.ShowDialog();
        }
    }
}