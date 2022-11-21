using System.Diagnostics;

namespace threading
{
    public class ContextProvider<T> where T : new()
    {
        public T InitContext1()
        {
            _asyncLocal1 = new T();
            return _asyncLocal1;
        }

        public T GetContext1()
        {
            return _asyncLocal1;
        }
        public T InitContext()
        {
            _asyncLocal.Value = new T();
            return _asyncLocal.Value;
        }

        public T GetContext()
        {
            return _asyncLocal.Value;
        }

        private static readonly AsyncLocal<T> _asyncLocal = new AsyncLocal<T>();
        private static T _asyncLocal1;
    }


    public class Context
    {
        public Guid id { get; set; }
    }

    internal class Program
    {
        static Random r = new Random();
        static ContextProvider<Context>  ctxProvider = new ContextProvider<Context>();

        async static Task InitializeAndPrintContextAsync(int id)
        {
            var ctx = ctxProvider.InitContext1();
            var guid = Guid.NewGuid();
            Console.WriteLine($"Init context for id: {id} - {guid}.");
            ctx.id = guid;
            await Task.Delay(r.Next(1000));
            ctx = ctxProvider.GetContext1();
            Console.WriteLine($"Current context for id: {id} - {ctx.id} - {guid}.");
        }

        static async Task Main(string[] args)
        {
            //await CancellableMethod();
            //await TakeNewThreadFromPoolAsync();
            //await UseTheSameThreadAsync();
            //await EnumerableTestAsync();

            Console.Read();
        }

        static async Task TakeNewThreadFromPoolAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task task = Task.Delay(1000);
            await task;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        static async Task UseTheSameThreadAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task task = Task.Delay(1000);
            Thread.Sleep(1700);
            await task;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        static async Task CancellableMethod()
        {
            var tokenSource = new CancellationTokenSource();
            for (int i = 0; i < 10; ++i)
            {
                Task.Run(() => DoSomeWork(tokenSource.Token), tokenSource.Token);
            }

            tokenSource.Cancel();
            await Task.Delay(1000);
        }

        static async Task DoSomeWork(CancellationToken ct)
        {
            int maxIterations = 100;
            for (int i = 0; i < maxIterations; ++i)
            {
                Console.WriteLine(ct.IsCancellationRequested);
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Task cancelled.");
                    ct.ThrowIfCancellationRequested();
                }
            }
        }

        //static async Task EnumerableTestAsync()
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    IAsyncEnumerable<int> enumerable = AsyncYielding();
        //    Console.WriteLine($"Time after calling: {sw.ElapsedMilliseconds}");

        //    await foreach (var element in enumerable.WithCancellation().ConfigureAwait(false))
        //    {
        //        Console.WriteLine($"element: {element}");
        //        Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
        //    }
        //}

        static async IAsyncEnumerable<int> AsyncYielding()
        {
            foreach (var uselessElement in Enumerable.Range(1, 3))
            {
                Task task = Task.Delay(TimeSpan.FromSeconds(uselessElement));
                Console.WriteLine($"Task run: {uselessElement}");
                await task;
                yield return uselessElement;
            }
        }
    }
}