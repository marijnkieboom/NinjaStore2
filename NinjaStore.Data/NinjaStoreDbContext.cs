using Microsoft.EntityFrameworkCore;
using NinjaStore.Data.Model;
using System;

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
			options.UseSqlServer("Server=localhost;Database=SuperShop;Trusted_Connection=true");
		}
	}
}