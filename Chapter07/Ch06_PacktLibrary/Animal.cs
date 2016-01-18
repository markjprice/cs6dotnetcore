using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public class Animal : IDisposable
    {
        public Animal()
        {
            // allocate unmanaged resource
        }
        ~Animal() // Finalizer aka destructor
        {
            if (disposed) return;
            Dispose(false);
        }
        bool disposed = false; // have resources been released? 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            // deallocate the *unmanaged* resource
            // ...
            if (disposing)
            {
                // deallocate any other *managed* resources
                // ...
            }
            disposed = true;
        }
    }
}
