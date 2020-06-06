using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitsOfWork {
    interface IUnitOfWork : IDisposable {
        IPoliclinicRepository Policlinicss { get; }
        IDoctorRepository Doctorss { get; }
        IUserRepository Userss { get; }
        void Save();
    }
}
