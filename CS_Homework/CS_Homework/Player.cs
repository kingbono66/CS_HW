using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Player : Character, ICoordinateable
    {    

        public int XPos { get; set; }
        public int YPos { get; set; }
       
        public Player(int x, int y)
        {
            XPos = x;
            YPos = y;
            Hp = 100;
            Att = 15;
            Exp = 0;
            Level = 1;
        }

        public void SetPos(Screen[,] screenArr )
        {
            screenArr[XPos + 2, YPos] = Screen.PLAYER;
            screenArr[XPos + 3, YPos] = Screen.PLAYER;
            screenArr[XPos + 4, YPos] = Screen.D_LAUNCHER;
            screenArr[XPos + 0, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 1, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 2, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 3, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 4, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 5, YPos + 1] = Screen.PLAYER;
            screenArr[XPos + 6, YPos + 1] = Screen.PLAYER;
        }
        public void DeletePos(Screen[,] screenArr)
        {
            screenArr[XPos + 2, YPos] = Screen.BLANK;
            screenArr[XPos + 3, YPos] = Screen.BLANK;
            screenArr[XPos + 4, YPos] = Screen.BLANK;
            screenArr[XPos + 0, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 1, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 2, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 3, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 4, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 5, YPos + 1] = Screen.BLANK;
            screenArr[XPos + 6, YPos + 1] = Screen.BLANK;
        }
    }
}
