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
                        Debug.Log(bestMove);
                    }
                }

            }
            board[Convert.ToInt32(bestMove)].SetComputerPlay();
            TurnManager.Instance.SetPlayerTurn();
        }

        public static Dictionary<string, int> score = new Dictionary<string, int>
        {
            {  "X", 10},
            {"O",-10},
            {"DRAW", 0}
        };



        public int Minimax(Slot[] board, int currentPlayer, Table table, bool isMax)
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
                for (int i = 0; i < 8; i++)
                {
                    if (board[i].MyValue == 0)
                    {
                        board[i].MyValue = 2;
                        var score = Minimax(board, currentPlayer + 1, table, false);
                        board[i].MyValue = 0;
                        bestValue = Mathf.Max(score, bestValue);
                    }

                }
                Debug.Log(bestValue);
                return bestValue;
            }
            else
            {
                var bestValue = int.MaxValue;
                for (int i = 0; i < 8; i++)
                {
                    if (board[i].MyValue == 0)
                    {
                        board[i].MyValue = 1;
                        var score = Minimax(board, currentPlayer + 1, table, true);
                        board[i].MyValue = 0;
                        bestValue = Mathf.Min(score, bestValue);
                    }
                }
                return bestValue;
            }
        }
    }
}