using GymSysyemWpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
	/// Interaction logic for machineUpdated.xaml
	/// </summary>
	public partial class machineUpdated : Window
	{
		public static GymMachine currentMachine = default;

		GymMachine GymMachine;
		public delegate void MachineData(object sender, GymMachine obj);
		public event MachineData machineDataUpdated;
		Context context = new Context();
		
		public machineUpdated()
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

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
            bool flag = true;

            GymMachine = new GymMachine();

			if (machineDataUpdated != null)
			{
				var q = context.GymMachines.Where(c => c.ID == int.Parse(textId.Text)).Select(c => c);
				foreach (var c in q)
				{
					c.Name = textName.Text;
                    if (textPrice.Text.Length == 0)
					{
                        c.Price = 0;
                    }
					else
					{
                        c.Price = int.Parse(textPrice.Text);
                    }

                    GymMachine = c;
				}
				


                if (textName.Text == "" || textPrice.Text == "")
                { flag = false; }
            }

            if (flag)
            {
                context.SaveChanges();
                machineDataUpdated(this, GymMachine);

                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
          
		}
		
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{


			this.Hide();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			textId.Text = currentMachine.ID.ToString();
			textName.Text = currentMachine.Name;
			textPrice.Text = currentMachine.Price.ToString();
		}
	}
}
