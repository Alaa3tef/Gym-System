using GymSysyemWpf.Classes;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection.PortableExecutable;

namespace GymSysyemWpf
{
	/// <summary>
	/// Interaction logic for AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		Context context;

        public AdminWindow()
		{
			InitializeComponent();
            context= new Context();

        }
        static public SeriesCollection SeriesCollection { get; set; }

        private bool mDeletePtnPressed = false;
		private bool mEditPtnPressed = false;


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
		private void btnMaximize_Click(object sender, RoutedEventArgs e)
		{
			borderBudget.Width = 850;
			borderIncome.Width = 850;

            Thickness margin = biChart.Margin;
            margin.Left = 60;
            biChart.Margin = margin;


            if (this.WindowState == WindowState.Normal)
				this.WindowState = WindowState.Maximized;
			else
			{
				this.WindowState = WindowState.Normal;

                if (WindowState == WindowState.Normal)
                {
                    borderBudget.Width = 780;
                    borderIncome.Width = 780;

                    margin.Left = 20;
                    biChart.Margin = margin;
                }
            }
				
				
		}



        //Reciptionist 
        private void receptionist_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "RECEPTIONISTS";
			receptionistGrid.Visibility = Visibility.Visible;
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Hidden;
			protienGrid.Visibility = Visibility.Hidden;
			machineGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
			financialGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;

            RAdd.Visibility = Visibility.Visible;
			TAdd.Visibility = Visibility.Hidden;
			CAdd.Visibility = Visibility.Hidden;
			PAdd.Visibility = Visibility.Hidden;
			MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;
			//dataGrideReceptionist.ItemsSource = null;

