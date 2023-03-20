using GymSysyemWpf.Classes;
using Microsoft.Win32;
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
	/// Interaction logic for AdminLogin.xaml
	/// </summary>
	public partial class AdminLogin : Window
	{
		Context context=new Context();
		public AdminLogin()
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
			Application.Current.Shutdown();
		}
		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			string name = textUser.Text;
			string pass = textPass.Password;
			bool flag = true;


			var adminData = context.Admins.Select(x => new { x.UserName, x.Password }).ToList();
			foreach (var item in adminData)
			{

				if (item.UserName == name && item.Password == pass)
				{
					flag = true;
					break;
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				AdminWindow admin= new AdminWindow();
				errorTextblock.Text = " ";
				admin.Show();
				this.Close();
			}
			else
			{
				errorTextblock.Text = "Invalid UserName or Password";
			}
		}



		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MainWindow main = new MainWindow();
			main.Show();
			this.Close();
		}

		
	}
}
