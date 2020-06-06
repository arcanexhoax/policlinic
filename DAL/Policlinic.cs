using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
	public class Policlinic {
		public string PoliclinicId { get; set; }
		public string PoliclinicName { get; set; }
		public IEnumerable<Doctor> Doctors { get; set; }
		public IEnumerable<User> Users { get; set; }
	}
}
