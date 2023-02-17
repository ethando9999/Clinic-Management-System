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
    /// Interaction logic for NguoiThan.xaml
    /// </summary>
    public partial class NguoiThan : Window
    {
        public NguoiThan()
        {
            InitializeComponent();
            FormLoad();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-E9KG6CQS\SQLEXPRESS; Initial Catalog = QL_PhongKham; Integrated Security = True");
        string ma = null;
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

        /// <summary>
        /// Xử lý ô giá chỉ nhận giá trị số
        /// </summary>
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void SignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        PhongKhamEntities PK = new PhongKhamEntities();
        public void loadDataGrid()
        {
            dgv.Items.Clear();
            List<Nguoithan> List = PK.Nguoithans.ToList();
            for (int i = 0; i < List.Count; i++)
            {
                Items items = new Items();
                items.MaNguoiThan = List[i].MaNguoithan;
                items.SDT = List[i].Sodienthoai;
                items.TenNguoiThan = List[i].Tennguoithan;
                dgv.Items.Add(items);
            }
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            HienTexBox();
            LamMoi();
            txt_Manguoithan.IsEnabled = true;
            btn_Sua.Content = "Lưu";
            btn_Them.IsEnabled = false;
        }
        private void Sửa_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Sua.Content == "Sửa")
            {
                String Manguoithan = txt_Manguoithan.Text;
                Nguoithan nguoithan = PK.Nguoithans.Find(Manguoithan);
                nguoithan.Tennguoithan = txt_Tennguoithan.Text;
                nguoithan.Sodienthoai = txt_Sdt.Text;
                PK.SaveChanges();
                MessageBox.Show("Sửa Thành Công");
                FormLoad();
            }
            else if (btn_Sua.Content == "Lưu")
            {
                Nguoithan nguoithan = new Nguoithan();
                nguoithan.MaNguoithan = txt_Manguoithan.Text;
                nguoithan.Tennguoithan = txt_Tennguoithan.Text;
                nguoithan.Sodienthoai = txt_Sdt.Text;
                PK.Nguoithans.Add(nguoithan);
                PK.SaveChanges();
                FormLoad();
            }
        }
        void updateBN(string mant)
        {
            List<BenhNhan> list = PK.BenhNhans.ToList();
            foreach(BenhNhan bn in list)
            {
                if(mant == bn.MaNguoithan)
                {
                    bn.MaNguoithan = null;
                }
            }
            PK.SaveChanges();
        }
        void xoaNT(string mant)
        {
            conn.Open();
            string de = "Delete from Nguoithan where MaNguoithan = '" + mant + "'";
            SqlCommand sqlcmd = new SqlCommand(de, conn);
            sqlcmd.ExecuteNonQuery();
        }
        private void Xóa_Click(object sender, RoutedEventArgs e)
        {
            // dgv.Items.Clear();
            var result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (dgv.SelectedItem == null)
                {
                    MessageBox.Show("Chọn 1 dòng trên datagird rồi tiếp tục!");
                }
                else
                {
                    string Manguoithan = txt_Manguoithan.Text;
                    Nguoithan nguoithan = PK.Nguoithans.Find(Manguoithan);
                    PK.Nguoithans.Remove(nguoithan);
                    //PK.SaveChanges();
                    updateBN(ma);
                    xoaNT(ma);
                    FormLoad();
                    MessageBox.Show("Đã Xóa");
                }
            }
        }
        private void Trove_Click(object sender, RoutedEventArgs e)
        {
            //ThemBenhNhan f = new ThemBenhNhan();
            this.Close();
            //f.ShowDialog();
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
                txt_Tennguoithan.Text = items.TenNguoiThan;
                txt_Manguoithan.Text = items.MaNguoiThan;
                txt_Sdt.Text = items.SDT;
                btn_Sua.Content = "Sửa";
                HienTexBox();
                txt_Manguoithan.IsEnabled = false;
                ma = items.MaNguoiThan;
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
            txt_Manguoithan.Text = "";
            txt_Sdt.Text = "";
            txt_Tennguoithan.Text = "";
            btn_Them.IsEnabled = true;
            btn_Sua.Content = "Sửa";
        }
        public void AnTextBox()
        {
            txt_Sdt.IsEnabled = false;
            txt_Manguoithan.IsEnabled = false;
            txt_Tennguoithan.IsEnabled = false;
        }
        private void HienTexBox()
        {
            txt_Sdt.IsEnabled = true;
            txt_Tennguoithan.IsEnabled = true;
        }
        public class Items
        {
            public string MaNguoiThan { get; set; }
            public string SDT { get; set; }
            public string TenNguoiThan { get; set; }

        }

    }
}
