using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Game2045 game2045 = new Game2045();
            game2045.StartGame();
        }
    }
}

//질문 타임매니저나 페인터처럼 오직 하나만 존재해야하는 클래스는 스태틱으로 만드는게 나은지
//     클래스의 멤퍼 필드 자동완성할때 두가지 차이점은?



//남은 일 레벨업,스킬,점수,미사일발사,플레이어 여러개,적 여러개