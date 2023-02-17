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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
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

        public void FormLoad()
        {
            Date_NgayLap.Text = Date_NgayLap.DisplayDate.ToString();
            AddDV();
            AddTLB();
            AddThuoc();
            AddTBN();
            refresh();
        }

        private void dgvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void AddTBN()// add item ten benh nhan
        {
            cbb_TenBN.Items.Clear();
            List<BenhNhan> list_BN = PK.BenhNhans.ToList();
            for (int i = 0; i < list_BN.Count; i++)
            {
                cbb_TenBN.Items.Add(list_BN[i].TenBN);
            }          
        }

        public void AddTLB()//add ten loai benh
        {
            cbb_Tenloaibenh.Items.Clear();
            List<Benh> list_TLB = PK.Benhs.ToList();
            foreach (Benh s in list_TLB)
            {
                cbb_Tenloaibenh.Items.Add(s.Tenbenh);
            }
        }
        public void AddThuoc()// add thuoc dieu tri
        {
            List<Thuoc> list_thuoc = PK.Thuocs.ToList();
            cbb_Tenthuoc.ItemsSource = list_thuoc;
            cbb_Tenthuoc.DisplayMemberPath = "Tenthuoc";
            cbb_Tenthuoc.SelectedValuePath = "Mathuoc";
            /*for(int i=0; i<list_thuoc.Count; i++)
            {
                cbb_Tenthuoc.Items.Add(list_thuoc[i].Tenthuoc);
            }*/
        }
        public void AddDV() // add don vi
        {
            cbbDonvi.Items.Clear();
            List<Donvi> list_DV = PK.Donvis.ToList();
            foreach (Donvi s in list_DV)
            {
                cbbDonvi.Items.Add(s.TenDonVi);
            }
        }

        private void DS_PhieuKham_Click(object sender, RoutedEventArgs e)
        {
            Danhsachphieukham f = new Danhsachphieukham();
            this.Close();
            f.ShowDialog();
        }
        public int ktra() // kiem tra ckua nhap
        {
            int i = 0;
            if (cbb_TenBN.Text == "")
            {
                i++;
            }
            if (cbb_Tenloaibenh.Text == "")
            {
                i++;
            }
            if (cbb_Tenthuoc.Text == "")
            {
                i++;
            }
            if (txt_Trieuchung.Text == "")
            {
                i++;
            }
            if (cbbDonvi.Text == "")
            {
                i++;
            }
            if (txt_SL.Text == "0")
            {
                i++;
            }
            return i;
        }
        public string ktraTBN()
        {
            string i = "";
            if (cbb_TenBN.Text == i)
            {
                i = " Chưa nhập tên bệnh nhân ";
            }
            return i;
        }
        public string ktraTLB()
        {
            string i = "";
            if (cbb_Tenloaibenh.Text == i)
            {
                i = " Chưa nhập tên lọai bệnh ";
            }
            return i;
        }
        public string ktraThuoc()
        {
            string i = "";
            if (cbb_Tenthuoc.Text == i)
            {
                i = " Chưa nhập tên thuốc ";
            }
            return i;
        }
        public string ktraTC()
        {
            string i = "";
            if (txt_Trieuchung.Text == i)
            {
                i = " Chưa nhập triệu chứng ";
            }
            return i;
        }
        public string ktraDV()
        {
            string i = "";
            if (cbbDonvi.Text == i)
            {
                i = " Chưa nhập đơn vị ";
            }
            return i;
        }
        public string ktraSL()
        {
            string i = "";
            if (txt_SL.Text == "0")
            {
                i = " Chưa nhập số lượng ";
            }
            return i;
        }
        private void LapPhieu_Click(object sender, RoutedEventArgs e)
        {
            if (ktra() > 0)
            {
                MessageBox.Show(ktraTBN() + "\n" + ktraTLB() + "\n" + ktraThuoc() + "\n" + ktraTC() + "\n" + ktraDV() + "\n" + ktraSL());
            }
            else
            {
                PhieuKham pk = new PhieuKham()
                {
                    MaBN = getMaBN(cbb_TenBN.SelectedItem.ToString()),
                    MaBenh = getMaB(cbb_Tenloaibenh.SelectedItem.ToString()),
                    TrieuChung = txt_Trieuchung.Text,
                    MaPK = MaPKTuTang(),
                    NgayLap = Date_NgayLap.DisplayDate
                };
                PK.PhieuKhams.Add(pk);
                CT_PhieuKham ctpk = new CT_PhieuKham()
                {
                    MaCtpk = MaCTPKTuTang(),
                    MaPK = MaPKTuTang(),
                    Mathuoc = getMaThuoc(),
                    Soluong = Convert.ToInt32(txt_SL.Text),
                    TinhTrang = "Chưa thanh toán"
                };
                PK.CT_PhieuKham.Add(ctpk);
                Thuoc thuoc = PK.Thuocs.Find(ctpk.Thuoc.Mathuoc);
                int soluongton = thuoc.Soluongton - ctpk.Soluong;
                if(soluongton < 0)
                {
                    soluongton = soluongton * -1;
                    MessageBox.Show("Số lượng không vượt quá " + soluongton);
                }
                else
                {
                    PK.SaveChanges();
                    FormLoad();
                    MessageBox.Show(" Lập phiếu thành công -.- ", "Thông báo!");
                }
            }
        }
        public void refresh() // lam moi giao dien
        {
            cbb_TenBN.Text = "";
            cbb_Tenloaibenh.Text = "";
            cbb_Tenthuoc.Text = "";
            txt_Trieuchung.Text = "";
            cbbDonvi.Text = "";
            txt_SL.Text = "";
        }
        public int MaPKTuTang() //MaPK tu tang
        {
            List<PhieuKham> list_pk = PK.PhieuKhams.ToList();
            int maPK;
            int i = list_pk.Count - 1;//lay gia trij cuoi
            if (i == -1)
            {
                maPK = 1;
            }
            else
            {
                maPK = Convert.ToInt32(list_pk[i].MaPK) + 1;//lay gia tri cuoi +1
            }
            return maPK;
        }
        public int MaCTPKTuTang()// ma ctpk tu tang
        {
            List<CT_PhieuKham> list_ctpk = PK.CT_PhieuKham.ToList();
            int maCTPK;
            int i = list_ctpk.Count - 1;
            if (i == -1)
            {
                maCTPK = 1;
            }
            else
            {
                maCTPK = Convert.ToInt32(list_ctpk[i].MaCtpk) + 1;
            }
            return maCTPK;
        }

        public int getMaBN(string tenBN)// lay MaBn tu TenBN
        {

            //BenhNhan bn = PK.BenhNhans.Find(tenBN);
            //int maBN = bn.MaBN;
            //return maBN;
            int maBN = 0;
            List<BenhNhan> list = PK.BenhNhans.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TenBN == tenBN)
                {
                    maBN = Convert.ToInt32(list[i].MaBN);
                }
            }
            return maBN;
        }

        public string getMaB(string tenB)// lay MaB tu TenB
        {

            string maB = "";
            List<Benh> list = PK.Benhs.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                maB = list[i].MaBenh;
            }
            return maB;
        }

        public int getMaThuoc()//Lay Mathuoc tu TenThuoc
        {
            Thuoc thuoc = PK.Thuocs.Find(cbb_Tenthuoc.SelectedValue);
            int mathuoc = thuoc.Mathuoc;
            return mathuoc;
        }



        private void LamMoi_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
        void LoadData()
        {

        }
    }
}
