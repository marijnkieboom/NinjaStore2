using Microsoft.EntityFrameworkCore;
using NinjaStore.Data.Models;

namespace NinjaStore.Data
{
	public class NinjaStoreDbContext : DbContext
	{
		public NinjaStoreDbContext()
		{
		}

		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Ninja> Ninjas { get; set; }
		public DbSet<NinjaEquipment> NinjaEquipment { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=localhost;Database=NinjaStore;Trusted_Connection=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NinjaEquipment>()
				.HasKey(t => new { t.NinjaId, t.EquipmentId });

			modelBuilder.Entity<NinjaEquipment>()
				.HasOne(pt => pt.Ninja)
				.WithMany(p => p.Bevat)
				.HasForeignKey(pt => pt.NinjaId);

			modelBuilder.Entity<NinjaEquipment>()
				.HasOne(pt => pt.Equipment)
				.WithMany(p => p.OnderdeelVan)
				.HasForeignKey(pt => pt.EquipmentId);


			modelBuilder.Entity<Equipment>().HasData(new Equipment {EquipmentId = 1, Name = "Petje", Value = 100, Category = Category.Head, Strength = 30 , Agility = 40 , Intelligence= 40 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 2, Name = "Broek", Value = 150, Category = Category.Feet, Strength = 32, Agility = 86, Intelligence = 34 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 3, Name = "Hoed", Value = 200, Category = Category.Head, Strength = 16, Agility = 18, Intelligence = 40 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 4, Name = "Kettingkje", Value = 50, Category = Category.Necklace, Strength = 60, Agility = 10, Intelligence = 10});
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 5, Name = "Crocs", Value = 100, Category = Category.Feet, Strength = 98, Agility = 49, Intelligence = 309 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 6, Name = "Vuurring", Value = 200, Category = Category.Ring, Strength = 453, Agility = 56, Intelligence = 86 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 7, Name = "Schoenhand", Value = 300, Category = Category.Hand, Strength = 80, Agility = 76, Intelligence = 122 });
			modelBuilder.Entity<Equipment>().HasData(new Equipment { EquipmentId = 8, Name = "Shirt", Value = 100, Category = Category.Chest, Strength = 76, Agility = 469, Intelligence = 67 });
		}
	}
}