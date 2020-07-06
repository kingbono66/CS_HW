using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Game2045
    {
        private bool isHeaderChanged;
        private bool isFooterChanged;
        private TimeManager timer;
        private int playerXPos, playerYPos;
        private Painter painter;

        internal void StartGame()
        {
            //초기화
            InitializeGame();

            //시작화면
            painter.DrawStartScreen();
            painter.DrawCharacter(true, playerXPos, playerYPos);
            while (true)
            {
                //화면 그리기
                if (isHeaderChanged) painter.DrawHeader(); isHeaderChanged = false;
                if (isFooterChanged) painter.DrawFooter(); isFooterChanged = false;
                
                //사용자 조작            
                if (timer.IsElapsed())
                {
                    PlayerProc();
                    FlushKey();
                }
            }

            //좌표수정


            //충돌판정


            //변동사항 반영


            //엔딩화면(점수표), 게임오버

        }

        private void FlushKey()
        {
            while (KeyAvailable)
                ReadKey(true);
        }

        private void PlayerProc()
        {
            ConsoleKey keys;
            if (KeyAvailable)
            {
                keys = ReadKey(true).Key;
                painter.DrawCharacter(false, playerXPos, playerYPos);
                switch (keys)
                {
                    case ConsoleKey.UpArrow:
                        playerYPos--;
                        break;
                    case ConsoleKey.DownArrow:
                        playerYPos++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerXPos--;
                        break;
                    case ConsoleKey.RightArrow:
                        playerXPos++;
                        break;
                }
                painter.DrawCharacter(true, playerXPos, playerYPos);
            }

        }

        
        

        private void InitializeGame()
        {
            WriteLine("게임 초기화 중입니다");
            CursorVisible = false;
            timer = new TimeManager();
            timer.SetStart();
            painter = new Painter();
            isHeaderChanged = true;
            isFooterChanged = true;
            playerXPos = 20;
            playerYPos = 20;
            SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);




            Clear();
        }
        
    }

   


}
