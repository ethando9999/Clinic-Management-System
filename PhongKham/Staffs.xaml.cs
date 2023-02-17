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
using System.Text.RegularExpressions;

namespace PhongKham
{
    /// <summary>
    /// Interaction logic for Staffs.xaml
    /// </summary>
    public partial class Staffs : Window
    {
        public Staffs()
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
        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow f = new MainWindow();
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

        PhongKhamEntities PK = new PhongKhamEntities();


        #region Xử lý hiệu ứng Comboxbox chức vụ
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbbChucvu_DropDownOpened(object sender, EventArgs e)
        {
            cbbChucvu.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void cbbChucvu_DropDownClosed(object sender, EventArgs e)
        {
            cbbChucvu.Background = Brushes.Transparent;
        }
        #endregion

        #region Xử lý hiệu ứng Comboxbox giới tính
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void cbbNV_gt_DropDownOpened(object sender, EventArgs e)
        {
            cbbNV_gt.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void cbbNV_gt_DropDownClosed(object sender, EventArgs e)
        {
            cbbNV_gt.Background = Brushes.Transparent;
        }
        #endregion

        // add itemssource vào combobox chức vụ
        public void AddItems_CV()
        {
            cbbChucvu.Items.Clear();
            List<LoaiNV> loainv = PK.LoaiNVs.ToList();
            foreach(LoaiNV s in loainv)
            {
                cbbChucvu.Items.Add(s.Tenloai);
            }
        }   

        // add item vào combobox giới tính
        public void addItem_Gioitinh()
        {
            cbbNV_gt.Items.Clear();
            cbbNV_gt.Items.Add("Nam");
            cbbNV_gt.Items.Add("Nữ");
        }

        //Chỉ cho phép nhập số
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        public void FormLoad()
        {
            txt_UserName.Content = UserInfo.UserName;
            AddItems_CV();
            addItem_Gioitinh();
            LamMoi();
            loadDataGrid();
        }
        public void LamMoi()
        {
            txtNV_Id.IsEnabled = true;
            txtNV_Id.Text = "";
            txtNV_Name.Text = "";
            txtNV_MK.Text = "";
            txtNV_Sdt.Text = "";
            cbbNV_gt.Text = "";
            cbbChucvu.Text = "";
            DateNV_ngaysinh.Text = "";
        }
        public int kiemtra()// kiem tra chua nhap
        {
            int i = 0;
            if (txtNV_Id.Text == "")
            {
                i++;
            }

            if (txtNV_Name.Text == "")
            {
                i++;
            }
            if (cbbNV_gt.Text == "")
            {
                i++;
            }
            if (DateNV_ngaysinh.Text == "")
            {
                i++;
            }

            if (txtNV_Sdt.Text == "")
            {
                i++;
            }
            if (txtNV_MK.Text == "")
            {
                i++;
            }
            if (cbbChucvu.Text == "")
            {
                i++;
            }

            return i;
        }
        public string kiemtraMaNV()//
        {
            string i = "";
            if (txtNV_Id.Text == i)
            {
                i = "Chưa nhập mã nhân viên";
            }
            return i;
        }
        public string kiemtraTenNV()//
        {
            string i = "";
            if (txtNV_Name.Text == i)
            {
                i = "Chưa nhập Tên";
            }
            return i;
        }
        public string kiemtraNS()//Xuat ra chua nhap txtSP_loai
        {
            string i = "";
            if (DateNV_ngaysinh.Text == i)
            {
                i = "Chưa nhập Ngày Sinh";
            }
            return i;
        }
        public string kiemtraGT()//Xuat ra chua nhap txtSP_loai
        {
            string i = "";
            if (cbbNV_gt.Text == i)
            {
                i = "Chưa nhập GT";
            }
            return i;
        }
        public string kiemtraSDT()//Xuat ra chua nhap txtSP_loai
        {
            string i = "";
            if (txtNV_Sdt.Text == i)
            {
                i = "Chưa nhập SDT";
            }
            return i;
        }

        public string kiemtraCV()// 
        {
            string i = "";
            if (cbbChucvu.Text == i)
            {
                i = "Chưa nhập chức vụ";
            }
            return i;
        }
        public string kiemtraMK()//Xuat ra chua nhap txtSP_loai
        {
            string i = "";
            if (txtNV_MK.Text == i)
            {
                i = "Chưa nhập MK";
            }
            return i;
        }

        public void loadDataGrid()// load datagirbview
        {
            dgvNhanVien.Items.Clear();
            List<NhanVien> list = PK.NhanViens.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Items data = new Items();
                data.MaNV = list[i].MaNV.ToString();
                data.TenNV = list[i].TenNV;
                data.NgaySinh = list[i].Ngaysinh.ToString("dd/MM/yyyy");
                data.SDT = "0" + list[i].SDT.ToString();
                data.GioiTinh = list[i].Gioitinh;
                data.ChucVu = list[i].LoaiNV.Tenloai;
                data.MatKhau = list[i].Matkhau;
                dgvNhanVien.Items.Add(data);
            }
            dgvNhanVien.SelectedItem = null;
        }


        public string getMaloainv(string chucvu)
        {
            LoaiNV loai = PK.LoaiNVs.FirstOrDefault(x => x.Tenloai == chucvu);
            string maloainv = loai.Maloai_nv;
            return maloainv;
        }


        public int kiemtra_TrungID()// kiem tra trùng id nhan vien 
        {
            int k = 0;
            List<NhanVien> list = PK.NhanViens.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaNV == txtNV_Id.Text)
                {
                    k++;
                }
            }
            return k;
        }
        public int sdt()
        {
            int i = 0;
            List<NhanVien> list = PK.NhanViens.ToList();
            foreach(NhanVien nv in list)
            {
                if(nv.SDT == Int32.Parse(txtNV_Sdt.Text))
                {
                    i++;
                }
            }
            return i;
        }
        public void year18()
        {
            //DateTime tuoi = DateTime.Now - DateTime.Parse(DateNV_ngaysinh.Text);
        }
        public int SSdate()
        {
            int i = 0;
            DateTime ngaysinh = DateTime.Parse(DateNV_ngaysinh.Text);

            if (ngaysinh > DateTime.Now)
            {
                i++;
            }
            return i;
        }
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            if (kiemtra() > 0)
            {
                MessageBox.Show(kiemtraMaNV() + "\n" + kiemtraTenNV() + "\n" + kiemtraNS() + "\n" + kiemtraGT() + "\n" + kiemtraSDT() + "\n" + kiemtraCV() + "\n" + kiemtraMK());

            }
            else
            {
                if (kiemtra_TrungID() > 0)
                {
                    MessageBox.Show("Sorry!Trùng mã nhân viên");
                }
                else if (SSdate() > 0)
                {
                    MessageBox.Show("Ngay sinh phai nho hon ngay hien tai");
                }
                else if (sdt() > 0)
                {
                    MessageBox.Show("Trùng số điện thoại");
                }
                else
                {
                    NhanVien nv = new NhanVien()
                    {
                        MaNV = txtNV_Id.Text,
                        Maloai_nv = getMaloainv(cbbChucvu.Text),
                        TenNV = txtNV_Name.Text,
                        Ngaysinh = DateNV_ngaysinh.DisplayDate,
                        Gioitinh = cbbNV_gt.Text,
                        SDT = Convert.ToInt32(txtNV_Sdt.Text),
                        Matkhau = txtNV_MK.Text
                    };
                    PK.NhanViens.Add(nv);
                    PK.SaveChanges();
                    FormLoad();
                }

            }
        }

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem != null)// Nếu có chọn trên datagrid 
            {
                if (kiemtra() > 0)// nếu để trống 
                {
                    MessageBox.Show(kiemtraMaNV() + "\n" + kiemtraTenNV() + "\n" + kiemtraNS() + "\n" + kiemtraGT() + "\n" + kiemtraSDT() + "\n" + kiemtraCV() + "\n" + kiemtraMK());
                }
                else
                {

                    string nv_id = txtNV_Id.Text;
                    NhanVien nv = PK.NhanViens.Find(nv_id);
                    nv.TenNV = txtNV_Name.Text;
                    nv.Maloai_nv = getMaloainv(cbbChucvu.Text);
                    nv.Gioitinh = cbbNV_gt.Text;
                    nv.Ngaysinh = DateNV_ngaysinh.DisplayDate;
                    nv.SDT = Convert.ToInt32(txtNV_Sdt.Text);
                    nv.Matkhau = txtNV_MK.Text;
                    PK.SaveChanges();
                    MessageBox.Show("Cập nhật thành công");
                    FormLoad();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn trên datagrid!", MessageBoxImage.Error.ToString());
            }
        }
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Xoá nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Items item = (Items)dgvNhanVien.SelectedItem;
                string nv_id = item.MaNV;
                NhanVien nv = PK.NhanViens.Find(nv_id);
                PK.NhanViens.Remove(nv);
                PK.SaveChanges();
                FormLoad();
            }
        }

        //Chọn 1 dòng trên datagrid hiện thị tất cả thông tin 
        private void dgvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvNhanVien.SelectedItem == null)
            {
                return;
            }
            {
                dgvNhanVien.ItemsSource = null;
                Items item = (Items)dgvNhanVien.SelectedItem;
                string nv_id = item.MaNV;
                NhanVien nv = PK.NhanViens.Find(nv_id);
                txtNV_Id.Text = nv.MaNV;
                txtNV_Id.IsEnabled = false;
                txtNV_Name.Text = nv.TenNV;
                cbbChucvu.Text = nv.LoaiNV.Tenloai;
                cbbNV_gt.Text = nv.Gioitinh;
                txtNV_Sdt.Text = nv.SDT.ToString();
                txtNV_MK.Text = nv.Matkhau;
                DateNV_ngaysinh.Text = nv.Ngaysinh.ToString("dd/MM/yyyy");
            }
        }
        public class Items // class dung de them item vao dgvSanPham
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public string GioiTinh { get; set; }
            public string NgaySinh { get; set; }
            public string SDT { get; set; }
            public string ChucVu { get; set; }
            public string MatKhau { get; set; }
        }

    }
}
