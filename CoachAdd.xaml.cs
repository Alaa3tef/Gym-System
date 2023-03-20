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
	/// Interaction logic for CoachAdd.xaml
	/// </summary>
	public partial class CoachAdd : Window
	{
		Context context = new Context();
		public delegate void CoachData(object sender, Coach obj);

		public event CoachData coachDataChanged;
		public CoachAdd()
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
			Coach coach = new Coach();
			
			if (textName.Text.All(Char.IsLetter))
			{
                coach.Name = textName.Text;
            }
			else
			{
				errorTextblock.Text= "Enter Alphabitics only";
			}

            if (textPhone.Text.All(Char.IsDigit))
            {
                coach.Phone = textPhone.Text;
            }
            else
            {
                errorTextblock.Text = "Enter Numbers only";
            }
           
			coach.Address = textAdress.Text;
            if (textSalary.Text.Length == 0)
            {
                coach.Salary = 0;
            }
            else
            {
                coach.Salary = int.Parse(textSalary.Text);
            }
            
			if (female.IsChecked == true)
			{
				coach.Gender = female.Content.ToString();
			}
			else if (male.IsChecked == true)
			{
				coach.Gender = male.Content.ToString();
			}

			coach.Time = DateTime.Now;
            if (textSalary.Text.Length == 0)
            {
                coach.Salary = 0;
            }
            else
            {
                coach.Salary = int.Parse(textSalary.Text);
            }

          
            if (textName.Text == "" || textAdress.Text == "" || textPhone.Text == "" ||
				textSalary.Text == "" || (male.IsChecked==false && female.IsChecked==false) )
            {

                flag = false;

            }
            if (flag)
            {
                if (coachDataChanged != null)
                {
                    coachDataChanged(this, coach);

                }
                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }

           

		
			if (textName.Text != "" && textAdress.Text != "" && textPhone.Text != "" && textSalary.Text != "" && (female.IsChecked == true || male.IsChecked == true))
			{
				textSalary.Text = "";
				textPhone.Text = "";
				textName.Text = "";
				textAdress.Text = "";
				female.IsChecked = false;
				male.IsChecked = false;

			}
		}
	}
}
