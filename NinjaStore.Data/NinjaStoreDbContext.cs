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
		}
	}
}