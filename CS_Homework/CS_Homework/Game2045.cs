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


        internal void StartGame()
        {
            //초기화
            InitializeGame();

            //시작화면
            DrawStartScreen();
            DrawCharacter(true);
            while (true)
            {
                //화면 그리기
                if (isHeaderChanged) DrawHeader();
                if (isFooterChanged) DrawFooter();

                //사용자 조작
            
                if (timer.IsElapsed())
                {
                    TestProc();
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

        private void TestProc()
        {
            ConsoleKey keys;
            if (KeyAvailable)
            {
                keys = ReadKey(true).Key;
                DrawCharacter(false);
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
                DrawCharacter(true);
            }

        }

        
        private void DrawHeader()
        {
            int i = 0;

            SetCursorPosition(0, 0);
            for ( i = 0; i < HEADER_HEIGHT; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH; j++)
                    Write(" ");
                WriteLine();
            }
            SetCursorPosition(0, 0);
            for (i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
            SetCursorPosition(0, HEADER_HEIGHT - 1);
            for (i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
            DrawVertical(0, 0, HEADER_HEIGHT);
            DrawVertical(WINDOW_WIDTH - 1, 0, HEADER_HEIGHT);
            
            SetCursorPosition((WINDOW_WIDTH - TITLE.Length) / 2, HEADER_HEIGHT / 2);
            ForegroundColor = ConsoleColor.Green;
            Write(TITLE);
            SetCursorPosition(WINDOW_WIDTH - (DESCRIPTION.Length + 1), HEADER_HEIGHT / 2 + 1);
            ForegroundColor = ConsoleColor.Blue;
            Write(DESCRIPTION);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(0, 0);

            isHeaderChanged = false;
        }
        private void DrawFooter()
        {
            int i = 0;
            int footerStartPos = WINDOW_HEIGHT - FOOTER_HEIGHT;

            SetCursorPosition(0, footerStartPos);
            for (i = 0; i < FOOTER_HEIGHT; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH; j++)
                    Write(" ");
                WriteLine();
            }
            SetCursorPosition(0, footerStartPos);
            for (i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
            SetCursorPosition(0, WINDOW_HEIGHT - 1);
            for (i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
            DrawVertical(0, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH -1 , footerStartPos, FOOTER_HEIGHT);

            DrawVertical(WINDOW_WIDTH/3, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH * 2 / 3, footerStartPos, FOOTER_HEIGHT);
            SetCursorPosition(0, 0);

            isFooterChanged = false;
        }
        private void DrawVertical(int startPosX, int startPosY, int lineNum)
        {
            for( int i = 0; i < lineNum; i++)
            { 
                SetCursorPosition(startPosX, startPosY + i);
                Write("|");
            }
        }


        private void DrawStartScreen()
        {
            WriteLine("게임을 시작합니다");





            WriteLine("아무키나 누르세요"); ReadKey();
            Clear();
        }

        private void InitializeGame()
        {
            WriteLine("게임 초기화 중입니다");
            CursorVisible = false;
            timer = new TimeManager();
            timer.SetStart();
            isHeaderChanged = true;
            isFooterChanged = true;
            playerXPos = 20;
            playerYPos = 20;
            SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);




            Clear();
        }
        private void DrawCharacter(bool isDraw)  //좌하단
        {
            if(isDraw)
            {
                BackgroundColor = ConsoleColor.White;
                SetCursorPosition(playerXPos, playerYPos); Write("       ");
                SetCursorPosition(playerXPos + 2, playerYPos - 1); Write("  ");
                BackgroundColor = ConsoleColor.Black; Write("==");
            }
            else
            {
                SetCursorPosition(playerXPos, playerYPos); Write("       ");
                SetCursorPosition(playerXPos + 2, playerYPos - 1); Write("    ");
            }

            SetCursorPosition(0, 0);
        }
    }

   


}
