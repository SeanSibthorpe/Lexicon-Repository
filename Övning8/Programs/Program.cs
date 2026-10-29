using Övning8.Interfaces;

namespace Övning8.Programs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program1 p1 = new Program1();
            Program2 p2 = new Program2();

            p1.Start();
            p1.DoSomething();

            p2.Start();

            IThirdInterface third = new Program3();
            IFourthInterface fourth = new Program3();

            third.Run();
            Console.WriteLine(fourth.Run());
                
           
            /*
            p1.Run();
            p2.Go();
            */
        }
    }
}
