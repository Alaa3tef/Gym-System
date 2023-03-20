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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Context context = new Context();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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
			var receptionistData=context.Receptionists.Select(x =>new { x.Name ,x.Password}).ToList();
			foreach (var item in receptionistData)
			{

				if (item.Name == name && item.Password == pass)
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
				ReciptionistWindow reciptionistWindow = new ReciptionistWindow();
				errorTextblock.Text = " ";
				reciptionistWindow.Show();
				this.Close();
			}
			else
			{
				errorTextblock.Text = "Invalid UserName or Password";
			}
		}

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				AdminLogin log = new AdminLogin();
				log.Show();
				this.Hide();
			}
		}

		
	}
}
