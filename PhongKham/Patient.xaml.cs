using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.SqlClient;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient()
        {
            InitializeComponent();
            formLoad();
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        string sdt = null;
        List<BenhNhan> bn = new List<BenhNhan>();
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

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
        public void addItemdgv(BenhNhan s)
        {
            Item item = new Item();
            item.TenBN = s.TenBN;
            item.GioiTinh = s.GioiTinh;
            item.NgaySinh = s.NgaySinh.Date.ToString("dd/MM/yyyy");
            item.SDT = s.Sodienthoai;
            item.NgayKham = s.NgayKham.Date.ToString("dd/MM/yyyy");
            item.PhongBenh = s.Phongbenh.TenPhongbenh;
            if (s.Nguoithan == null)
            {
                item.NguoiThan = "";
            }
            else
            {
                item.NguoiThan = s.Nguoithan.Tennguoithan;
            }
            dgv.Items.Add(item);
        }
        public void loadDatagrid()
        {
            dgv.Items.Clear();
            bn = PK.BenhNhans.ToList();
            foreach (BenhNhan s in bn)
            {
                addItemdgv(s);
            }
            dgv.SelectedItem = null;

        }
        public void formLoad()
        {
            loadDatagrid();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgv.Items.Clear();
            foreach (BenhNhan x in bn)
            {
                if (x.TenBN.Contains(txtSearch.Text))
                {
                    addItemdgv(x);
                }
            }
            dgv.SelectedItem = null;
        }
        public class Item
        {
            public string TenBN { get; set; }
            public string GioiTinh { get; set; }
            public string NgaySinh { get; set; }
            public string SDT { get; set; }
            public string NgayKham { get; set; }
            public string PhongBenh { get; set; }
            public string NguoiThan { get; set; }

        }
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv.SelectedItem == null)
            {
                return;
            }
            else
            {
                Item x = (Item)dgv.SelectedItem;
                sdt = x.SDT;
            }

        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemBenhNhan f = new ThemBenhNhan();
            this.Close();
            f.ShowDialog();
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            BenhNhan bn = PK.BenhNhans.FirstOrDefault(x => x.Sodienthoai == sdt);          
            PK.BenhNhans.Remove(bn);           
            PK.SaveChanges();
            MessageBox.Show("xóa Thành công");
            dgv.Items.Clear();
            formLoad();
        }
    }
}