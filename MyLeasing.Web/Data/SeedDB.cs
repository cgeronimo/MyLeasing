using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
	public class SeedDB
	{
		private readonly DataContext _context;

		public SeedDB(DataContext context)
		{
			_context = context;
		}

		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckPropertyTypesAsync();
		}

		private async Task CheckPropertyTypesAsync()
		{
			if (!_context.PropertyTypes.Any())
			{
				_context.PropertyTypes.Add(new Entities.PropertyType { Name = "Apartamento" });
				_context.PropertyTypes.Add(new Entities.PropertyType { Name = "Casa" });
				_context.PropertyTypes.Add(new Entities.PropertyType { Name = "Negocio" });
				await _context.SaveChangesAsync();
			}
		}
	}
}
