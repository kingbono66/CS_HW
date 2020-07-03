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
            CursorVisible = false;
            //선언부
            int x = 5, y = 2;


            TestElapsedTime testTime = new TestElapsedTime();
            testTime.SetStart();
            while (true)
            {
                testTime.GetCurrentEndTick();
                if (testTime.uCurrentEndTick - testTime.uStartTick > 500)
                {
                    //WriteLine($"cycle: {testTime.uCurrentEndTick}  {testTime.uStartTick}  :  {testTime.uCurrentEndTick - testTime.uStartTick}");
                    testTime.uStartTick = testTime.uCurrentEndTick;
                    TestProc();
                    flushKey();
                    WriteLine("time pass");
                }
            }



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








            /*




            //실행부
            while (true)
            {
                //초기화
                //Clear();

                //위치세팅
                SetCursorPosition(x, y);

                //출력
                Write("^^");

                //키보드입력
                ConsoleKey key = ReadKey(true).Key;
                CharacterClear(x, y);

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                }
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                
            }
            */

        }

        private static void flushKey()
        {
            while (KeyAvailable)
                ReadKey(true);
        }

        private static void TestProc()
        {
            ConsoleKey keys;
            if (KeyAvailable)
            {
                keys = ReadKey(true).Key;
                switch (keys)
                {
                    case ConsoleKey.UpArrow:
                        WriteLine("up");
                        break;
                    case ConsoleKey.DownArrow:
                        WriteLine("down");
                        break;
                    case ConsoleKey.LeftArrow:
                        WriteLine("left");
                        break;
                    case ConsoleKey.RightArrow:
                        WriteLine("right");
                        break;
                }
            }

        }

        static void CharacterClear(int x, int y)
        {
            SetCursorPosition(x, y);
            Write("  ");
        }

        public class TestElapsedTime
        {
            [DllImport("kernel32.dll")]
            public static extern uint GetTickCount();
            public uint uStartTick;
            public uint uStopTick;
            public uint uCurrentEndTick;
            public void SetStart()
            {
                uStartTick = GetTickCount();
            }
            public void SetEnd(string strName)
            {
                uStopTick = GetTickCount();
                string elapsedTime = Convert.ToString(uStopTick - uStartTick);
                Trace.WriteLine(strName + "걸린시간: " + elapsedTime);
            }
            public uint GetCurrentEndTick()
            {
                uCurrentEndTick = GetTickCount();
                return uCurrentEndTick - uStartTick;
            }
        }

    }


}
