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

        internal void Blink(Screen[,] screenArr, System.Collections.ArrayList enemyList, Calculator calculator)
        {
            DeletePos(screenArr);
            XPos += 25;
            if (XPos > WINDOW_WIDTH - 8) XPos = WINDOW_WIDTH - 8;
            for(int i = 0; i < 10; i++)
            {
                int damage = calculator.Collide(screenArr, this, enemyList);
                Hp += damage;
            }
            SetPos(screenArr);
        }

        internal void Excalibur(Screen[,] screenArr, System.Collections.ArrayList enemyList)
        {
            Enemy e;
            for( int i = 0; i < enemyList.Count; i++)
            {
                e = (Enemy)enemyList[i];
                if ( e.XPos >= XPos+2 && e.XPos <= XPos+25 && e.YPos >= YPos - 10 && e.YPos <= YPos + 4)
                {
                    e.DeletePos(screenArr);
                    enemyList.RemoveAt(i--);
                }
            }
        }

        internal void Heal()
        {
            Hp += 50;
        }
    }
}
