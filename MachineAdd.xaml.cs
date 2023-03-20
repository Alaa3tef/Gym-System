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
	/// Interaction logic for MachineAdd.xaml
	/// </summary>
	public partial class MachineAdd : Window
	{
		public delegate void MachienData(object sender, GymMachine obj);
		public event MachienData machienDataChanged;

		public MachineAdd()
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

            GymMachine machien = new GymMachine();
			machien.Name = textName.Text;

            if (textPrice.Text.Length == 0)
            {
                machien.Price = 0;
            }
            else
            {
                machien.Price = int.Parse(textPrice.Text);
            }

            if (textName.Text == "" || textPrice.Text == "")
            {

                flag = false;

            }
            if (flag)
            {
                if (machienDataChanged != null)
                {
                    machienDataChanged(this, machien);

                }
                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }



            

			
			if (textName.Text != "" && textPrice.Text != "")
			{
				textName.Text = "";
				textPrice.Text = "";
			}
		}
	}
}
