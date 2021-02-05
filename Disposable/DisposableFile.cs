using System.IO;

namespace Disposable
{
    public sealed record DisposableFile(FileInfo FileInfo) : DisposableBaseRecord
    {
        protected override void DisposeManagedResources()
        {
            File.Delete(FileInfo.FullName);
        }
    }
}