			dataGrideReceptionist.ItemsSource = null;
			var query = context.Receptionists.Select(R => R).ToList();
			dataGrideReceptionist.ItemsSource = query;


		}
		private void RecEdit_Click(object sender, RoutedEventArgs e)
		{
            receptionistUpdated receptionistUpdated = new receptionistUpdated();

            receptionistUpdated.recephDataUpdated += Receptionistupdated_receptionistupdate;

            mEditPtnPressed = true;
			if (mEditPtnPressed)
			{
				Receptionist currentReceptionist;
				currentReceptionist = dataGrideReceptionist.SelectedItem as Receptionist;
				receptionistUpdated.currentReciptionist = currentReceptionist;
				receptionistUpdated.Show();

				dataGrideReceptionist.SelectedItem = null;
				mEditPtnPressed = false;

				dataGrideReceptionist.ItemsSource = null;
				dataGrideReceptionist.ItemsSource = context.Receptionists.ToList();
			}
		}
		private void Rec_Delete_Click(object sender, RoutedEventArgs e)
		{
			mDeletePtnPressed = true;

			Receptionist item = dataGrideReceptionist.SelectedItem as Receptionist;
			int Id = int.Parse(item.ID.ToString());
			var query = context.Receptionists.FirstOrDefault(p => p.ID == Id);
			context.Receptionists.Remove(query);
			context.SaveChanges();
			mDeletePtnPressed = false;
			dataGrideReceptionist.ItemsSource = context.Receptionists.ToList();
			mDeletePtnPressed = false;

		}
		private void R_MouseDown(object sender, MouseButtonEventArgs e)
		{
            ReciptionistAdd reciption = new ReciptionistAdd();
            reciption.receptionDataChanged += Reciption_receptionDataChanged;
            reciption.Show();
		}
		private void Reciption_receptionDataChanged(object sender, Receptionist obj)
		{
			Receptionist rec = new Receptionist();
			rec = obj;
			rec.AdminID = 1;

			context.Receptionists.Add(rec);
			context.SaveChanges();
			GetReceptionists();
			dataGrideReceptionist.DataContext = rec;
		}
		private void GetReceptionists()
		{
			dataGrideReceptionist.ItemsSource = context.Receptionists.ToList();

		}
		private void Receptionistupdated_receptionistupdate(object sender, Receptionist e)
		{
			dataGrideReceptionist.ItemsSource = null;
            context = new Context();
            var query = context.Receptionists.Select(R => R).ToList();
			dataGrideReceptionist.ItemsSource = query;
		}




		//Trainee
		private void traniee_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "TRAINEES";
			receptionistGrid.Visibility = Visibility.Hidden;
			traineeGrid.Visibility = Visibility.Visible;
			coachGrid.Visibility = Visibility.Hidden;
			protienGrid.Visibility = Visibility.Hidden;
			machineGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
			financialGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;


            RAdd.Visibility = Visibility.Hidden;
			TAdd.Visibility = Visibility.Visible;
			CAdd.Visibility = Visibility.Hidden;
			PAdd.Visibility = Visibility.Hidden;
			MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;

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
			GetTrainee(trainee);
			dataGrideTrainee.DataContext = trainee;
		}
		private void GetTrainee(Trainee trainee)
		{
			dataGrideTrainee.ItemsSource = context.Trainees.ToList();
        }
        private void TrainUpdate_TaineeDataUpdated(object sender, Trainee obj)
		{
			dataGrideTrainee.DataContext = null;
            context = new Context();
            var query = context.Trainees.ToList();
			dataGrideTrainee.ItemsSource = query;
		}

		


		//Coach
		private void coach_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "COACHES";
			receptionistGrid.Visibility = Visibility.Hidden;
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Visible;
			protienGrid.Visibility = Visibility.Hidden;
			machineGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
			financialGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;



            RAdd.Visibility = Visibility.Hidden;
			TAdd.Visibility = Visibility.Hidden;
			CAdd.Visibility = Visibility.Visible;
			PAdd.Visibility = Visibility.Hidden;
			MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;


			dataGrideCoach.DataContext = null;
			var query = context.Coaches.Select(R => R).ToList();
			dataGrideCoach.ItemsSource = query;
		}
		private void CEdit_Click(object sender, RoutedEventArgs e)
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
				//currentProtien = null;
				mEditPtnPressed = false;
				dataGrideCoach.ItemsSource = null;
				dataGrideCoach.ItemsSource = context.Coaches.ToList();
			}
		}
		private void CDelete_Click(object sender, RoutedEventArgs e)
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
		private void CAdd_MouseDown(object sender, MouseButtonEventArgs e)
		{
            CoachAdd co = new CoachAdd();
            co.coachDataChanged += Co_coachDataChanged;
            co.Show();
		}
		private void Co_coachDataChanged(object sender, Coach obj)
		{
			Coach co = new Coach();
			co = obj;
			co.AdminID = 1;
			co.ReceptionistID=1;

			context.Coaches.Add(co);
			context.SaveChanges();
			GetCoaches();
			dataGrideCoach.DataContext = co;
		}
		private void GetCoaches()
		{
			dataGrideCoach.ItemsSource = context.Coaches.ToList();
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
			headerText.Text = "PROTIEN PRODUCTS";
			receptionistGrid.Visibility = Visibility.Hidden;
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Hidden;
			protienGrid.Visibility = Visibility.Visible;
			machineGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
			financialGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;



            RAdd.Visibility = Visibility.Hidden;
			TAdd.Visibility = Visibility.Hidden;
			CAdd.Visibility = Visibility.Hidden;
			PAdd.Visibility = Visibility.Visible;
			MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;
			
			var query = context.ProtienProducts.Select(R => R).ToList();
			dataGrideProtien.DataContext = query;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
            ProtienUpdate prot = new ProtienUpdate();
            prot.ProtienDataUpdated += Prot_ProtienDataUpdated;

            mEditPtnPressed = true;
			if (mEditPtnPressed)
			{
				ProtienProduct currentProtien;
				currentProtien = dataGrideProtien.SelectedItem as ProtienProduct;
				ProtienUpdate.currentProtien = currentProtien;
				prot.Show();
				dataGrideProtien.SelectedItem = null;
				//currentProtien = null;
				mEditPtnPressed = false;
				dataGrideProtien.ItemsSource = null;
				dataGrideProtien.ItemsSource= context.ProtienProducts.ToList();	
			}
		
		}
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			mDeletePtnPressed = true;
			
			ProtienProduct item = dataGrideProtien.SelectedItem as ProtienProduct;
			int Id = int.Parse(item.ID.ToString());
			var query = context.ProtienProducts.FirstOrDefault(p => p.ID == Id);
			context.ProtienProducts.Remove(query);
			context.SaveChanges();
			mDeletePtnPressed = false;
			dataGrideProtien.ItemsSource = context.ProtienProducts.ToList();
			mDeletePtnPressed = false;
		}	
		private void P_MouseDown(object sender, MouseButtonEventArgs e)
		{
            ProtienAdd pr = new ProtienAdd();
            pr.protienhDataChanged += pr_protienDataChanged;

            pr.Show();
		}
		private void pr_protienDataChanged(object sender, ProtienProduct obj)
		{
			ProtienProduct pro = new ProtienProduct();
			pro = obj;
			pro.AdminID = 1;
			pro.ReceptionistID = 1;
			
			context.ProtienProducts.Add(pro);
			context.SaveChanges();

			GetProtien();
			dataGrideProtien.DataContext = pro;
		}
		private void GetProtien()
		{
			dataGrideProtien.ItemsSource = context.ProtienProducts.ToList();

		}
		private void Prot_ProtienDataUpdated(object sender, ProtienProduct prot)
		{
			dataGrideProtien.ItemsSource = null;
            context = new Context();
            dataGrideProtien.ItemsSource= context.ProtienProducts.ToList();

        }



		//Machine
		private void machiene_Click(object sender, RoutedEventArgs e)
		{
			headerText.Text = "MACHINES";
			receptionistGrid.Visibility = Visibility.Hidden;
			traineeGrid.Visibility = Visibility.Hidden;
			coachGrid.Visibility = Visibility.Hidden;
			protienGrid.Visibility = Visibility.Hidden;
			machineGrid.Visibility = Visibility.Visible;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
			financialGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;



            RAdd.Visibility = Visibility.Hidden;
			TAdd.Visibility = Visibility.Hidden;
			CAdd.Visibility = Visibility.Hidden;
			PAdd.Visibility = Visibility.Hidden;
			MAdd.Visibility = Visibility.Visible;
            VAdd.Visibility = Visibility.Hidden;

			var query = context.GymMachines.Select(R => R).ToList();
			dataGrideMachien.DataContext = query;
		}
		private void MaEdit_Click(object sender, RoutedEventArgs e)
		{
            machineUpdated machineUpdated = new machineUpdated();
            machineUpdated.machineDataUpdated += MachineUpdated_machineDataUpdated;
            mEditPtnPressed = true;
			if (mEditPtnPressed)
			{
				GymMachine currentMachine;
				currentMachine = dataGrideMachien.SelectedItem as GymMachine;
				machineUpdated.currentMachine = currentMachine;
				machineUpdated.Show();

				dataGrideMachien.SelectedItem = null;
				mEditPtnPressed = false;

				dataGrideMachien.ItemsSource = null;
				dataGrideMachien.ItemsSource = context.GymMachines.ToList();
			}
		}
		private void MaDelete_Click(object sender, RoutedEventArgs e)
		{
			mDeletePtnPressed = true;

			GymMachine item = dataGrideMachien.SelectedItem as GymMachine;
			int Id = int.Parse(item.ID.ToString());
			var query = context.GymMachines.FirstOrDefault(p => p.ID == Id);
			context.GymMachines.Remove(query);
			context.SaveChanges();
			mDeletePtnPressed = false;
			dataGrideMachien.ItemsSource = context.GymMachines.ToList();
			mDeletePtnPressed = false;
		}
		private void M_MouseDowen(object sender, MouseButtonEventArgs e)
		{
            MachineAdd machineAdd = new MachineAdd();
            machineAdd.machienDataChanged += MachineAdd_machienDataChanged;
            machineAdd.Show();
		}
		private void MachineAdd_machienDataChanged(object sender, GymMachine obj)
		{
			GymMachine machine = new GymMachine();
			machine = obj;
			machine.AdminID = 1;

			context.GymMachines.Add(machine);
			context.SaveChanges();

			GetMachien();
			dataGrideMachien.DataContext = machine;
		}
		private void GetMachien()
		{
			dataGrideMachien.ItemsSource = context.GymMachines.ToList();

		}
		private void MachineUpdated_machineDataUpdated(object sender, GymMachine obj)
		{
			dataGrideMachien.ItemsSource = null;
			context = new Context();
			var query = context.GymMachines.ToList();
			dataGrideMachien.ItemsSource = query;
		}


        //Vendors
        private void Vendor_Click(object sender, RoutedEventArgs e)
        {
            headerText.Text = "Vendors";
            receptionistGrid.Visibility = Visibility.Hidden;
            traineeGrid.Visibility = Visibility.Hidden;
            coachGrid.Visibility = Visibility.Hidden;
            protienGrid.Visibility = Visibility.Hidden;
            machineGrid.Visibility = Visibility.Hidden;
            financialGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Visible;
            BuyprotienGrid.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Hidden;



            VAdd.Visibility = Visibility.Visible;
            RAdd.Visibility = Visibility.Hidden;
            TAdd.Visibility = Visibility.Hidden;
            CAdd.Visibility = Visibility.Hidden;
            PAdd.Visibility = Visibility.Hidden;
            MAdd.Visibility = Visibility.Hidden;
            financialIncome.Visibility = Visibility.Hidden;

            // dataGrideReceptionist.ItemsSource = null;


            var query = context.Vendors.ToList();
            dataGrideVendor.DataContext = query;
        }
        private void updateVendor_Click(object sender, RoutedEventArgs e)
        {
            VendorUpdate vendor = new VendorUpdate();
            vendor.VendorDataUpdated += Vendor_VendorDataUpdated;

            mEditPtnPressed = true;
            if (mEditPtnPressed)
            {
                Vendor currentVendor;
                currentVendor = dataGrideVendor.SelectedItem as Vendor;
                VendorUpdate.currentVendor = currentVendor;
                vendor.Show();
                dataGrideVendor.SelectedItem = null;
                //currentProtien = null;
                mEditPtnPressed = false;
                dataGrideVendor.ItemsSource = null;
                dataGrideVendor.ItemsSource = context.Vendors.ToList();
            }
        }
        private void Vendor_VendorDataUpdated(object sender, Vendor prot)
        {
            dataGrideVendor.ItemsSource = null;
            context = new Context();
            dataGrideVendor.ItemsSource = context.Vendors.ToList();
        }
        private void vendorDelete_Click(object sender, RoutedEventArgs e)
        {
            mDeletePtnPressed = true;

            Vendor item = dataGrideVendor.SelectedItem as Vendor;
            int Id = int.Parse(item.ID.ToString());
            var query = context.Vendors.FirstOrDefault(p => p.ID == Id);
            context.Vendors.Remove(query);
            context.SaveChanges();
            mDeletePtnPressed = false;
            dataGrideVendor.ItemsSource = context.Vendors.ToList();
            mDeletePtnPressed = false;
        }
        private void V_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VendorAdd vendor = new VendorAdd();
            vendor.vendorDataChanged += V_VendorDataChanged;

            vendor.Show();
        }
        private void V_VendorDataChanged(object sender, Vendor obj)
        {
            Vendor vendor = new Vendor();
            vendor = obj;
            vendor.AdminID = 1;

            context.Vendors.Add(vendor);
            context.SaveChanges();

            GetVendor();
            dataGrideProtien.DataContext = vendor;
        }
        private void GetVendor()
        {
            dataGrideVendor.ItemsSource = context.Vendors.ToList();

        }


        // Selling Protein 
        private void BUYProtein_Click(object sender, RoutedEventArgs e)
        {
            headerText.Text = "Selling Protein";
            receptionistGrid.Visibility = Visibility.Hidden;
            traineeGrid.Visibility = Visibility.Hidden;
            coachGrid.Visibility = Visibility.Hidden;
            protienGrid.Visibility = Visibility.Hidden;
            machineGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Visible;
            financialGrid.Visibility = Visibility.Hidden;
            texttotal.Visibility = Visibility.Visible;
            financialIncome.Visibility = Visibility.Hidden;


            RAdd.Visibility = Visibility.Hidden;
            TAdd.Visibility = Visibility.Hidden;
            CAdd.Visibility = Visibility.Hidden;
            PAdd.Visibility = Visibility.Hidden;
            MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;

			var sellProtien = context.Buyprotiens.ToList();
            dataGridBuyProtien.ItemsSource = sellProtien;

        }
        private void dataGridBuyProtien_LayoutUpdated(object sender, EventArgs e)
        {
            int sum = context.Buyprotiens.Sum(x => x.Total);
			textTotal.Text = sum.ToString();
        }

		int totalIncome;
        int totalOut    ;

        // Financial
        private void financial_Click(object sender, RoutedEventArgs e)
        {
            headerText.Text = "FINANCIAL REPORT";
            receptionistGrid.Visibility = Visibility.Hidden;
            traineeGrid.Visibility = Visibility.Hidden;
            coachGrid.Visibility = Visibility.Hidden;
            protienGrid.Visibility = Visibility.Hidden;
            machineGrid.Visibility = Visibility.Hidden;
            vendorGrid.Visibility = Visibility.Hidden;
            BuyprotienGrid.Visibility = Visibility.Hidden;
            financialGrid.Visibility = Visibility.Visible;
            financialIncome.Visibility = Visibility.Visible;
            texttotal.Visibility = Visibility.Hidden;


            RAdd.Visibility = Visibility.Hidden;
            TAdd.Visibility = Visibility.Hidden;
            CAdd.Visibility = Visibility.Hidden;
            PAdd.Visibility = Visibility.Hidden;
            MAdd.Visibility = Visibility.Hidden;
            VAdd.Visibility = Visibility.Hidden;


            int TotalOfReceptionist = context.Receptionists.Sum(r => r.Salary);
            int TotalOfCoaches = context.Coaches.Sum(c => c.Salary);
            int TotalOfTrainee = context.Trainees.Sum(t => t.price);
            int TotalOfMachines = context.GymMachines.Sum(m => m.Price);
            int TotalOfProtein = context.ProtienProducts.Sum(p => p.Price);
            int TotalOfBuyProtein = context.Buyprotiens.Sum(p => p.Total);

            totalRece.Content = TotalOfReceptionist.ToString();
            totalTraineeIncome.Content = TotalOfTrainee.ToString();
            toatalCoach.Content = TotalOfCoaches.ToString();
            totalMach.Content = TotalOfMachines.ToString();
            totalProt.Content = TotalOfProtein.ToString();
            totalProtienIncome.Content = TotalOfBuyProtein.ToString();


            int budget = TotalOfReceptionist + TotalOfCoaches + TotalOfProtein + TotalOfMachines;
            int income = TotalOfTrainee + TotalOfBuyProtein;

            Budget.Content = budget.ToString();
            GymIncome.Content = income.ToString();

            int profite;
            if (income > budget)
            {
                profite = income - budget;
                Profit.Content = "You earned " + profite.ToString();
                Profit.Foreground = Brushes.Green;

            }
            else
            {
                profite = budget - income;
                Profit.Content = "You lost " + profite.ToString();
                Profit.Foreground = Brushes.Red;
            }

             totalIncome = TotalOfBuyProtein + TotalOfTrainee;
             totalOut    = TotalOfProtein + TotalOfMachines + TotalOfCoaches + TotalOfReceptionist;

			if (SeriesCollection != null)
			{
				SeriesCollection.Clear();
				SeriesCollection.Add(new PieSeries
				{
					Title = "totalIncome",
					Values = new ChartValues<ObservableValue> { new ObservableValue(totalIncome) },
					DataLabels = true
				});
				SeriesCollection.Add(new PieSeries
                {
                    Title = "Cost",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(totalOut) },
                    DataLabels = true
                });
            }
			else
			{
				SeriesCollection = new SeriesCollection
				{
					new PieSeries
					{
						Title = "totalIncome",
						Values = new ChartValues<ObservableValue> { new ObservableValue(totalIncome)},
						DataLabels = true
					},
					new PieSeries
					{
						Title = "Cost",
						Values = new ChartValues<ObservableValue> { new ObservableValue(totalOut)},
						DataLabels = true
					}
				};

				DataContext = this;
			}
        }
        


        //logout
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

       

        private void biChart_Initialized(object sender, EventArgs e)
        {
            
        }


       

        private void StackPanel_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "totalIncome",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(totalIncome)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Cost",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(totalOut)},
                    DataLabels = true
                }
            };

            DataContext = this;
        }
    }
}
