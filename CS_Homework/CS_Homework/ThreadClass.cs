using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    public delegate void ThreadClassCallBack(bool isChanged);
    class ThreadClass
    {
        private SkillType skillType;
        private int xPos;
        private int yPos;
        private Screen[,] screenArr;
        private ThreadClassCallBack callback;  //결과값을 반환할 콜백 대리자

        public ThreadClass(Screen[,] screenArr,SkillType skillType, int xPos, int yPos, ThreadClassCallBack callback)
        {            
            this.callback = callback;
            this.skillType = skillType;
            this.xPos = xPos;
            this.yPos = yPos;
            this.screenArr = screenArr;
        }

        //스레드 프로시저
        public void ThreadProc()
        {
            if (callback != null) //콜백 대리자 확인후 실행.
            {
                DrawSkillEffect();
                callback(true);
            }
        }

        public void DrawSkillEffect()
        {
            switch (skillType)
            {
                case SkillType.BLINK:
                    {
                        int xPos = this.xPos - BLINK_RANGE;
                        if (xPos > WINDOW_WIDTH - 26) break;
                        for (int i = 0; i < BLINK_RANGE; i++)
                        {
                            screenArr[xPos + i, yPos + 1] = Screen.BLINK;
                            screenArr[xPos + i, yPos] = Screen.BLINK;
                        }
                        Thread.Sleep(2000);
                        for (int i = 0; i < BLINK_RANGE; i++)
                        {
                            screenArr[xPos + i, yPos + 1] = Screen.BLANK;
                            screenArr[xPos + i, yPos] = Screen.BLANK;
                        }
                    }                    
                    break;
                case SkillType.EXCALIBUR:
                    if (yPos < 8 || yPos > WINDOW_HEIGHT - FOOTER_HEIGHT - HEADER_HEIGHT - 3) break;
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3, yPos - 3 - i] = Screen.EXCALIBUR;
                    Thread.Sleep(500);
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3, yPos - 3 - i] = Screen.BLANK;
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3 + i, yPos - 3 - i] = Screen.EXCALIBUR;
                    Thread.Sleep(500);
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3 + i, yPos - 3 - i] = Screen.BLANK;
                    for (int i = 0; i < 10; i++)
                        screenArr[xPos + 3 + i, yPos - 3] = Screen.EXCALIBUR;
                    Thread.Sleep(500);
                    for (int i = 0; i < 10; i++)
                        screenArr[xPos + 3 + i, yPos - 3] = Screen.BLANK;
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3 + i, yPos - 3 + i] = Screen.EXCALIBUR;
                    Thread.Sleep(500);
                    for (int i = 0; i < 5; i++)
                        screenArr[xPos + 3 + i, yPos - 3 + i] = Screen.BLANK;
                    break;
                case SkillType.HEAL:
                    if (yPos < 5) break;
                    DrawHeal(xPos + 3, yPos - 1, true);
                    Thread.Sleep(500);
                    DrawHeal(xPos + 3, yPos - 1, false);
                    if( yPos > 8)
                    {
                        DrawHeal(xPos + 3, yPos - 2, true);
                        Thread.Sleep(500);
                        DrawHeal(xPos + 3, yPos - 2, false);
                        DrawHeal(xPos + 3, yPos - 3, true);
                        Thread.Sleep(500);
                        DrawHeal(xPos + 3, yPos - 3, false);
                    }                    
                    break;
            }
        }
        public void DrawHeal(int xPos, int yPos, bool isDraw)
        {
            Screen type;
            if (isDraw)
                type = Screen.HEAL;
            else
                type = Screen.BLANK;

            screenArr[xPos + 2, yPos - 2] = type;
            screenArr[xPos + 3, yPos - 2] = type;
            screenArr[xPos, yPos - 1] = type;
            screenArr[xPos + 1, yPos - 1] = type;
            screenArr[xPos + 2, yPos - 1] = type;
            screenArr[xPos + 3, yPos - 1] = type;
            screenArr[xPos + 4, yPos - 1] = type;
            screenArr[xPos + 5, yPos - 1] = type;
            screenArr[xPos + 2, yPos] = type;
            screenArr[xPos + 3, yPos] = type;
        }
    }
}
