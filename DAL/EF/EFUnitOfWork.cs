using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF {
    public class EFUnitOfWork
        : IUnitOfWork {
        private PoliclinicContext db;
        private PoliclinicRepository policlinicRepository;
        private DoctorRepository doctorRepository;
        private UserRepository userRepository;
        
        public EFUnitOfWork(DbContextOptions options) {
            db = new PoliclinicContext(options);
        }

        public IPoliclinicRepository Policlinicss {
            get {
                if (policlinicRepository == null)
                    policlinicRepository = new PoliclinicRepository(db);
                return policlinicRepository;
            }
        }
        
        public IDoctorRepository Doctorss {
            get {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public IUserRepository Userss {
            get {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save() {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
