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
	/// Interaction logic for ProtienUpdate.xaml
	/// </summary>
	public partial class ProtienUpdate : Window
	{
		public static ProtienProduct currentProtien;

		ProtienProduct ProtienAfterUpdate = new ProtienProduct();

		public delegate void ProtienData(object sender, ProtienProduct prot);

		public event ProtienData ProtienDataUpdated;

		Context context = new Context();
		public ProtienUpdate()
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
			textId.Text = currentProtien.ID.ToString();
			textName.Text = currentProtien.Name;
			txtQuantaty.Text = currentProtien.Quantaty.ToString();
			txtPrice.Text = currentProtien.Price.ToString();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
            bool flag = true;

            ProtienProduct protien = new ProtienProduct();
			if (ProtienDataUpdated != null)
			{
				var query = context.ProtienProducts.Where(p => p.ID == int.Parse(textId.Text)).Select(p => p);
				foreach (var p in query)
				{
					p.Name = textName.Text;

                    if (txtQuantaty.Text.Length == 0)
                    {
                        p.Quantaty = 0;
                    }
                    else
                    {
                        p.Quantaty = int.Parse(txtQuantaty.Text);
                    }
					
					if (txtPrice.Text.Length == 0)
                    {
                        p.Price = 0;
                    }
                    else
                    {
                        p.Price = int.Parse(txtPrice.Text);
                    }

                    p.Total = p.Quantaty * p.Price;
					protien = p;
				}
				if (textName.Text == "" || txtQuantaty.Text == "" || txtPrice.Text == "" )
				{ flag = false; }
			}

            if (flag)
            {
                context.SaveChanges();
                ProtienDataUpdated(this, protien);

                this.Close();
            }
            else
            {
                errorTextblock.Text = "You must enter all data";
            }
           
		}
			
	}
}

