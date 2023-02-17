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
    /// Interaction logic for DS_HoaDon.xaml
    /// </summary>
    public partial class DS_HoaDon : Window
    {
        public DS_HoaDon()
        {
            InitializeComponent();
            FormLoad();
        }

        PhongKhamEntities PK = new PhongKhamEntities();

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

        private void SignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void dgv_DSHD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CTHD_Click(object sender, RoutedEventArgs e)
        {
            if (dgv_DSHD.SelectedItem == null)
            {
                MessageBox.Show("Chọn 1 dòng trên datagrid rồi tiếp tục!");
            }
            else
            {
                Items items = (Items)dgv_DSHD.SelectedItem;
                HoadonInfo.MaHD = items.MaHD;
                ChiTietHoaDon f = new ChiTietHoaDon();
                this.Close();
                f.ShowDialog();
            }
        }

        private void TroVe_Click(object sender, RoutedEventArgs e)
        {
            Bill f = new Bill();
            this.Close();
            f.ShowDialog();
        }

        public void FormLoad()
        {
            loadDatagrid();
        }

        //Lấy tên bệnh nhân từ mã bệnh nhân
        public string getTenBN(int maBN)
        {
            BenhNhan bn = PK.BenhNhans.Find(maBN);
            string tenBN = bn.TenBN;
            return tenBN;
        }

        // Add item vao datagrid
        public void addItemDatagrid(HOADON hd)
        {
            Items item = new Items()
            {
                MaHD = hd.MaHoaDon,
                TenBN = getTenBN(hd.MaBenhNhan),
                NgayTao = hd.Ngaytao.ToString("dd/MM/yyyy"),
                TongTien = hd.TongTien
            };
            dgv_DSHD.Items.Add(item);
        }



        public void loadDatagrid()
        {
            dgv_DSHD.Items.Clear();
            List<HOADON> list = PK.HOADONs.ToList();
            foreach(HOADON hd in list)
            {
                addItemDatagrid(hd);
            }
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Xoá nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (dgv_DSHD.SelectedItem == null)
                {
                    MessageBox.Show("Chọn 1 dòng trên datagrid rồi tiếp tục!");
                }
                else
                {
                    Items items = (Items)dgv_DSHD.SelectedItem;
                    HOADON hd = PK.HOADONs.Find(items.MaHD);
                    List < CTHD > list = PK.CTHDs.ToList();
                    foreach(CTHD cthd in list)
                    {
                        if(cthd.MaHoaDon == hd.MaHoaDon)
                        {
                            PK.CTHDs.Remove(cthd);
                        }
                    }
                    PK.HOADONs.Remove(hd);
                    PK.SaveChanges();
                    FormLoad();
                }
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgv_DSHD.Items.Clear();
            List<HOADON> list = PK.HOADONs.ToList();
            foreach (HOADON hd in list)
            {
                if(Date_NgayTao.DisplayDate == hd.Ngaytao)
                {
                    addItemDatagrid(hd);
                }
            }
        }

        public class Items // class dung de them item vao dgv
        {
            public int MaHD { get; set; }
            public string NgayTao { get; set; }
            public string TenBN { get; set; }
            public double TongTien { get; set; }
        }
    }
}
