using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class TimeManager
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();
        private uint baseTick;
        private uint currentTick;
        private int playTime;


        public void SetStart() => baseTick = GetTickCount();

        public bool IsElapsed()
        {
            currentTick = GetTickCount();
            if ((currentTick - baseTick) > FRAME_RATE)
            {
                baseTick = currentTick;
                return true;
            }
            else
                return false;
        }
        public void SetPlayTimeStart() => playTime = (int)GetTickCount() / 1000;
        public int GetPlayTime() => (int)GetTickCount() / 1000 - playTime;
    }
}

//스톱와치
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
