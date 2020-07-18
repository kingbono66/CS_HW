using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Missile : ICoordinateable
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Missile(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public void SetPos(Screen[,] screenArr) => screenArr[XPos, YPos] = Screen.BASIC_MISSILE;
        public void DeletePos(Screen[,] screenArr) => screenArr[XPos, YPos] = Screen.BLANK;
    }
}
