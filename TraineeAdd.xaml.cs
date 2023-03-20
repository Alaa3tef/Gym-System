using GymSysyemWpf.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
	/// Interaction logic for TraineeAdd.xaml
	/// </summary>
	public partial class TraineeAdd : Window
	{
		Context context = new Context();
		

		public delegate void TranieeData(object sender, Trainee obj);

		public event TranieeData traineeDataChanged;
		public TraineeAdd()
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
			Trainee trainee = new Trainee();
			trainee.Name = textName.Text;
			trainee.Phone = textPhone.Text;
			trainee.Address = textAdress.Text;
            if (textAge.Text.Length == 0)
            {
                trainee.Age = 0;
            }
            else
            {
                trainee.Age = int.Parse(textAge.Text);
            }
            
			if (female.IsChecked == true)
			{
				trainee.Gender = female.Content.ToString();
			}
			else if (male.IsChecked == true)
			{
				trainee.Gender = male.Content.ToString();
			}

			if (combBoxTrainee.SelectedItem != null)
			{
				string subscribe = combBoxTrainee.SelectedItem.ToString();
				if (subscribe == "Monthly")
				{
					trainee.Subscription = subscribe;
					trainee.price = 500;
				}
				else if (subscribe == "Session")
				{
					trainee.Subscription = subscribe;
					trainee.price = 50;
				}
			}
            if (textName.Text == "" || textAdress.Text == "" || textPhone.Text == ""
                                   || textAge.Text == "" || (female.IsChecked == false && male.IsChecked == false) ||
                                    combBoxTrainee.SelectedItem == null)
            {

                flag = false;

            }
            if (flag)
            {

                if (traineeDataChanged != null)
                {
                    traineeDataChanged(this, trainee);

                this.Close();
                }
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }

			if (textName.Text != "" && textAdress.Text != "" && textPhone.Text != "" && textAge.Text != "" && (female.IsChecked == true || male.IsChecked == true))
			{
				textAge.Text = "";
				textPhone.Text = "";
				textName.Text = "";
				textAdress.Text = "";
				female.IsChecked = false;
				male.IsChecked = false;

            }
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			combBoxTrainee.Items.Add("Monthly");
			combBoxTrainee.Items.Add("Session");


			//combBoxCoach.SelectedValue = "ID";
			//combBoxCoach.DisplayMemberPath = "Name";
			//var x = context.Coaches.ToList();
			//combBoxCoach.ItemsSource = x;
		}
	}
}
