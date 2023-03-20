using GymSysyemWpf.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace GymSysyemWpf
{
	/// <summary>
	/// Interaction logic for ReciptionistWindow.xaml
	/// </summary>
	public partial class ReciptionistWindow : Window
	{
        private bool mDeletePtnPressed = false;
        private bool mEditPtnPressed = false;

		Context context;

        public ReciptionistWindow()
		{
			InitializeComponent();

            context = new Context();
        }

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == WindowState.Normal)
				this.WindowState = WindowState.Maximized;
			else this.WindowState = WindowState.Normal;
		}


        //Traniee
        private void traniee_Click(object sender, RoutedEventArgs e)
        {
            headerText.Text = "TRAINEES";
            traineeGrid.Visibility = Visibility.Visible;
            coachGrid.Visibility = Visibility.Hidden;
            protienGrid.Visibility = Visibility.Hidden;
            enterData.Visibility = Visibility.Hidden;
            TextTotal.Visibility= Visibility.Hidden;

            TAdd.Visibility = Visibility.Visible;
          
            dataGrideTrainee.DataContext = null;
            var query = context.Trainees.Select(R => R).ToList();
            dataGrideTrainee.DataContext = query;
        }
        private void TrEdit_Click(object sender, RoutedEventArgs e)
        {
            TraineeUpdate TrainUpdate = new TraineeUpdate();
            TrainUpdate.TaineeDataUpdated += TrainUpdate_TaineeDataUpdated;

            mEditPtnPressed = true;
            if (mEditPtnPressed)
            {
                Trainee currentTrainee;
                currentTrainee = dataGrideTrainee.SelectedItem as Trainee;
                TraineeUpdate.currentTrainee = currentTrainee;
                TrainUpdate.Show();
                dataGrideTrainee.SelectedItem = null;
                mEditPtnPressed = false;
                dataGrideTrainee.ItemsSource = null;
                dataGrideTrainee.ItemsSource = context.Trainees.ToList();
            }
        }
        private void TrDelete_Click(object sender, RoutedEventArgs e)
        {
            mDeletePtnPressed = true;

            Trainee item = dataGrideTrainee.SelectedItem as Trainee;
            int Id = int.Parse(item.ID.ToString());
            var query = context.Trainees.FirstOrDefault(p => p.ID == Id);
            context.Trainees.Remove(query);
            context.SaveChanges();
            mDeletePtnPressed = false;
            dataGrideTrainee.ItemsSource = context.Trainees.ToList();
            mDeletePtnPressed = false;
        }
        private void T_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TraineeAdd trainee = new TraineeAdd();
            trainee.traineeDataChanged += Trainee_TraineeDataChanged;
            trainee.Show();
        }
        private void Trainee_TraineeDataChanged(object sender, Trainee obj)
        {
            Trainee trainee = new Trainee();
            trainee = obj;
            trainee.AdminID = 1;
            trainee.ReceptionistID = 1;

            context.Trainees.Add(trainee);
            context.SaveChanges();
            GetTrainee();
            dataGrideTrainee.DataContext = trainee;
        }
        private void GetTrainee()
        {
            dataGrideTrainee.ItemsSource = context.Trainees.ToList();
        }
        private void TrainUpdate_TaineeDataUpdated(object sender, Trainee obj)
        {
            dataGrideTrainee.ItemsSource = null;
            context = new Context();
            var query = context.Trainees.ToList();
            dataGrideTrainee.ItemsSource = query;
        }




        // Coach
        private void coach_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "COACHES";
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Visible;
			protienGrid.Visibility = Visibility.Hidden;
            enterData.Visibility = Visibility.Hidden;
            TextTotal.Visibility = Visibility.Hidden;

            TAdd.Visibility = Visibility.Hidden;


            dataGrideCoach.ItemsSource = null;
            dataGrideCoach.ItemsSource = context.Coaches.ToList();
        }
        private void CoEdit_Click(object sender, RoutedEventArgs e)
        {
            UpdateCoach Popup = new UpdateCoach();
            Popup.coachDataUpdated += Cu_coachDataUpdated;

            mEditPtnPressed = true;
            if (mEditPtnPressed)
            {
                Coach currentCoach;
                currentCoach = dataGrideCoach.SelectedItem as Coach;
                UpdateCoach.currentCoach = currentCoach;
                Popup.Show();
                dataGrideCoach.SelectedItem = null;
                mEditPtnPressed = false;
                dataGrideCoach.ItemsSource = null;
                dataGrideCoach.ItemsSource = context.Coaches.ToList();
            }
        }
        private void CoDelete_Click(object sender, RoutedEventArgs e)
        {
            mDeletePtnPressed = true;

            Coach item = dataGrideCoach.SelectedItem as Coach;
            int Id = int.Parse(item.ID.ToString());
            var query = context.Coaches.FirstOrDefault(p => p.ID == Id);
            context.Coaches.Remove(query);
            context.SaveChanges();
            mDeletePtnPressed = false;
            dataGrideCoach.ItemsSource = context.Coaches.ToList();
            mDeletePtnPressed = false;
        }
        private void Cu_coachDataUpdated(object sender, Coach obj)
        {
            dataGrideCoach.ItemsSource = null;
            context = new Context();
            dataGrideCoach.ItemsSource = context.Coaches.ToList();
        }





        // Protien Product
        private void protien_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "SELLING PROTEIN";
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Hidden;
			protienGrid.Visibility = Visibility.Visible; 
			enterData.Visibility = Visibility.Visible; 
            TextTotal.Visibility = Visibility.Visible;


            TAdd.Visibility = Visibility.Hidden;
			// dataGrideReceptionist.ItemsSource = null;


			//dataGrideProtien.ItemsSource = GymData.protienProducts;

		}
        private void combBoxProtien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int price;
            string num;
            if (combBoxProtien.ItemsSource != null)
            {
                ProtienProduct Pro = (ProtienProduct)combBoxProtien.SelectedItem;
                price = Pro.Price;
                textPrice.Text = price.ToString();
                textQuantaty.IsReadOnly = false;
                if(textQuantaty.Text == "") 
                {
                    textTotalPrice.Text = "";
                }
                else
                {
                    num = textQuantaty.Text;
                    textTotalPrice.Text = (price * int.Parse(num)).ToString();
                }
            }
        }
        private void textQuantaty_TextChanged(object sender, TextChangedEventArgs e)
		{
            if(combBoxProtien.SelectedItem != null)
            {
                int price;
                string num;
                if( textQuantaty.Text != string.Empty )
                {
                    price = int.Parse(textPrice.Text);
                    num = textQuantaty.Text;
                    textTotalPrice.Text = (price * int.Parse(num)).ToString();

                }
                else if(textQuantaty.Text == string.Empty)
                {
                    textTotalPrice.Text=string.Empty;
                }
            }
            
        }
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;

            ProtienProduct pName = combBoxProtien.SelectedItem as ProtienProduct;


            if (textName.Text == "" || textPrice.Text == "" || textQuantaty.Text == "")
            {

                flag = false;

            }
            if (flag)
            {
                errorTextblock.Text = "";
                List<BuyProtien> buyProtien = new List<BuyProtien>{
                new BuyProtien() { Name = textName.Text,
                                    ProtienName = pName.Name,
                                    Quantaty= int.Parse(textQuantaty.Text),
                                    Price = int.Parse(textPrice.Text),
                                    Total= int.Parse(textTotalPrice.Text)},

            };
                dataGrideProtien.Items.Add(buyProtien);
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }



            if (textName.Text != "" && textQuantaty.Text != "" && textPrice.Text != "" && textTotalPrice.Text != "" && combBoxProtien.SelectedIndex >= 0)
            {
                textName.Text = "";
                textQuantaty.Text = "";
                textName.Text = "";
                textPrice.Text = "";
                combBoxProtien.ItemsSource = null;
                combBoxProtien.SelectedValue = "ID";
                combBoxProtien.DisplayMemberPath = "Name";
                combBoxProtien.ItemsSource = context.ProtienProducts.ToList();
            }
        }
        private void Edprotien_Click(object sender, RoutedEventArgs e)
        {
            var data = dataGrideProtien.SelectedItem;

            textName.Text = (dataGrideProtien.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
            combBoxProtien.Text = (dataGrideProtien.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
            textQuantaty.Text = (dataGrideProtien.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
            textPrice.Text = (dataGrideProtien.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
            textTotalPrice.Text = (dataGrideProtien.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;

            dataGrideProtien.Items.Remove(dataGrideProtien.SelectedItem);
        }
        private void Deprotien_click(object sender, RoutedEventArgs e)
        {
            dataGrideProtien.Items.Remove(dataGrideProtien.SelectedItem);
        }
        private void btnCla_Click(object sender, RoutedEventArgs e)
        {
            //int TotalPay = 0;
            //string column = "";
            //for (int i = 0; i < dataGrideProtien.Items.Count; i++)
            //{
            //    column = (dataGrideProtien.Columns[4].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text;

            //    TotalPay += int.Parse(column);
            //}
            //textTotal.Text = TotalPay.ToString();

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BuyProtien buyProtien;
            var data = dataGrideProtien.SelectedItem;
            for (int i = 0; i < dataGrideProtien.Items.Count; i++)
            {
                buyProtien = new BuyProtien();
                buyProtien.Name = (dataGrideProtien.Columns[0].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text;
                buyProtien.ProtienName = (dataGrideProtien.Columns[1].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text;
                buyProtien.Quantaty = int.Parse((dataGrideProtien.Columns[2].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text);
                buyProtien.Price = int.Parse((dataGrideProtien.Columns[3].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text);
                buyProtien.Total = int.Parse((dataGrideProtien.Columns[4].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text);
                buyProtien.AdminID = 1;
                context.Buyprotiens.Add(buyProtien);
                context.SaveChanges();

            }
            dataGrideProtien.Items.Clear();

        }
        private void dataGrideProtien_LayoutUpdated(object sender, EventArgs e)
        {
                int TotalPay = 0;
                string column = "";
                for (int i = 0; i < dataGrideProtien.Items.Count; i++)
                {
                    column = (dataGrideProtien.Columns[4].GetCellContent(dataGrideProtien.Items[i]) as TextBlock).Text;

                    TotalPay += int.Parse(column);
                }
                textTotal.Text = TotalPay.ToString();
        }
        




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            combBoxProtien.SelectedValue = "ID";
            combBoxProtien.DisplayMemberPath = "Name";
            var x = context.ProtienProducts.ToList();
            combBoxProtien.ItemsSource = x;
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


    }
}
