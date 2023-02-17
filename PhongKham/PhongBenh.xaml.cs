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
    /// Interaction logic for PhongBenh.xaml
    /// </summary>
    public partial class PhongBenh : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-E9KG6CQS\SQLEXPRESS ; Initial Catalog = QL_PhongKham; Integrated Security = True");
        public PhongBenh()
        {
            InitializeComponent();
            FormLoad();
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
        public void DemSoLuongBenhNhan()
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
                txt_Maphongbenh.Text = items.MaPhongBenh;
                txt_Tenphongbenh.Text = items.TenPhongBenh;
                btn_Sua.Content = "Sửa";
                HienTexBox();
            }
        }

        private void Trove_Click(object sender, RoutedEventArgs e)
        {
            //ThemBenhNhan f = new ThemBenhNhan();
            this.Close();
            //f.ShowDialog();
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            HienTexBox();
            LamMoi();
            txt_Maphongbenh.IsEnabled = true;
            btn_Sua.Content = "Lưu";
            btn_Them.IsEnabled = false;
        }

        private void Sửa_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Sua.Content == "Sửa")
            {
                String Maphongbenh = txt_Maphongbenh.Text;
                Phongbenh phongbenh = PK.Phongbenhs.Find(Maphongbenh);
                phongbenh.TenPhongbenh = txt_Tenphongbenh.Text;
                PK.SaveChanges();
                MessageBox.Show("Sửa Thành Công");
                FormLoad();
            }
            else if (btn_Sua.Content == "Lưu")
            {
                Phongbenh phongbenh = new Phongbenh();
                phongbenh.TenPhongbenh = txt_Tenphongbenh.Text;
                phongbenh.MaPhongbenh = txt_Maphongbenh.Text;
                PK.Phongbenhs.Add(phongbenh);
                PK.SaveChanges();
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
            var result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (dgv.SelectedItem == null)
                {
                    MessageBox.Show("Chọn 1 dòng trên datagird rồi tiếp tục!");
                }
                else if(SoluongBN() > 0)
                {
                    MessageBox.Show("Số lượng bệnh nhân trong phòng bệnh phải bằng 0 ");
                }
                else
                {
                    String Maphongbenh = txt_Maphongbenh.Text;
                    Phongbenh phongbenh = PK.Phongbenhs.Find(Maphongbenh);
                    phongbenh.TenPhongbenh = txt_Tenphongbenh.Text;
                    phongbenh.MaPhongbenh = txt_Maphongbenh.Text;
                    PK.Phongbenhs.Remove(phongbenh);
                    PK.SaveChanges();
                    MessageBox.Show("Đã Xóa");
                    FormLoad();
                }
            }
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        int slbn(string x)
        {
            conn.Open();
            int i = 0;
            string a = "select count(BenhNhan.MaBN) from Phongbenh,BenhNhan where Phongbenh.MaPhongbenh = '" + x + "' and Phongbenh.MaPhongbenh = BenhNhan.MaPhongbenh";
            SqlCommand oknha = new SqlCommand(a, conn);
            SqlDataReader okluon = oknha.ExecuteReader();
            if (okluon.Read())
            {
                i = okluon.GetInt32(0);
            }
            conn.Close();
            return i;
        }
        List<Phongbenh> List = new List<Phongbenh>();
        public void loadDataGrid()
        {
            dgv.Items.Clear();
            List = PK.Phongbenhs.ToList();
            for (int i = 0; i < List.Count; i++)
            {

                Items items = new Items();
                items.TenPhongBenh = List[i].TenPhongbenh;
                items.MaPhongBenh = List[i].MaPhongbenh;
                items.SoLuong = slbn(List[i].MaPhongbenh);
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
            txt_Tenphongbenh.Text = "";
            txt_Maphongbenh.Text = "";
            btn_Them.IsEnabled = true;
            btn_Sua.Content = "Sửa";
        }
        public void AnTextBox()
        {
            txt_Tenphongbenh.IsEnabled = false;
            txt_Maphongbenh.IsEnabled = false;
        }
        private void HienTexBox()
        {
            txt_Tenphongbenh.IsEnabled = true;
        }
        public class Items
        {
            public string MaPhongBenh { get; set; }
            public string TenPhongBenh { get; set; }
            public int SoLuong { get; set; }
        }
    }
}
