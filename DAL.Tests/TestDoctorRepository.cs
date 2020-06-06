using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests {
	class TestDoctorRepository : BaseRepository<Doctor>  {
		public TestDoctorRepository(DbContext context)
		: base(context) {
		}
	}
}
