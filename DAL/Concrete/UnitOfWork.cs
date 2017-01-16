using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork 
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        /* private bool disposed = false;

 public virtual void Dispose(bool disposing)
 {
     if (!this.disposed)
     {
         if (disposing)
         {
             db.Dispose();
         }
         this.disposed = true;
     }
 }

 public void Dispose()
 {
     Dispose(true);
     GC.SuppressFinalize(this);
 }*/
    }
}
