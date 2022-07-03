using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class ComputerAI : MonoBehaviour
    {

        public void AIMove(Slot[] board, Table table)
        {
            // var possibilitys = GetPositions(board);
            var bestScore = int.MinValue;
            object bestMove = null;

            for (int i = 0; i < 8; i++)
            {
                if (board[i].MyValue == 0)
                {
                    board[i].MyValue = 2;
                    var score = Minimax(board, 0, table, false);
                    board[i].MyValue = 0;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }

            }
            board[Convert.ToInt32(bestMove)].MyValue = 2;
            TurnManager.Instance.SetPlayerTurn();

            //     board[i].MyValue = currentPlayer;
            //     var value = Minimax(board, currentPlayer, table);
            //     board[i].MyValue = 0;

            //     if (bestValue == 0)
            //     {
            //         bestValue = value;
            //         bestMov = i;
            //     }
            //     else if (currentPlayer == 0)
            //     {
            //         if (value > bestValue)
            //         {
            //             bestValue = value;
            //             bestMov = i;
            //         }
            //     }
            //     else if (currentPlayer == 1)
            //     {
            //         if (value < bestValue)
            //         {
            //             bestValue = value;
            //             bestMov = i;
            //         }
            //     }
            // }

            // return board[bestMov];
        }

        // public List<Slot> GetPositions(Slot[] board)
        // {
        //     var emptySpaces = new List<Slot>();
        //     foreach (Slot slot in board)
        //     {
        //         if (slot.MyValue == 0)
        //         {
        //             emptySpaces.Add(slot);
        //         }
        //     }
        //     return emptySpaces;
        // }

        public static Dictionary<string, int> score = new Dictionary<string, int>
        {
            {"DRAW", 0},
            {  "X", 10},
            {"O",-10}
        };



        public int Minimax(Slot[] board, int currentPlayer, Table table, bool isMax)
        {
            // ref
            // jogador 0 = computador 
            // jogador 1 = pessoa

            var winner = table.CheckVictory();
            if (winner != null)
            {
                Debug.Log("winner : " + winner);
                return score[winner];
            }

            var bestValue = int.MinValue;
            if (isMax)
            {

                for (int i = 0; i < 8; i++)
                {
                    if (board[i].MyValue == 0)
                    {
                        board[i].MyValue = 2;
                        var score = Minimax(board, 0, table, false);
                        board[i].MyValue = 0;
                        if (score > bestValue)
                        {
                            bestValue = score;
                        }
                    }

                }
                return bestValue;
            }
            else
            {

                for (int i = 0; i < 8; i++)
                {
                    if (board[i].MyValue == 0)
                    {
                        board[i].MyValue = 1;
                        var score = Minimax(board, 0, table, true);
                        board[i].MyValue = 0;
                        if (score < bestValue)
                        {
                            bestValue = score;
                        }
                    }
                }
                return bestValue;
            }
            //   board[bestMov] =  board[bestMov].MyValue = 2;



            // currentPlayer = (currentPlayer + 1) % 2;
            // var possibilitysNew = GetPositions(board);
            // var bestValue = 0;

            // for (int i = 0; i < 8; i++)
            // {
            //     board[i].MyValue = currentPlayer;
            //     var value = Minimax(board, currentPlayer, table);
            //     board[i].MyValue = 0;

            //     if (bestValue == 0)
            //     {
            //         bestValue = value;
            //     }
            //     else if (currentPlayer == 0)
            //     {
            //         if (value > bestValue)
            //         {
            //             bestValue = value;
            //         }
            //     }
            //     else if (currentPlayer == 1)
            //     {
            //         if (value < bestValue)
            //         {
            //             bestValue = value;
            //         }
            //     }
            // }

            // return bestValue;
        }
    }
}