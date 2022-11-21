namespace ClassVsStructVsRecord
{
    internal interface IActionType
    {
        public IActionType()
        {
            Console.WriteLine("kek");
        }
        public void Move()
        {
            Console.WriteLine("move");
        }
    }

    class FirstActionType : IActionType
    {

    }
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}