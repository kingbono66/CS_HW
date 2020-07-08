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
        private int originYPos;
        private int att;
        private int hp;
        private double currentXPos;
        private double currentYPos;
        Random random = new Random();

        public double CurrentXPos { get => currentXPos; set => currentXPos = value; }
        public double CurrentYPos { get => currentYPos; set => currentYPos = value; }
        public int Att { get => att; set => att = value; }
        public int Hp { get => hp; set => hp = value; }

        public Enemy()
        {
            att = 10;
            hp = 50;
            originYPos = random.Next(0, WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT);
            currentXPos = WINDOW_WIDTH - 2;
            currentYPos = originYPos;
        }
        
        internal void SetPos(Screen[,] screenArr)
        {
            screenArr[(int)currentXPos, (int)currentYPos] = Screen.S_LAUNCHER;
            screenArr[(int)currentXPos + 1, (int)currentYPos] = Screen.ENEMY;
            screenArr[(int)currentXPos, (int)currentYPos + 1] = Screen.ENEMY;
            screenArr[(int)currentXPos + 1, (int)currentYPos + 1] = Screen.ENEMY;
        }

        internal bool Move(Screen[,] screenArr)
        {
            DeletePos(screenArr);
            currentXPos -= 0.2;
            if (random.Next(0, 2) == 1)
                currentYPos += 0.2;
            else
                currentYPos -= 0.2;
            if (currentXPos < 1 || currentYPos < 1 || currentYPos > WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT - 4)
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
