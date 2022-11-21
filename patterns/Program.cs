using patterns.AbstractFactory;
using patterns.FactoryMethod;
using patterns.SimpleFactory;
using patterns.Singleton;

namespace patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //SimpleFactory();
            //FactoryMethod();
            //AbstractFactory();
            Singleton();
        }

        static void SimpleFactory()
        {
            var factory = new FanFactory();
            var blackFan = factory.Create(FanType.Black);
            blackFan.SwitchOff();
        }

        static void FactoryMethod()
        {
            var woodDeveloper = new WoodDeveloper();
            IHouse house1 = woodDeveloper.CreateHouse();
            house1.OpenWindow();
            var panelDeveloper = new PanelDeveloper();
            IHouse house2 = panelDeveloper.CreateHouse();
            house2.OpenWindow();
        }

        static void AbstractFactory()
        {
            var electricity1 = new IndianElectricalFactory();
            var pipe1 = electricity1.GetPipe();
            var electricity2 = new USElectricicalFactory();
            var pipe2 = electricity2.GetPipe();
            var tubelight2 = electricity2.GetTubelight();
        }

        static void Singleton()
        {
            (new Thread(() =>
            {
                var comp2 = new Computer();
                comp2.OS = OSFirst.GetInstance("Windows 10");
                Console.WriteLine(comp2.OS.Name);

            })).Start();

            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);
            Console.ReadLine();
        }
    }
}