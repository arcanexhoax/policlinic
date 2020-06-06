using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF {
	class PoliclinicContext : DbContext {
		public DbSet<Policlinic> Policlinics { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Doctor> Doctors { get; set; }

		public PoliclinicContext(DbContextOptions options)
			: base(options) {
		}
	}
}
