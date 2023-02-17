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

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {
        public Bill()
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
            Login f = new Login();
            this.Close();
            f.Show();
        }      

        private void DS_HoaDon_Click(object sender, RoutedEventArgs e)
        {
            DS_HoaDon f = new DS_HoaDon();
            this.Close();
            f.Show();
        }

        private void cbb_TenBN_DropDownClosed(object sender, EventArgs e)
        {
            cbb_TenBN.Background = Brushes.Transparent;
        }

        private void cbb_TenBN_DropDownOpened(object sender, EventArgs e)
        {
            cbb_TenBN.Background = Brushes.LightGray;
        }
        public void FormLoad()
        {
            Add_tenBN();
            LamMoi();
            lab_UserName.Content = UserInfo.UserName;
        }

        public void LamMoi()
        {
            Date_NgayTao.Text = Date_NgayTao.DisplayDate.ToString();
            cbb_TenBN.SelectedIndex = -1;
            txt_Tongtien.Text = "0";
            txt_MaHD.Text = "";
            dgv.Items.Clear();
        }

        // Add item vào combobox tên bệnh nhân
        public void Add_tenBN()
        {
            List<BenhNhan> list = PK.BenhNhans.ToList();
            foreach(BenhNhan bn in list)
            {
                cbb_TenBN.Items.Add(bn.TenBN);
            }
        }
        // kiem tra mã hóa đơn để trống?
        public string kiemtraMaHD()
        {
            string ktra = "";
            if (txt_MaHD.Text == ktra)
                ktra = "Chưa nhập mã hóa đơn";
            return ktra;
        }

        // kiem tra chưa chọn tên bệnh nhân
        public string kiemtraTenBN()
        {
            string ktra = "";
            if (txt_Tongtien.Text == "0")
                ktra = "Chưa chọn phiếu thanh toán";
            return ktra;
        }

        public int kiemtra()
        {
            int ketqua = 0;
            string ktra = kiemtraMaHD() + kiemtraTenBN();
            if (ktra != "")
            {
                ketqua++;
            }          
            return ketqua;
        }

        //Kiểm tra trùng mã hóa đơn?
        public int sameMaHD()
        {
            int i = 0;
            List<HOADON> list = PK.HOADONs.ToList();
            foreach(HOADON hd in list)
            {
                if (hd.MaHoaDon == Convert.ToInt32(txt_MaHD.Text))
                {
                    i++;
                }
            }
            return i;
        }

        public int taoMaCTHD()
        {
            List<CTHD> list = PK.CTHDs.ToList();
            int vitri = list.Count - 1; // Vị trí phần tử cuối 
            int end;
            if(vitri >= 0) // Nếu có phần tử nào
            {
                end = list[vitri].MaCTHD; // Giá trị mã cthd phần tử cuối
            }
            else 
            {
                end = 0;
            }
            return end + 1;
        }

        //Lấy tên thuốc từ 
        public void getMathuoc()
        {

        }

        private void ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if(kiemtra() > 0)
            {
                MessageBox.Show(kiemtraTenBN() + "\n" + kiemtraMaHD());
            }
            else if (sameMaHD() > 0)
            {
                MessageBox.Show("Trùng mã hóa đơn");
            }
            else
            {
                HOADON hd = new HOADON()
                {
                    Ngaytao = Date_NgayTao.DisplayDate,
                    MaHoaDon = Convert.ToInt32(txt_MaHD.Text),
                    MaBenhNhan = getMaBN(),
                    TongTien = Convert.ToDouble(txt_Tongtien.Text)
                };
                PK.HOADONs.Add(hd);
                foreach(Items items in dgv.Items)
                {
                    if(items.Check == true)
                    {
                        CT_PhieuKham ctpk = PK.CT_PhieuKham.FirstOrDefault(x => x.MaPK == items.MaPK);
                        ctpk.TinhTrang = "Đã thanh toán";                       
                        CTHD cthd = new CTHD()
                        {
                            MaCTHD = taoMaCTHD(),
                            MaHoaDon = Convert.ToInt32(txt_MaHD.Text),
                            MaThuoc = ctpk.Mathuoc,
                            SoLuong = ctpk.Soluong,
                            ThanhTien = items.ThanhTien
                        };
                        PK.CTHDs.Add(cthd);
                        PK.SaveChanges();
                    }                    
                }
                LamMoi();
                MessageBox.Show("Thanh toán thành công");
                //LamMoi();
            }         
        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*foreach (DataGridRow row in dgv_CTHD.Items)
            {

            }*/
        }

        //Lấy mã bệnh nhân từ combobox bệnh nhân 
        public int getMaBN()
        {
            BenhNhan BN = PK.BenhNhans.FirstOrDefault(x => x.TenBN == cbb_TenBN.SelectedItem.ToString());
            int maBN = BN.MaBN;
            return maBN;
        }

        //Lấy mã phiếu khám từ mã bệnh nhân của getMaBN
        public int getMaPK(int maBN)
        {
            PhieuKham phieu = PK.PhieuKhams.FirstOrDefault(x => x.MaBN == getMaBN());
            int maPK = phieu.MaPK;
            return maPK;
        }

        //Lấy tên thuốc từ mã thuốc
        public string getTenthuoc(int mathuoc)
        {
            Thuoc thuoc = PK.Thuocs.Find(mathuoc);
            string tenthuoc = thuoc.Tenthuoc;
            return tenthuoc;
        }

       /* // Lấy mã đơn vị từ mã thuốc 
        public int getMaDonvi(int mathuoc)
        {
            Thuoc thuoc = PK.Thuocs.Find(mathuoc);
            int madonvi = thuoc.Madonvi;
            return madonvi;
        }

        // Lấy tên đơn vị từ mã thuốc 
        public string getTendonvi(int madonvi)
        {
            Donvi donvi = PK.Donvis.Find(madonvi);
            string tendonvi = donvi.TenDonVi;
            return tendonvi;
        }*/

        // Hiển thị textbox tổng tiền 
        public void tinhTongtien()
        {
            if(dgv.Items == null)
            {
                txt_Tongtien.Text = "0";
            }
            else
            {
                double tongtien = 0;
                foreach (Items items in dgv.Items)
                {
                    if(items.Check == true)
                    {
                        tongtien = tongtien + items.ThanhTien;
                    }
                }
                txt_Tongtien.Text = tongtien.ToString();
            }            
        }

        private void cbb_TenBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbb_TenBN.SelectedIndex == -1)
            {
                return;
            }
            dgv.Items.Clear();
            int khongco = 0; // Biến kiểm tra bệnh nhân k có phiếu khám chưa thanh toán
            List<PhieuKham> list = PK.PhieuKhams.ToList();           
            foreach(PhieuKham phieu in list)
            {
                CT_PhieuKham ctpk = PK.CT_PhieuKham.FirstOrDefault(x => x.MaPK == phieu.MaPK);
                if (phieu.MaBN == getMaBN() && ctpk.TinhTrang == "Chưa thanh toán")
                {
                    Items items = new Items();
                    items.Check = false;
                    items.TenThuoc = getTenthuoc(ctpk.Mathuoc);
                    items.SoLuong = ctpk.Soluong;
                    items.DonGia = ctpk.Thuoc.Giathuoc;
                    items.ThanhTien = Convert.ToDouble(items.SoLuong) * items.DonGia;
                    items.MaPK = ctpk.MaPK;
                    dgv.Items.Add(items);
                }
                else
                {
                    khongco++;
                }
            }
            if(khongco == list.Count)
            {
                txt_Tongtien.Text = "0";
                MessageBox.Show("Không có khoản cần thanh toán");
            }
        }

        public class Items // class dung de them item vao dgv
        {           
            public  bool  Check { get; set; }
            public string TenThuoc { get; set; }
            public int SoLuong { get; set; }
            public double DonGia { get; set; }
            public double ThanhTien { get; set; }
            public int MaPK { get; set; }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tinhTongtien();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tinhTongtien();
        }
    }
}
