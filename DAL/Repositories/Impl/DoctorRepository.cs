using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl {
	class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository {
		internal DoctorRepository(PoliclinicContext context)
			: base(context) {
		}

	}
}
