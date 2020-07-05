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

        public void SetStart()
        {
            baseTick = GetTickCount();
        }
        
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
    }
}
