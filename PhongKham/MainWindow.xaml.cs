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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadTennguoidung();
        }
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

        private void Patient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Patient f = new Patient();
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
            
            {
                Registration f = new Registration();
                this.Close();
                f.ShowDialog();
            }
            
        }

        private void Bill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Bill f = new Bill();
            this.Close();
            f.ShowDialog();
        }

        private void SignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login f = new Login();
            this.Close();
            f.Show();
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        public void Laythongtinnguoidung()//Lay ten thong tin nguoi dung
        {
            List<NhanVien> list = PK.NhanViens.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaNV.ToString() == UserInfo.UserId)
                {
                    UserInfo.UserName = list[i].TenNV;
                    UserInfo.SDT = list[i].SDT.ToString();
                    UserInfo.Chucvu = list[i].LoaiNV.Tenloai;
                    Phongban phongban = PK.Phongbans.Find(list[i].LoaiNV.Maloai_nv);
                    UserInfo.Maphongban = phongban.MaPhong;
                }
            }
        }
        // Load textbox tên người dùng 
        public void loadTennguoidung()
        {
            Laythongtinnguoidung();
            lab_UserName.Content = UserInfo.UserName;
        }
    }
}
