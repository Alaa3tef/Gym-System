using GymSysyemWpf.Classes;
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

namespace GymSysyemWpf
{
    /// <summary>
    /// Interaction logic for VendorUpdate.xaml
    /// </summary>
    public partial class VendorUpdate : Window
    {
        public static Vendor currentVendor;

        Vendor VendorAfterUpdate = new Vendor();

        public delegate void VendorData(object sender, Vendor prot);

        public event VendorData VendorDataUpdated;

        Context context = new Context();

        public VendorUpdate()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textId.Text = currentVendor.ID.ToString();
            textName.Text = currentVendor.Name;
            txtAddress.Text = currentVendor.Adress;
            txtPhone.Text = currentVendor.Phone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;

            Vendor vendor = new Vendor();
            if (VendorDataUpdated != null)
            {
                var query = context.Vendors.Where(v => v.ID == int.Parse(textId.Text)).ToList();
                foreach (var v in query)
                {
                    v.Name = textName.Text;
                    v.Adress = txtAddress.Text;
                    v.Phone = txtPhone.Text;
                    vendor = v;
                }
               

                if (textName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
                { flag = false; }
            }

            if (flag)
            {
                context.SaveChanges();
                VendorDataUpdated(this, vendor);

                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
        }
    }
}
