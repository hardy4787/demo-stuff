using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace IDisposable
{
    internal class ConnectionAndMemory : System.IDisposable
    {
        private int _chunkSize;
        private bool _isDisposed;

        bool isFreed;
        public static long TotalFreed { get; private set; }
        public static long TotalAllocated { get; private set; }

        SqlConnection connection;
        IntPtr chunkHandle;

        public ConnectionAndMemory(int chunkSize)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();

            this._chunkSize = chunkSize;
            chunkHandle = Marshal.AllocHGlobal(chunkSize);
            TotalAllocated += chunkSize;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
            {
                connection.Dispose();
                connection = null!;
            }

            FreeChunk();
            _isDisposed = true;
        }

        ~ConnectionAndMemory()
        {
            Dispose(false);
        }

        private void FreeChunk()
        {
            if (isFreed)
            {
                return;
            }

            Marshal.FreeHGlobal(chunkHandle);
            TotalFreed += _chunkSize;
            isFreed = true;
        }

        private int ChunkSize
        {
            get
            {
                if (_isDisposed)
                    throw new ObjectDisposedException("");
                return _chunkSize;
            }
            set => _chunkSize = value;
        }

        public void DoWork()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("");
        }
    }
}
