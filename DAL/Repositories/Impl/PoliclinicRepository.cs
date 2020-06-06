using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl {
	class PoliclinicRepository : BaseRepository<Policlinic>, IPoliclinicRepository {
		internal PoliclinicRepository(PoliclinicContext context)
			: base(context) {
		}

	}
}
