using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CS_Homework
{
    class Program
    {

        static void Main(string[] args)
        {
            Game2045 game2045 = new Game2045();
            game2045.StartGame();



            /*
            Stopwatch stopwatch = Stopwatch.StartNew();
            long elapsedTicks = 0;
            while(true)
            {
                stopwatch.Stop();
                WriteLine(stopwatch.ElapsedTicks);
                elapsedTicks += stopwatch.ElapsedTicks; 
                if( elapsedTicks > 500)
                {
                    WriteLine(elapsedTicks);
                    stopwatch.Reset();
                    elapsedTicks = 0;
                    //
                }
                else
                {
                    stopwatch.Reset();
                }
            }
            */


        }

       
    }


}
