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
using Aspose.Cells;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for Pills.xaml
    /// </summary>
    public partial class Pills : Window
    {
        PhongKhamEntities PK = new PhongKhamEntities();
        public Pills()
        {
            InitializeComponent();

            formload();
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

        #region Xử lý hiệu ứng Comboxbox
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void ComboProductTypes_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>


        /// <summary>
        /// Xử lý ô giá chỉ nhận giá trị số
        /// </summary>
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void ComboProductTypes_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.Transparent;
        }
        #endregion
        // Sự kiện thay đổi combobox
        private void ComboSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Nếu danh sách thuốc khác null thì sắp xếp lại
            sapxep();
        }

        public class Item
        {
            public string TenThuoc { set; get; }
            public int SoLuong { set; get; }
            public string DonVi { set; get; }
            public double GiaBan { set; get; }
        }
        public void formload()
        {

            themSapXep();
            loadItem();
        }
        Item dele;
        private void dgvPill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item item = (Item)dgv_Pill.SelectedItem;
            dele = item;
        }
        public void loadItem()
        {
            dgv_Pill.Items.Clear();
            List<Thuoc> thuoc = PK.Thuocs.ToList();
            for (var i = 0; i < thuoc.Count; i++)
            {
                Item item = new Item();
                item.TenThuoc = thuoc[i].Tenthuoc;
                item.SoLuong = thuoc[i].Soluongton;
                item.DonVi = thuoc[i].Donvi.TenDonVi;
                item.GiaBan = thuoc[i].Giathuoc;
                dgv_Pill.Items.Add(item);
            }

            dgv_Pill.SelectedItem = null;
        }

        public void themSapXep()
        {
            cbbSapXep.Items.Clear();
            cbbSapXep.Items.Add("Sắp xếp theo tên thuốc A-Z");
            cbbSapXep.Items.Add("Sắp xếp theo tên thuốc Z-A");
            cbbSapXep.Items.Add("Sắp xếp theo giá thuốc bé-lớn");
            cbbSapXep.Items.Add("Sắp xếp theo giá thuốc lớn-bé");

        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            List<Thuoc> thuoc = PK.Thuocs.ToList();
            for (var i = 0; i < thuoc.Count; i++)
            {
                if (dele.TenThuoc == thuoc[i].Tenthuoc)
                {
                    dgv_Pill.Items.Remove(thuoc[i]);
                    PK.Thuocs.Remove(thuoc[i]);
                }
                PK.SaveChanges();
            }
            sapxep();
        }

        private void BtnThemThuoc_Click(object sender, RoutedEventArgs e)
        {
            ThemThuoc f = new ThemThuoc();
            this.Close();
            f.Show();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var search = txtSearch.Text;
            if (search == "")
            {
                sapxep();
            }
            else
            {
                List<Thuoc> thuoc = PK.Thuocs.ToList();
                dgv_Pill.Items.Clear();
                for (var i = 0; i < thuoc.Count; i++)
                {
                    if (search == thuoc[i].Tenthuoc)
                    {

                        Item item = new Item();
                        item.TenThuoc = thuoc[i].Tenthuoc;
                        item.SoLuong = thuoc[i].Soluongton;
                        Donvi dv = PK.Donvis.Find(thuoc[i].Madonvi);
                        item.DonVi = dv.TenDonVi;
                        item.GiaBan = thuoc[i].Giathuoc;
                        dgv_Pill.Items.Add(item);

                        dgv_Pill.SelectedItem = null;
                    }

                }

            }

        }

        public void sapxep()
        {
            dgv_Pill.Items.Clear();
            List<Thuoc> thuoc = PK.Thuocs.ToList();

            var sx = thuoc.OrderBy(P => P.Tenthuoc).ToList();
            if (cbbSapXep.Text == "Sắp xếp theo tên thuốc A-Z")
            {
                sx = thuoc.OrderByDescending(P => P.Tenthuoc).ToList();

            }
            else if (cbbSapXep.Text == "Sắp xếp theo tên thuốc Z-A")
            {
                sx = thuoc.OrderBy(P => P.Tenthuoc).ToList();

            }
            else if (cbbSapXep.Text == "Sắp xếp theo giá thuốc bé-lớn")
            {
                sx = thuoc.OrderByDescending(P => P.Giathuoc).ToList();
            }
            else
            {
                sx = thuoc.OrderBy(P => P.Giathuoc).ToList();
            }
            for (var i = 0; i < sx.Count; i++)
            {
                Item item = new Item();
                item.TenThuoc = sx[i].Tenthuoc;
                item.SoLuong = sx[i].Soluongton;
                Donvi dv = PK.Donvis.Find(sx[i].Madonvi);
                item.DonVi = dv.TenDonVi;
                item.GiaBan = sx[i].Giathuoc;
                dgv_Pill.Items.Add(item);
            }


        }


        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            // Hiện thông báo xác nhận
            var dialog = new Dialog() { Message = "Xuất dữ liệu ra tập tin Excel?" };
            dialog.Owner = Window.GetWindow(this);
            if (dialog.ShowDialog() == false) return;

            // Mở hộp thoại lưu tập tin
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx";

            if (false == saveFileDialog.ShowDialog()) return;
            string filename = saveFileDialog.FileName;
            
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Name = "Pills";
            // Ghi các cột
            worksheet.Cells["A1"].PutValue("TÊN THUỐC");
            worksheet.Cells["B1"].PutValue("SỐ LƯỢNG");
            worksheet.Cells["C1"].PutValue("ĐƠN VỊ");
            worksheet.Cells["D1"].PutValue("GIÁ THUỐC");
            int i = 0;
            foreach(Item item in dgv_Pill.Items)
            {
                i++;
                worksheet.Cells[$"A{i + 2}"].PutValue(item.TenThuoc);
                worksheet.Cells[$"B{i + 2}"].PutValue(item.SoLuong.ToString());
                worksheet.Cells[$"C{i + 2}"].PutValue(item.DonVi);
                worksheet.Cells[$"D{i + 2}"].PutValue(item.GiaBan.ToString());

            }
            // Lưu lại
            worksheet.AutoFitColumns();
            workbook.Save(filename);
        }
    }
}
