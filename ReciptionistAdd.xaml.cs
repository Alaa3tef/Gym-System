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
	/// Interaction logic for ReciptionistAdd.xaml
	/// </summary>
	public partial class ReciptionistAdd : Window
	{
		Context context = new Context();
		public delegate void ReceptionistData(object sender, Receptionist obj);

		public event ReceptionistData receptionDataChanged;
		public ReciptionistAdd()
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
			Receptionist recpt = new Receptionist();
			recpt.Name = textName.Text;
			recpt.Phone = textPhone.Text;
			recpt.Address = textAdress.Text;
			if(textSalary.Text.Length ==0)
			{
				recpt.Salary = 0;
			}
			else
			{
				recpt.Salary= int.Parse(textSalary.Text);
            }
			 
			recpt.Password = textPass.Password;
			if(textName.Text == "" || textAdress.Text == "" || textPhone.Text == "" || textSalary.Text == "" || textPass.Password == "")
			{
				
				flag= false;

            }
			if(flag)
			{
                if (receptionDataChanged != null)
                {
                    receptionDataChanged(this, recpt);
			       

                }
                this.Close();
            }
			else
			{
                errorTextblock.Text = "You must enter all data";
            }

			if (textName.Text != "" && textAdress.Text != "" && textPhone.Text != "" && textSalary.Text != "" && textPass.Password != "")
			{
				textSalary.Text = "";
				textPhone.Text = "";
				textName.Text = "";
				textAdress.Text = "";
				textPass.Password = "";

			}

		}
	}
}
