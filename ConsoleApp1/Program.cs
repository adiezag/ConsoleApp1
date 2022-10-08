// See https://aka.ms/new-console-template for more information


namespace MyConsoleApplication
{

    //Interface
    interface MyInterface
    {
        // 3 methods
        int Age { get; set; }
        string Name { get; set; }
        bool IsAlive { get; set; }

    }

    class MyClass : MyInterface
    {
        // 3 properties
        private int age; 
        private string name;
        private bool isAlive;

        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

    }

    //Event
    class DisplayInfo
    {
        //Define a delegate
        public delegate void DisplayInfoEventHandler(object source, EventArgs args);

        //Declare the event
        public event DisplayInfoEventHandler InfoDisplayed;
        public void ShowInfo(MyClass avenger)
        {
            Console.WriteLine($"When Thanos got dusted, {avenger.Name} was {avenger.Age}.");
            Thread.Sleep(3000);

            OnInfoDisplayed();
        }
        
        //Raising the event
        protected virtual void OnInfoDisplayed()
        {
            if (InfoDisplayed != null) 
                InfoDisplayed(this, null);
        }
    }

    //Subscribing to the event
    public class AppService
    {
        public void OnInfoDisplayed(object source, EventArgs eventArgs)
        {
            Console.WriteLine("The end...");
        }
    }

    class Program
    {
        static void Main()
        {
            var Avenger = new MyClass();

            Avenger.Age = 53;
            Avenger.Name = "Tony";
            Avenger.IsAlive = false;

            var displayInfo = new DisplayInfo(); ;
            var appService = new AppService();

            displayInfo.InfoDisplayed += appService.OnInfoDisplayed;
            displayInfo.ShowInfo(Avenger);
            Console.ReadKey();
        }
    }

}
