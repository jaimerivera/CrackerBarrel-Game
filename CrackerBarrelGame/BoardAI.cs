using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CrackerBarrelGame
{
    class BoardAI
    {
        static int possibleMoves = 0;
        static int branchesChecked = 0;

        public int GetBoardSolutions(Board board)
        {
            possibleMoves = 0;
            branchesChecked = 0;
            GetMoveCount(board, 0);
            Console.WriteLine("Checked {0} branches",branchesChecked);
            return possibleMoves;
        }

        public int GetBranchesCount { 
            get { return branchesChecked; }            
        }
        

        private void GetMoveCount(Board board, int level)
        {            
            MoveManager boardMgr = new MoveManager();
            List<Move> moves = boardMgr.GetPossbileMoveList(ref board);

            if (moves.Count == 0)
            {                
                CheckWinner(ref board);
                return;
            }

            IncBranches();

            if (level < 2)
            {
                
                ++level;

                Parallel.ForEach(moves, currmove =>
                {
                    
                    Board newBoard = new Board();
                    Array.Copy(board.Positions, newBoard.Positions, 15);  //simple way to do my copy since it only contains thearray          
                    boardMgr.UpdateBoard(ref newBoard, currmove);
                    Console.WriteLine(string.Format("I am threading at level {0}", level));
                    //Console.WriteLine("Move is from {0} to {1} erasing {2}", m.from, m.to, m.remove);
                    //Console.WriteLine("               {0}", newBoard.Positions[0]);
                    //Console.WriteLine("           {0}      {1}", newBoard.Positions[1], newBoard.Positions[2]);
                    //Console.WriteLine("       {0}      {1}      {2}", newBoard.Positions[3], newBoard.Positions[4], newBoard.Positions[5]);
                    //Console.WriteLine("   {0}     {1}       {2}      {3}", newBoard.Positions[6], newBoard.Positions[7], newBoard.Positions[8], newBoard.Positions[9]);
                    //Console.WriteLine("{0}    {1}      {2}       {3}      {4}", newBoard.Positions[10], newBoard.Positions[11], newBoard.Positions[12], newBoard.Positions[13],newBoard.Positions[14]);
                    GetMoveCount(newBoard, level);
                });
            }
            else
            {                
                ++level;
                foreach (Move m in moves)
                {                    
                    Board newBoard = new Board();
                    Array.Copy(board.Positions, newBoard.Positions, 15);  //simple way to do my copy since it only contains thearray          
                    boardMgr.UpdateBoard(ref newBoard, m);
                    //Console.WriteLine("Move is from {0} to {1} erasing {2}", m.from, m.to, m.remove);
                    //Console.WriteLine("               {0}", newBoard.Positions[0]);
                    //Console.WriteLine("           {0}      {1}", newBoard.Positions[1], newBoard.Positions[2]);
                    //Console.WriteLine("       {0}      {1}      {2}", newBoard.Positions[3], newBoard.Positions[4], newBoard.Positions[5]);
                    //Console.WriteLine("   {0}     {1}       {2}      {3}", newBoard.Positions[6], newBoard.Positions[7], newBoard.Positions[8], newBoard.Positions[9]);
                    //Console.WriteLine("{0}    {1}      {2}       {3}      {4}", newBoard.Positions[10], newBoard.Positions[11], newBoard.Positions[12], newBoard.Positions[13],newBoard.Positions[14]);
                    GetMoveCount(newBoard, level);
                }
            }
            return;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void IncBranches()
        {
            branchesChecked++;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool CheckWinner(ref Board board)
        {
            int i = 0;
           
            foreach (int k in board.Positions)
            {
                i+= k;
            }

            if (i == 1)
            {
                possibleMoves += 1;
                return true;
            }
            return false;
        }
    }
}
