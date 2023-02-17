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
    /// Interaction logic for ThemThuoc.xaml
    /// </summary>
    public partial class ThemThuoc : Window
    {
        public ThemThuoc()
        {
            InitializeComponent();
            formLoad();
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
        public void formLoad()
        {
            addDonvi();
            addTenthuoc();
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

        /// <summary>
        /// Xử lý ô giá chỉ nhận giá trị số
        /// </summary>
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void BtnRefesh_Click(object sender, RoutedEventArgs e)
        {
            txt_Mathuoc.Text = "";
            cbb_Tenthuoc.Text = "";
            txt_Donvi.Text = "";
            txt_Soluong.Text = "";
            editProductPrice.Text = "";
            txt_Mathuoc.IsEnabled = true;
        }
        PhongKhamEntities PK = new PhongKhamEntities();
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            String[] str = { txt_Mathuoc.Text,
                cbb_Tenthuoc.Text,
                txt_Soluong.Text,
                editProductPrice.Text
            };
            String[] warn = { "Vui lòng điền mã thuốc ",
                "Vui lòng điền tên thuốc",
                "Vui lòng điền số lượng thuốc",
                "Vui lòng điền giá thuốc"
            };
            String show = "";
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == "")
                {
                    show += warn[i] + "\n";
                }
            }
            if (show.Length > 0)
            {
                MessageBox.Show(show);
            }
            else if (KtraMathuoc())
            {
                Thuoc thuoc = PK.Thuocs.Find(Int32.Parse(txt_Mathuoc.Text));
                thuoc.Tenthuoc = cbb_Tenthuoc.Text;
                int soluong = thuoc.Soluongton + Int32.Parse(txt_Soluong.Text);
                thuoc.Soluongton = soluong;
                thuoc.Madonvi = getMadonvi(txt_Donvi.Text);
                thuoc.Giathuoc = Double.Parse(editProductPrice.Text);
                PK.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                BtnRefesh_Click(sender, e);
            }
            else
            {
                Thuoc th = new Thuoc()
                {
                    Mathuoc = Int32.Parse(txt_Mathuoc.Text),
                    Tenthuoc = cbb_Tenthuoc.Text,
                    Soluongton = Int32.Parse(txt_Soluong.Text),
                    Madonvi = getMadonvi(txt_Donvi.Text),
                    Giathuoc = Double.Parse(editProductPrice.Text)
                };
                PK.Thuocs.Add(th);
                PK.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                BtnRefesh_Click(sender, e);
            }

        }

        //Lấy mã đơn vị từ tên đơn vị
        public int getMadonvi(string tendonvi)
        {
            Donvi donvi = PK.Donvis.FirstOrDefault(x => x.TenDonVi == tendonvi);
            int madonvi = donvi.MaDonVi;
            return madonvi;
        }

        public bool KtraMathuoc()
        {
            bool ketqua = false;
            int mathuoc = Int32.Parse(txt_Mathuoc.Text);
            Thuoc thuoc = PK.Thuocs.Find(mathuoc);
            if(thuoc != null)
            {
                ketqua = true;
            }
            return ketqua;
        }

        private void BtnTrove_Click(object sender, RoutedEventArgs e)
        {
            Pills f = new Pills();
            this.Close();
            f.ShowDialog();
        }
        public class Item
        {
            public string TenDonVi { set; get; }
            public int MaDonVi { set; get; }

        }
        private void txt_Donvi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void addDonvi()
        {
            txt_Donvi.Items.Clear();
            List<Donvi> donvi = PK.Donvis.ToList();
            foreach (Donvi dv in donvi)
            {
                txt_Donvi.Items.Add(dv.TenDonVi);
            }
        }
        public void addTenthuoc()
        {
            List<Thuoc> list = PK.Thuocs.ToList();
            cbb_Tenthuoc.ItemsSource = list;
            cbb_Tenthuoc.DisplayMemberPath = "Tenthuoc";
            cbb_Tenthuoc.SelectedValuePath = "Mathuoc";
        }





        private void txt_Mathuoc__MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txt_Mathuoc__touchDown(object sender, TouchEventArgs e)
        {

        }

        private void txt_Mathuoc__click(object sender, MouseButtonEventArgs e)
        {

        }

        private void cbb_Tenthuoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Thuoc thuoc = PK.Thuocs.Find(cbb_Tenthuoc.SelectedValue);
            if(thuoc == null)
            {
                return;
            }
            else
            {
                txt_Mathuoc.Text = thuoc.Mathuoc.ToString();
                txt_Mathuoc.IsEnabled = false;
                editProductPrice.Text = thuoc.Giathuoc.ToString();
                txt_Donvi.Text = thuoc.Donvi.TenDonVi;
            }

        }
    }
}

