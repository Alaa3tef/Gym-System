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
	/// Interaction logic for ProtienAdd.xaml
	/// </summary>
	public partial class ProtienAdd : Window
	{

		public delegate void ProtienData(object sender, ProtienProduct obj);

		public event ProtienData protienhDataChanged;

		public ProtienAdd()
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
            ProtienProduct protien = new ProtienProduct();
			protien.Name = TextName.Text;
			protien.Total=protien.Quantaty * protien.Price;

            if (textQuantaty.Text.Length == 0)
            {
                protien.Quantaty = 0;
            }
            else
            {
                protien.Quantaty = int.Parse(textQuantaty.Text);
            }

            if(textPrice.Text.Length == 0)
            {
                protien.Price = 0;
            }
            else
            {
                protien.Price = int.Parse(textPrice.Text);
            }
            protien.Total = protien.Quantaty * protien.Price;

            if (TextName.Text == "" || textQuantaty.Text == "" || textPrice.Text == "" )
            {

                flag = false;

            }
            if (flag)
            {
                if (protienhDataChanged != null)
                {
                    protienhDataChanged(this, protien);

                }
                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }


            

			if (TextName.Text != "" && textQuantaty.Text != "" && textPrice.Text != "")
			{
				TextName.Text = "";
				textQuantaty.Text = "";
				textPrice.Text = "";
			}
		}
	}
}
