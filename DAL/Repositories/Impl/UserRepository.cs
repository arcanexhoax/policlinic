using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl {
	class UserRepository : BaseRepository<User>, IUserRepository {
		internal UserRepository(PoliclinicContext context)
			: base(context) {
		}

	}
}
