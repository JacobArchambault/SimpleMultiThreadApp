using System.Threading;
using static System.Console;
using static System.Threading.Thread;
using static System.Windows.Forms.MessageBox;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main()
        {
            WriteLine("***** The Amazing Thread App *****\n");
            Write("Do you want [1] or [2] threads? ");
            string threadCount = ReadLine();

            // Name the current thread.
            Thread primaryThread = CurrentThread;
            primaryThread.Name = "Primary";

            // Display Thread info.
            WriteLine($"-> {CurrentThread.Name} is executing Main()");

            // Make worker class.
            Printer p = new Printer();

            switch (threadCount)
            {
                case "2":
                    // Now make the thread.
                    Thread backgroundThread =
                      new Thread(new ThreadStart(p.PrintNumbers))
                      {
                          Name = "Secondary"
                      };
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1";
            }

            // Do some additional work.
            Show("I'm busy!", "Work on main thread...");
            ReadLine();
        }

    }
}