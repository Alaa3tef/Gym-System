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
    /// Interaction logic for TraineeUpdate.xaml
    /// </summary>
    public partial class TraineeUpdate : Window
    {
		public static Trainee currentTrainee;

		Trainee TraineeAfterUpdate = new Trainee();

		public delegate void TraineeData(object sender, Trainee obj);
		public event TraineeData TaineeDataUpdated;

		Context context = new Context();

		public TraineeUpdate()
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
		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			bool flag = true;
			Trainee trainee = new Trainee();

			if (TaineeDataUpdated != null)
			{
				var query =
					context.Trainees.Where(t => t.ID == int.Parse(textId.Text)).Select(t => t);

				foreach (var t in query)
				{
					t.Name = textName.Text;
					t.Phone = textPhone.Text;
					t.Address = textAdress.Text;
					t.Age = int.Parse(textAge.Text);
					if (female.IsChecked == true)
					{
						t.Gender = female.Content.ToString();
					}
					else if (male.IsChecked == true)
					{
						t.Gender = male.Content.ToString();
					}
					string subscribe = combBoxTrainee.SelectedItem.ToString();
                    if (combBoxTrainee.SelectedItem != null)
                    {
                        
                        if (subscribe == "Monthly")
                        {
                            t.Subscription = subscribe;
                            t.price = 500;
                        }
                        else if (subscribe == "Session")
                        {
                            t.Subscription = subscribe;
                            t.price = 50;
                        }
                    }
                    t.Subscription = subscribe;
                    if ( textName.Text == "" || textAdress.Text == "" || textPhone.Text == ""
						|| textAge.Text == "" ||( female.IsChecked == false && male.IsChecked==false)  ||
						 combBoxTrainee.SelectedItem==null)
					{
						flag=false;
					}
                }
              
			}
            if (flag)
            {
                context.SaveChanges();
                TaineeDataUpdated(this, trainee); this.Close();
                this.Close();

            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			textId.Text = currentTrainee.ID.ToString();
			textName.Text = currentTrainee.Name;
			textPhone.Text = currentTrainee.Phone;
			textAdress.Text = currentTrainee.Address;
			textAge.Text = currentTrainee.Age.ToString();
			combBoxTrainee.SelectedValue = currentTrainee.Subscription;
			

			if (female.IsChecked == true)
			{
				female.Content = currentTrainee.Gender;
			}
			else if (male.IsChecked == true)
			{
				male.Content = currentTrainee.Gender;
			}
			combBoxTrainee.Items.Add("Monthly");
			combBoxTrainee.Items.Add("Session");

			

			//combBoxCoach.SelectedValue = "ID";
			//combBoxCoach.DisplayMemberPath = "Name";
			//var x = context.Coaches.ToList();
			//combBoxCoach.ItemsSource = x;
		}
	}
}
