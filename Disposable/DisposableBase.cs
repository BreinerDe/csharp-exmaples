
using System;

namespace Disposable
{
    //Use in Projects < Net 5 
    public abstract class DisposableBase : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableBase()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                DisposeManagedResources();
            }

            _isDisposed = true;
        }
        protected abstract void DisposeManagedResources();
    }
}
