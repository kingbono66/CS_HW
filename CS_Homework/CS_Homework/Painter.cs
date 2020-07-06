using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Painter
    {



        public void DrawHeader()
        {
            ClearLines(0, HEADER_HEIGHT);            
            DrawHorizontal(0);
            DrawHorizontal(HEADER_HEIGHT - 1);            
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
        }
        public void DrawFooter()
        {
            int footerStartPos = WINDOW_HEIGHT - FOOTER_HEIGHT;

            ClearLines(footerStartPos, FOOTER_HEIGHT);            
            DrawHorizontal(footerStartPos);
            DrawHorizontal(WINDOW_HEIGHT - 1);            
            DrawVertical(0, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH - 1, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH / 3, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH * 2 / 3, footerStartPos, FOOTER_HEIGHT);
            SetCursorPosition(0, 0);
        }
        private void DrawVertical(int startPosX, int startPosY, int lineNum)
        {
            for (int i = 0; i < lineNum; i++)
            {
                SetCursorPosition(startPosX, startPosY + i);
                Write("|");
            }
        }
        private void DrawHorizontal(int y)
        {
            SetCursorPosition(0, y);
            for (int i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
        }

        private void ClearLines(int startYPos, int lineNum)
        {
            SetCursorPosition(0, startYPos);
            for (int i = 0; i < lineNum; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH; j++)
                    Write(" ");
                WriteLine();
            }
        }

        public void DrawStartScreen()
        {
            WriteLine("게임을 시작합니다");





            WriteLine("아무키나 누르세요"); ReadKey();
            Clear();
        }
        public void DrawCharacter(bool isDraw, int playerXPos, int playerYPos)  //좌하단
        {
            if (isDraw)
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
