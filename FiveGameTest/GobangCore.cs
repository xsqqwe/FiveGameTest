using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiveGameTest
{
    /// <summary>
    /// 五子棋核心
    /// </summary>
    public class GobangCore
    {
        public ChessState[,] gameMap = new ChessState[15, 15];

        public Dictionary<string, int[]> direction = null;

        private Chess LastChess = null;

        public GobangCore()
        {
            direction = new Dictionary<string, int[]>
            {
                {"U",   new int[]{0, -1}},//上
                {"D",   new int[]{0,  1}},//下
                {"L",   new int[]{-1, 0}},//左
                {"R",   new int[]{ 1, 0}},//右
                {"LU",new int[]{-1, -1}},//左上
                {"LD",new int[]{1, -1}},//左下
                {"RU",new int[]{-1, 1}},//右上
                {"RD",new int[]{1, 1}}  //右下
            };
        }

        /// <summary>
        /// 放棋子
        /// </summary>
        /// <param name="rIndex"></param>
        /// <param name="cIndex"></param>
        /// <param name="state"></param>
        public void FallingChess(int rIndex, int cIndex, ChessState state)
        {
            if (gameMap[rIndex, cIndex] == ChessState.Empty)
            {
                gameMap[rIndex, cIndex] = state;
                LastChess = new Chess() { RIndex = rIndex, CIndex = cIndex, State = state };
            }
        }

        /// <summary>
        /// 判断胜负
        /// </summary>
        /// <returns></returns>
        public bool IsWin()
        {
            if (LastChess != null)
            {
                int chessCount = 1;
                //水平
                chessCount += EqualsCount(direction["L"]) + EqualsCount(direction["R"]);
                if (chessCount >= 5) return true;
                //垂直
                chessCount = 1;
                chessCount += EqualsCount(direction["U"]) + EqualsCount(direction["D"]);
                if (chessCount >= 5) return true;
                //左上-->右下
                chessCount = 1;
                chessCount += EqualsCount(direction["LU"]) + EqualsCount(direction["RD"]);
                if (chessCount >= 5) return true;
                //右上-->左下
                chessCount = 1;
                chessCount += EqualsCount(direction["RU"]) + EqualsCount(direction["LD"]);
                if (chessCount >= 5) return true;
            }
            return false;
        }

        /// <summary>
        /// 计算相同颜色棋子的数量
        /// </summary>
        /// <param name="direct">方向</param>
        /// <returns></returns>
        public int EqualsCount( int[] direct)
        {
            if (LastChess != null)
            {
                int rIndex = LastChess.RIndex;
                int cIndex = LastChess.CIndex;
                ChessState state = LastChess.State;

                int chessCount = 0;
                for (int i = 0; i < 4; i++)
                {
                    rIndex += direct[0];
                    cIndex += direct[1];
                    if (rIndex >= 0 && rIndex <= 14 &&
                        cIndex >= 0 && cIndex <= 14 &&
                        gameMap[rIndex, cIndex] == state)
                        chessCount += 1;
                    else
                        break;
                }
                return chessCount;
            }
            return 0;
        }


        public void ClearMap()
        {
            Array.Clear(gameMap, 0, gameMap.Length);
        }

    }
}
