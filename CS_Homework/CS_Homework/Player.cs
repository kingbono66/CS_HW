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
        private int xPos;
        private int yPos;
        private int hp;
        private int att;


        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Att { get => att; set => att = value; }
        public int Exp { get; set; }
        public int Level { get; set; }

        public Player(int x, int y)
        {
            xPos = x;
            YPos = y;
            hp = 100;
            att = 15;
            Exp = 0;
        }

        public void SetPos(Screen[,] screenArr )
        {
            screenArr[xPos + 2, yPos] = Screen.PLAYER;
            screenArr[xPos + 3, yPos] = Screen.PLAYER;
            screenArr[xPos + 4, yPos] = Screen.D_LAUNCHER;
            screenArr[xPos + 0, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 1, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 2, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 3, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 4, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 5, yPos + 1] = Screen.PLAYER;
            screenArr[xPos + 6, yPos + 1] = Screen.PLAYER;
        }
        public void DeletePos(Screen[,] screenArr)
        {
            screenArr[xPos + 2, YPos] = Screen.BLANK;
            screenArr[xPos + 3, YPos] = Screen.BLANK;
            screenArr[xPos + 4, YPos] = Screen.BLANK;
            screenArr[xPos + 0, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 1, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 2, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 3, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 4, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 5, YPos + 1] = Screen.BLANK;
            screenArr[xPos + 6, YPos + 1] = Screen.BLANK;
        }

    }
}
