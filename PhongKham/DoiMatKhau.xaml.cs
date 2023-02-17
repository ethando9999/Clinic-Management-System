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
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        PhongKhamEntities PK = new PhongKhamEntities();
        private void Trove_Click_1(object sender, RoutedEventArgs e)
        {
            TaiKhoan f = new TaiKhoan();
            this.Close();
            f.Show();
        }
        
        // Nhấn vào textbox1 kiem tra mat khau dung khong? 
        public void TextBox_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            if (txtPassword.Password != UserInfo.UserPassword)
            {
                MessageBox.Show("Sai mật khẩu!");
            }
        }
        //Nhấn vào textbox2 kiem tra mat khau dung khong?
        public void TextBox_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            if (txtPassword.Password != UserInfo.UserPassword)
            {
                MessageBox.Show("Sai mật khẩu!");
            }
        }
        private void Xacnhan_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword1.Password != "" && txtPassword2.Password != "")
            {
                if (txtPassword1.Password == txtPassword2.Password)
                {
                    UserInfo.UserPassword = txtPassword1.Password;
                    NhanVien nv = PK.NhanViens.Find(UserInfo.UserId);
                    nv.Matkhau = UserInfo.UserPassword;
                    PK.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                    TaiKhoan f = new TaiKhoan();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mật khẩu mới!");
            }
        }
    }
}
