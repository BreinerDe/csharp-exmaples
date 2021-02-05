using System;

namespace Disposable
{
    // Use in Net 5
    public abstract record DisposableBaseRecord : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableBaseRecord()
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