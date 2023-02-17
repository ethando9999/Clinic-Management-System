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
    /// Interaction logic for Danhsachphieukham.xaml
    /// </summary>
    public partial class Danhsachphieukham : Window
    {
        public Danhsachphieukham()
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

        #region Xử lý hiệu ứng Comboxbox
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbb_Tinhtrang_DropDownOpened(object sender, EventArgs e)
        {
            cbb_Tinhtrang.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void cbb_Tinhtrang_DropDownClosed(object sender, EventArgs e)
        {
            cbb_Tinhtrang.Background = Brushes.Transparent;
        }
        #endregion
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

        private void TroVe_Click(object sender, RoutedEventArgs e)
        {
            Registration f = new Registration();
            this.Close();
            f.ShowDialog();
        }
        public void FormLoad()
        {
            cbb_Tinhtrang.Text = "Tất cả";
            LoadDatagrid();
            Add_cbb_Tinhtrang();
        }


        public class Item
        {
            public string NgayLap { get; set; }
            public int MaPK { get; set; }
            public string TenBN { get; set; }
            public string TenThuoc { get; set; }
            public string TinhTrang { get; set; }
        }
        private void dgvPhongKham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv_DSPhieuKham.SelectedItem == null)
            {
                return;
            }
            else
            {
                Item item = (Item)dgv_DSPhieuKham.SelectedItem;
                int maPK = item.MaPK;
                List<CT_PhieuKham> list = PK.CT_PhieuKham.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].MaPK == maPK)
                    {
                        txt_Soluong.Text = list[i].Soluong.ToString();
                        int madonvi = getMaDonvi(list[i].Thuoc.Mathuoc);
                        string tendonvi = getTenDonvi(madonvi);
                        txt_Donvi.Text = tendonvi;

                    }
                }
                List<PhieuKham> list_pk = PK.PhieuKhams.ToList();
                for (int i = 0; i < list_pk.Count; i++)
                {
                    if (list_pk[i].MaPK == maPK)
                    {
                        txt_Tenbenh.Text = list_pk[i].Benh.Tenbenh;
                        txt_Trieuchung.Text = list_pk[i].TrieuChung;
                    }
                }
            }
        }
        public string getTenDonvi(int madonvi)// Lấy tên đơn vị từ mã đơn vị
        {
            Donvi dv = PK.Donvis.Find(madonvi);
            string tendonvi = dv.TenDonVi;
            return tendonvi;
        }

        public int getMaDonvi(int mathuoc)//Lấy mã đơn vị từ mã thuốc
        {
            Thuoc thuoc = PK.Thuocs.Find(mathuoc);
            int madonvi = thuoc.Madonvi;
            return madonvi;
        }
        //public void addItemDatagrid(HOADON hd)
        //{
        //    Items item = new Items()
        //    {
        //        MaHD = hd.MaHoaDon,
        //        TenBN = getTenBN(hd.MaBenhNhan),
        //        NgayTao = hd.Ngaytao.ToString("dd/MM/yyyy"),
        //        TongTien = hd.TongTien
        //    };
        //    dgv_DSHD.Items.Add(item);
        //}
        public void addItemDatagird(PhieuKham pk)
        {
            Item data = new Item();
            data.NgayLap = pk.NgayLap.ToString("dd/MM/yyyy");
            data.MaPK = pk.MaPK;
            data.TenBN = pk.BenhNhan.TenBN;
            CT_PhieuKham CT = PK.CT_PhieuKham.FirstOrDefault(x => x.MaPK == pk.MaPK);
            data.TenThuoc = CT.Thuoc.Tenthuoc;
            data.TinhTrang = CT.TinhTrang;
            dgv_DSPhieuKham.Items.Add(data);
        }

        public void LoadDatagrid()
        {
            dgv_DSPhieuKham.Items.Clear();
            List<PhieuKham> list_PK = PK.PhieuKhams.ToList();
            //for (int i = 0; i < list_PK.Count; i++)
            foreach (PhieuKham pk in list_PK)
            {
                addItemDatagird(pk);
            }
            dgv_DSPhieuKham.SelectedItem = null;
        }
        private void cbb_Tinhtrang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgv_DSPhieuKham.Items.Clear();
            List<PhieuKham> list = PK.PhieuKhams.ToList();
            if (cbb_Tinhtrang.SelectedIndex == 0)
            {
                LoadDatagrid();
            }
            else if (cbb_Tinhtrang.SelectedIndex == 1)
            {
                foreach (PhieuKham pk in list)
                {
                    CT_PhieuKham CT = PK.CT_PhieuKham.FirstOrDefault(x => x.MaPK == pk.MaPK);

                    if (CT.TinhTrang == "Đã thanh toán")
                    {
                        addItemDatagird(pk);
                    }
                }
            }
            else if (cbb_Tinhtrang.SelectedIndex == 2)
            {
                foreach (PhieuKham pk in list)
                {
                    CT_PhieuKham CT = PK.CT_PhieuKham.FirstOrDefault(x => x.MaPK == pk.MaPK);

                    if (CT.TinhTrang == "Chưa thanh toán")
                    {
                        addItemDatagird(pk);
                    }
                }
            }
            dgv_DSPhieuKham.SelectedItem = null;
        }
        private void HuyPhieu_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Item item = (Item)dgv_DSPhieuKham.SelectedItem;
                PhieuKham pk = PK.PhieuKhams.Find(item.MaPK);
                List<CT_PhieuKham> list = PK.CT_PhieuKham.ToList();
                foreach (CT_PhieuKham s in list)
                {
                    if (s.MaPK == pk.MaPK)
                    {
                        PK.CT_PhieuKham.Remove(s);
                    }
                }
                PK.PhieuKhams.Remove(pk);
                PK.SaveChanges();
                FormLoad();
            }
        }
        public void Add_cbb_Tinhtrang()
        {
            cbb_Tinhtrang.ItemsSource = new string[] { "Tất cả phiếu",
                                                       "Phiếu đã thanh toán",
                                                       "Phiếu chưa thanh toán" };
            cbb_Tinhtrang.SelectedIndex = 0;
        }



    }
}


