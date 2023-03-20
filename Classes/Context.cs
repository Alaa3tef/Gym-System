using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GymSysyemWpf.Classes
{
    public class Context : DbContext
    {
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Receptionist> Receptionists { get; set; }
		public DbSet<Coach> Coaches { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<GymMachine> GymMachines { get; set; }
		public DbSet<ProtienProduct> ProtienProducts { get; set; }
		public DbSet<Vendor> Vendors { get; set; }

		public DbSet<BuyProtien> Buyprotiens { get; set; }


		public Context() { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=MENATALLAH;Initial Catalog=Gym;Integrated Security=True; trust server certificate = true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
			{
				relation.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}

		
		
	}
}
