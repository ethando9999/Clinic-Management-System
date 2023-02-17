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
using System.Data.SqlClient;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
             List<NhanVien> list = PK.NhanViens.ToList();
             int k = 0;
             for (int i = 0; i < list.Count; i++)
             {
                 if (txtUserId.Text == list[i].MaNV.ToString() && txtPassword.Password.ToString() == list[i].Matkhau)
                 {
                     UserInfo.UserId = txtUserId.Text;
                     UserInfo.UserPassword = txtPassword.Password.ToString();
                     k++;
                 }
             }
             if (k > 0)
             {
                MainWindow f = new MainWindow();
                f.ShowDialog();
                this.Close();
            }
             else
             {
                 MessageBox.Show("Nhập sai tên đăng nhập hoặc password");
             }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Nhập mật khẩu nhấn enter để login
        private void login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
