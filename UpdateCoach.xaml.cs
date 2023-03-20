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
	/// Interaction logic for UpdateCoach.xaml
	/// </summary>
	public partial class UpdateCoach : Window
	{

		public static Coach currentCoach;

		Coach CoachAfterupdate = new Coach();

		public delegate void CoachData(object sender, Coach obj);

		public event CoachData coachDataUpdated;

		Context context = new Context();
		public UpdateCoach()
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
			textId.Text = currentCoach.ID.ToString();
			textName.Text = currentCoach.Name;
			textPhone.Text = currentCoach.Phone;
			textAdress.Text = currentCoach.Address;
			textSalary.Text = currentCoach.Salary.ToString();

		}


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			bool flag = true;
			Coach coach = new Coach();
			if (coachDataUpdated != null)
			{
				var q = context.Coaches.Where(c => c.ID == int.Parse(textId.Text)).Select(c => c);
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



                    if (female.IsChecked == true)
                    {
                        c.Gender = female.Content.ToString();
                    }
                    else if (male.IsChecked == true)
                    {
                        c.Gender = male.Content.ToString();
                    }
                    coach = c;
				}
                if ( textName.Text == "" || textAdress.Text == "" || textPhone.Text == "" || textSalary.Text == "" || textSalary.Text == "" || (male.IsChecked == false && female.IsChecked == false))
                { flag = false; }

			}
            if (flag)
            {
                context.SaveChanges();
                coachDataUpdated(this, coach);
                this.Close();

            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
        }

	}
}
