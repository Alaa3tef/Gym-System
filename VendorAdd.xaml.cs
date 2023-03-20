using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Interaction logic for VendorAdd.xaml
    /// </summary>
    public partial class VendorAdd : Window
    {
        public delegate void VendorData(object sender, Vendor obj);

        public event VendorData vendorDataChanged;
        public VendorAdd()
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;

            Vendor vendor = new Vendor();
            vendor.Name = TextName.Text;
            vendor.Adress = textAddress.Text;
            vendor.Phone = textPhone.Text;

            if (TextName.Text == "" || textAddress.Text == "" || textPhone.Text == "")
            {

                flag = false;

            }
            if (flag)
            {
                if (vendorDataChanged != null)
                {
                    vendorDataChanged(this, vendor);

                }
                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }


            if (TextName.Text != "" && textAddress.Text != "" && textPhone.Text != "")
            {
                TextName.Text = "";
                textAddress.Text = "";
                textPhone.Text = "";
            }
        }
    }
}
