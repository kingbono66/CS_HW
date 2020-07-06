using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Player
    {


        public void SetPos(Screen[,] screenArr, int x, int y)
        {
            screenArr[x + 2, y] = Screen.PLAYER;
            screenArr[x + 3, y] = Screen.PLAYER;
            screenArr[x + 4, y] = Screen.D_LAUNCHER;
            screenArr[x + 0, y + 1] = Screen.PLAYER;
            screenArr[x + 1, y + 1] = Screen.PLAYER;
            screenArr[x + 2, y + 1] = Screen.PLAYER;
            screenArr[x + 3, y + 1] = Screen.PLAYER;
            screenArr[x + 4, y + 1] = Screen.PLAYER;
            screenArr[x + 5, y + 1] = Screen.PLAYER;
            screenArr[x + 6, y + 1] = Screen.PLAYER;
        }
        public void DeletePos(Screen[,] screenArr, int x, int y)
        {
            screenArr[x + 2, y] = Screen.BLANK;
            screenArr[x + 3, y] = Screen.BLANK;
            screenArr[x + 4, y] = Screen.BLANK;
            screenArr[x + 0, y + 1] = Screen.BLANK;
            screenArr[x + 1, y + 1] = Screen.BLANK;
            screenArr[x + 2, y + 1] = Screen.BLANK;
            screenArr[x + 3, y + 1] = Screen.BLANK;
            screenArr[x + 4, y + 1] = Screen.BLANK;
            screenArr[x + 5, y + 1] = Screen.BLANK;
            screenArr[x + 6, y + 1] = Screen.BLANK;
        }

    }
}
