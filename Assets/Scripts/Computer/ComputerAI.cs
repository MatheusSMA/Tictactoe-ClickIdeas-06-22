using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class ComputerAI : MonoBehaviour
    {
        [SerializeField] private Table table;

        /// <summary>
        /// Do the best AI movement on table
        /// </summary>        
        public void AIMove()
        {
            var bestValue = int.MinValue;
            var bestMove = 0;
            var bestMoveTwo = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table.Board[i, j].MyValue == 0)
                    {
                        table.Board[i, j].MyValue = 2;
                        var score = Minimax(table.Board, 0, false);
                        table.Board[i, j].MyValue = 0;
                        if (score > bestValue)
                        {
                            bestValue = score;
                            bestMove = i;
                            bestMoveTwo = j;
                        }
                    }
                }

            }
            table.Board[bestMove, bestMoveTwo].ComputerPlay();
            TurnManager.Instance.SetPlayerTurn();
        }

        /// <summary>
        /// To recive token (X or O) and give the points for minimax
        /// </summary>
        private static Dictionary<string, int> score = new Dictionary<string, int>
        {
            {  "X", -10},
            {"O", 10},
            {"DRAW", 0}
        };


        public int Minimax(Slot[,] board, int depth, bool isComputer)
        {
            // references
            // player 0 = computer 
            // player 1 = human

            string winner = table.BoardRules();
            if (winner != null)
            {
                return score[winner];
            }

            if (isComputer)
            {
                var bestValue = int.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j].MyValue == 0)
                        {
                            board[i, j].MyValue = 2;
                            var score = Minimax(board, depth + 1, false);
                            board[i, j].MyValue = 0;
                            if (score > bestValue)
                            {
                                bestValue = score;
                            }
                        }

                    }
                }
                return bestValue;
            }
            else
            {
                var bestValue = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j].MyValue == 0)
                        {
                            board[i, j].MyValue = 1;
                            var score = Minimax(board, depth + 1, true);
                            board[i, j].MyValue = 0;
                            if (score < bestValue)
                            {
                                bestValue = score;
                            }
                        }
                    }
                }
                return bestValue;
            }
        }
    }
}