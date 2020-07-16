using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Enemy
    {
        private int att;
        private int hp;
        private double currentXPos;
        private double currentYPos;
        
        Random random = new Random();

        public double CurrentXPos { get => currentXPos; set => currentXPos = value; }
        public double CurrentYPos { get => currentYPos; set => currentYPos = value; }
        public int Att { get => att; set => att = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Exp { get; }

        public Enemy()
        {
            att = 10;
            hp = 50;
            currentXPos = WINDOW_WIDTH - 2;
            currentYPos = random.Next(0, WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT);
            Exp = 20;
        }
        
        internal void SetPos(Screen[,] screenArr)
        {
            screenArr[(int)currentXPos, (int)currentYPos] = Screen.S_LAUNCHER;
            screenArr[(int)currentXPos + 1, (int)currentYPos] = Screen.ENEMY;
            screenArr[(int)currentXPos, (int)currentYPos + 1] = Screen.ENEMY;
            screenArr[(int)currentXPos + 1, (int)currentYPos + 1] = Screen.ENEMY;
        }

        internal bool Move(Screen[,] screenArr, int playerYPos)
        {
            DeletePos(screenArr);
            currentXPos -= 0.3;
            if( playerYPos > CurrentYPos )
                currentYPos += 0.2;
            else if(playerYPos < CurrentYPos)
                currentYPos -= 0.2;

            if (currentXPos < 1)
                return false;
            else
                return true;
        }

        public void  DeletePos(Screen[,] screenArr)
        {
            screenArr[(int)currentXPos, (int)currentYPos] = Screen.BLANK;
            screenArr[(int)currentXPos + 1, (int)currentYPos] = Screen.BLANK;
            screenArr[(int)currentXPos, (int)currentYPos + 1] = Screen.BLANK;
            screenArr[(int)currentXPos + 1, (int)currentYPos + 1] = Screen.BLANK;
        }
    }
}
