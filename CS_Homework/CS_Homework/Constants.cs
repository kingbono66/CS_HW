using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Homework
{
    static class Constants
    {
        public const int WINDOW_WIDTH = 120;
        public const int WINDOW_HEIGHT = 40;
        public const int HEADER_HEIGHT = 8;     //최소 5 이상
        public const int FOOTER_HEIGHT = 5;
        public const string TITLE = "2045!!!";
        //public const string DESCRIPTION = "2020.07.05 oh jong geun";
        public const string DESCRIPTION = "2020.07.05 오종근";
        public const int FRAME_RATE = 1000 / 20;  //뒤에 숫자가 프레임레이트
        public const int ENEMY_FREQ = (1000 / FRAME_RATE) * 1; // 뒤에숫자가 몇초당 하나 생성

        public enum Screen { BLANK, PLAYER, D_LAUNCHER, ENEMY1, ENEMY2, ENEMY3, ENEMY9, S_LAUNCHER, BASIC_MISSILE }
        public enum MsgType { DAMAGE, CLEAR, EXP }
        public enum WindowPos { LEFT, MIDDLE, RIGHT }
        public enum GameState { STAGE1, STAGE2, STAGE3, PAUSE, LEVELUP, ENDING }

        public const int INITIAL_XPOS = 20;
        public const int INITIAL_YPOS = 10;
        public const int MSG_DURATION = 2;  //시스템 메시지 지속시간

    }
}
