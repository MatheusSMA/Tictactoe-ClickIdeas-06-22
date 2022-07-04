using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class ComputerAI : MonoBehaviour
    {
        public Table table;


        public void AIMove()
        {
            var bestScore = int.MinValue;
            var bestMove = 0;
            var bestMoveTwo = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table._board[i, j].MyValue == 0)
                    {
                        table._board[i, j].MyValue = 2;
                        var score = Minimax(table._board, 0, false);
                        table._board[i, j].MyValue = 0;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i;
                            bestMoveTwo = j;
                        }
                    }
                }

            }
            table._board[bestMove, bestMoveTwo].SetComputerPlay();
            TurnManager.Instance.SetPlayerTurn();
        }

        public static Dictionary<string, int> score = new Dictionary<string, int>
        {
            {  "X", -10},
            {"O", 10},
            {"DRAW", 0}
        };



        public int Minimax(Slot[,] board, int depth, bool isMax)
        {
            // ref
            // jogador 0 = computador 
            // jogador 1 = pessoa

            string winner = table.CheckVictory();
            if (winner != null)
            {
                return score[winner];
            }

            if (isMax)
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