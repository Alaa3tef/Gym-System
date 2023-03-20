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
	/// Interaction logic for receptionistUpdated.xaml
	/// </summary>
	public partial class receptionistUpdated : Window
	{

		public static Receptionist currentReciptionist;

		Receptionist receptionist = new Receptionist();

		public delegate void receptionistData(object sender, Receptionist obj);

		public event receptionistData recephDataUpdated;

		Context context = new Context();
		public receptionistUpdated()
		{
			InitializeComponent();
			//btnUpdate.IsEnabled = false;
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			textId.Text = currentReciptionist.ID.ToString();
			textName.Text = currentReciptionist.Name;
			textPhone.Text = currentReciptionist.Phone;
			textAdress.Text = currentReciptionist.Address;
			textSalary.Text = currentReciptionist.Salary.ToString();
			textPassword.Text = currentReciptionist.Password;
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			bool flag = true;
			Receptionist receptionist = new Receptionist();
			if (recephDataUpdated != null)
			{
				var q = context.Receptionists.Where(c => c.ID == int.Parse(textId.Text)).Select(c => c);
				foreach (var c in q)
				{
					c.Name = textName.Text;
					c.Address = textAdress.Text;
					c.Phone = textPhone.Text;
                    if (textSalary.Text.Length == 0)
                    {
                        c.Salary = 0;
                    }
                    else
                    {
                        c.Salary = int.Parse(textSalary.Text);
                    }
                    receptionist = c;
				}
				if(textPassword.Text== "" ||textName.Text=="" || textAdress.Text=="" || textPhone.Text=="" || textSalary.Text=="" )
				{ flag = false; }
				
			}
			if(flag)
			{
                context.SaveChanges();
                recephDataUpdated(this, receptionist);
                this.Close();

            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
            
		}

   //     private void textId_TextChanged(object sender, TextChangedEventArgs e)
   //     {
			
   //     }

   //     private void textName_TextChanged(object sender, TextChangedEventArgs e)
   //     {
			//if(textName.Text.Length> 0 && textPhone.Text.Length>0 && textSalary.Text.Length>0 && textAdress.Text.Length>0 &&textPassword.Text.Length>0) {
   //             btnUpdate.IsEnabled = true;
			//}
   //     }

   //     private void textPhone_TextChanged(object sender, TextChangedEventArgs e)
   //     {
   //         if (textName.Text.Length > 0 && textPhone.Text.Length > 0 && textSalary.Text.Length > 0 && textAdress.Text.Length > 0 && textPassword.Text.Length > 0)
   //         {
   //             btnUpdate.IsEnabled = true;
   //         }
   //     }

   //     private void textAdress_TextChanged(object sender, TextChangedEventArgs e)
   //     {
   //         if (textName.Text.Length > 0 && textPhone.Text.Length > 0 && textSalary.Text.Length > 0 && textAdress.Text.Length > 0 && textPassword.Text.Length > 0)
   //         {
   //             btnUpdate.IsEnabled = true;
   //         }
   //     }

   //     private void textSalary_TextChanged(object sender, TextChangedEventArgs e)
   //     {
   //         if (textName.Text.Length > 0 && textPhone.Text.Length > 0 && textSalary.Text.Length > 0 && textAdress.Text.Length > 0 && textPassword.Text.Length > 0)
   //         {
   //             btnUpdate.IsEnabled = true;
   //         }
   //     }

   //     private void textPassword_TextChanged(object sender, TextChangedEventArgs e)
   //     {
   //         if (textName.Text.Length > 0 && textPhone.Text.Length > 0 && textSalary.Text.Length > 0 && textAdress.Text.Length > 0 && textPassword.Text.Length > 0)
   //         {
   //             btnUpdate.IsEnabled = true;
   //         }
   //     }
    }
}
