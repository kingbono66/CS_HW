using System;
using System.Collections;
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
        private Screen[,] screenArr;
        private Player player;
        private Random random;
        private ArrayList enemyList;


        internal void StartGame()
        {
            //초기화
            InitializeGame();

            //시작화면
            painter.DrawStartScreen();
            while (true)
            {
                //화면 그리기
                if (isHeaderChanged) painter.DrawHeader(); isHeaderChanged = false;
                if (isFooterChanged) painter.DrawFooter(); isFooterChanged = false;
                painter.DrawMainScreen(screenArr);
                //사용자 조작            
                if (timer.IsElapsed())
                {
                    PlayerProc();
                    FlushKey();
                    if (random.Next(0, ENEMY_FREQ) == 1)
                    {
                        Enemy enemy = new Enemy();
                        enemyList.Add(enemy);
                        enemy.SetPos(screenArr);
                    }
                    for ( int i = 0; i < enemyList.Count; i++)
                    {
                        if (((Enemy)enemyList[i]).Move(screenArr))
                            ((Enemy)enemyList[i]).SetPos(screenArr);
                        else
                            enemyList.RemoveAt(i--);
                    }


                   
                }
                //적 조작
                
                
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
                player.DeletePos(screenArr, playerXPos, playerYPos);
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
                player.SetPos(screenArr, playerXPos, playerYPos);
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
            screenArr = new Screen[WINDOW_WIDTH + 5, WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT + 5];
            for( int i = 0; i < WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT + 5; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH + 5; j++)
                    screenArr[j, i] = Screen.BLANK;
            }
            playerXPos = 20;
            playerYPos = 15;
            player = new Player();
            player.SetPos(screenArr, playerXPos, playerYPos);
            random = new Random();
            enemyList = new ArrayList();
            SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);



            Clear();
        }
        
    }

   


}
