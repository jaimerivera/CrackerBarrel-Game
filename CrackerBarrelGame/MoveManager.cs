using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackerBarrelGame
{
    class MoveManager
    {
        public void UpdateBoard(ref Board board, Move move)
        {
            board.Positions[move.from] = 0;
            board.Positions[move.to] = 1;
            board.Positions[move.remove] = 0;
            return;
        }

        public List<Move> GetPossbileMoveList(ref Board board)
        {
            List<Move> dlist = new List<Move>();

            for (int i = 0; i < board.Positions.Length; i++)
            {
                if (board.Positions[i] != 0)
                    PossibleMoves(ref dlist, ref board, i);
            }
            return dlist;
        }

        private void PossibleMoves(ref List<Move> moveList, ref Board board, int position)
        {
            switch (position)
            {
                case 0:
                    CheckMove(ref moveList, ref board, 0, 3, 1);
                    CheckMove(ref moveList, ref board, 0, 5, 2);
                    break;
                case 1:
                    CheckMove(ref moveList, ref board, 1, 6, 3);
                    CheckMove(ref moveList, ref board, 1, 8, 4);
                    break;
                case 2:
                    CheckMove(ref moveList, ref board, 2, 7, 4);
                    CheckMove(ref moveList, ref board, 2, 9, 5);
                    break;
                case 3:
                    CheckMove(ref moveList, ref board, 3, 0, 1);
                    CheckMove(ref moveList, ref board, 3, 5, 4);
                    CheckMove(ref moveList, ref board, 3, 10, 6);
                    CheckMove(ref moveList, ref board, 3, 12, 7);
                    break;
                case 4:
                    CheckMove(ref moveList, ref board, 4, 11, 7);
                    CheckMove(ref moveList, ref board, 4, 13, 8);
                    break;
                case 5:
                    CheckMove(ref moveList, ref board, 5, 0, 2);
                    CheckMove(ref moveList, ref board, 5, 3, 4);
                    CheckMove(ref moveList, ref board, 5, 12, 8);
                    CheckMove(ref moveList, ref board, 5, 14, 9);
                    break;
                case 6:
                    CheckMove(ref moveList, ref board, 6, 1, 3);
                    CheckMove(ref moveList, ref board, 6, 8, 7);
                    break;
                case 7:
                    CheckMove(ref moveList, ref board, 7, 2, 4);
                    CheckMove(ref moveList, ref board, 7, 9, 8);
                    break;
                case 8:
                    CheckMove(ref moveList, ref board, 8, 1, 4);
                    CheckMove(ref moveList, ref board, 8, 6, 7);
                    break;
                case 9:
                    CheckMove(ref moveList, ref board, 9, 2, 5);
                    CheckMove(ref moveList, ref board, 9, 7, 8);
                    break;
                case 10:
                    CheckMove(ref moveList, ref board, 10, 3, 6);
                    CheckMove(ref moveList, ref board, 10, 12, 11);
                    break;
                case 11:
                    CheckMove(ref moveList, ref board, 11, 4, 7);
                    CheckMove(ref moveList, ref board, 11, 13, 12);
                    break;
                case 12:
                    CheckMove(ref moveList, ref board, 12, 3, 7);
                    CheckMove(ref moveList, ref board, 12, 5, 8);
                    CheckMove(ref moveList, ref board, 12, 10, 11);
                    CheckMove(ref moveList, ref board, 12, 14, 13);
                    break;
                case 13:
                    CheckMove(ref moveList, ref board, 13, 4, 8);
                    CheckMove(ref moveList, ref board, 13, 11, 12);
                    break;
                case 14:
                    CheckMove(ref moveList, ref board, 14, 5, 9);
                    CheckMove(ref moveList, ref board, 14, 12, 13);
                    break;                   
            }
        }

        private void CheckMove(ref List<Move> moveList, ref Board board, int curr, int dnew, int rem)
        {
            if (board.Positions[dnew] == 0 && board.Positions[rem] == 1)
            {
                Move m = new Move() { from = curr, to = dnew, remove = rem };
                moveList.Add(m);
            }
        }
    }
}
