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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window
    {
        public Department()
        {
            InitializeComponent();
            FormLoad();
        }

        List<Phongban> List = new List<Phongban>();
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-E9KG6CQS\SQLEXPRESS ; Initial Catalog = QL_PhongKham; Integrated Security = True");
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

        private void Patient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Patient f = new Patient();
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

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            HienTexBox();
            LamMoi();
            txt_Maphongban.IsEnabled = true;
            btn_Sua.Content = "Lưu";
            btn_Them.IsEnabled = false;
        }

        private void Sửa_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Sua.Content != "Sửa")
            {
                if (btn_Sua.Content == "Lưu")
                {
                    Phongban phongban = new Phongban();
                    phongban.TenP = txt_Tenphongban.Text;
                    phongban.MaPhong = txt_Maphongban.Text;
                    PK.Phongbans.Add(phongban);
                    PK.SaveChanges();
                    FormLoad();
                }
            }
            else
            {
                String Maphongban = txt_Maphongban.Text;
                Phongban phongban = PK.Phongbans.Find(Maphongban);
                phongban.TenP = txt_Tenphongban.Text;
                PK.SaveChanges();
                MessageBox.Show("Sửa Thành Công");
                FormLoad();
            }
        }

        public int SoluongBN()
        {
            Items items = (Items)dgv.SelectedItem;
            int soluong = items.SoLuong;
            return soluong;
        }

        private void Xóa_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (dgv.SelectedItem == null)
                {
                    MessageBox.Show("Chọn 1 dòng trên datagird rồi tiếp tục!");
                }
                else if (SoluongBN() > 0)
                {
                    MessageBox.Show("Số lượng bệnh nhân trong phòng bệnh phải bằng 0 ");
                }
                else
                {
                    String Maphongban = txt_Maphongban.Text;
                    Phongban phongban = PK.Phongbans.Find(Maphongban);
                    phongban.TenP = txt_Tenphongban.Text;
                    phongban.MaPhong = txt_Maphongban.Text;
                    PK.Phongbans.Remove(phongban);
                    PK.SaveChanges();
                    MessageBox.Show("Đã Xóa");
                    FormLoad();
                }
            }
        }

        void getsl()
        {

        }
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv.SelectedItem == null)
            {
                return;
            }
            else
            {
                Items items = (Items)dgv.SelectedItem;
                txt_Maphongban.Text = items.MaPhongBan;
                txt_Tenphongban.Text = items.TenPhongBan;
                btn_Sua.Content = "Sửa";
                HienTexBox();
            }
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        int get_sl(string x)
        {
            conn.Open();
            int y = 0;
            string se = "select COUNT(MaNV) from NhanVien,LoaiNV,Phongban where Phongban.MaPhong ='" + x + "' and Phongban.MaPhong = LoaiNV.MaPhong and LoaiNV.Maloai_nv =NhanVien.Maloai_nv";
            SqlCommand sqlcmd = new SqlCommand(se, conn);
            SqlDataReader rd = sqlcmd.ExecuteReader();
            if (rd.Read())
            {
                y = rd.GetInt32(0);
            }
            conn.Close();
            return y;
        }
        public void loadDataGrid()
        {
            dgv.Items.Clear();
            List = PK.Phongbans.ToList();
            for (int i = 0; i < List.Count; i++)
            {
                Items items = new Items();
                items.TenPhongBan = List[i].TenP;
                items.MaPhongBan = List[i].MaPhong;
                items.SoLuong = get_sl(List[i].MaPhong);
                dgv.Items.Add(items);
            }
        }
        public void FormLoad()
        {
            loadDataGrid();
            AnTextBox();
            LamMoi();
        }
        public void LamMoi()
        {
            txt_Maphongban.Text = "";
            txt_Tenphongban.Text = "";
            btn_Them.IsEnabled = true;
            btn_Sua.Content = "Sửa";
        }
        public void AnTextBox()
        {
            txt_Maphongban.IsEnabled = false;
            txt_Tenphongban.IsEnabled = false;
        }
        private void HienTexBox()
        {
            txt_Tenphongban.IsEnabled = true;
        }
        public class Items
        {
            public string MaPhongBan { get; set; }
            public string TenPhongBan { get; set; }
            public int SoLuong { get; set; }
        }
    }
}
