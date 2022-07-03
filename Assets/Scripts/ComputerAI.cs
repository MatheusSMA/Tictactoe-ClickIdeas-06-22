using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class ComputerAI : MonoBehaviour
    {
        public static ComputerAI Instance;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }


        public Slot AIMove(Slot[] board, int currentPlayer, Table table)
        {
            List<Slot> possibilitys = GetPositions(board);

            var bestValue = 0;
            var bestMov = 0;
            for (int i = 0; i < possibilitys.Count; i++)
            {
                board[i].MyValue = 1;
                var value = Minimax(board, currentPlayer, table);
                board[i].MyValue = 0;

                if (bestValue == 0)
                {
                    bestValue = value;
                    bestMov = i;
                }
                else if (currentPlayer == 0)
                {
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestMov = i;
                    }
                }
                else if (currentPlayer == 1)
                {
                    if (value < bestValue)
                    {
                        bestValue = value;
                        bestMov = i;
                    }
                }
            }

            return board[bestMov];
        }

        public List<Slot> GetPositions(Slot[] board)
        {
            List<Slot> emptySpaces = new List<Slot>();
            foreach (Slot slot in board)
            {
                if (slot.MyValue == 0)
                {
                    emptySpaces.Add(slot);
                }
            }
            return emptySpaces;
        }



        public int Minimax(Slot[] board, int currentPlayer, Table table)
        {
            // ref
            // jogador 0 = computador 
            // jogador 1 = pessoa

            int winner = table.CheckVictory();
            if (winner != 7)
            {
                Debug.Log("winner : " + winner);
                return winner;
            }
            currentPlayer = (currentPlayer + 1) % 2;
            List<Slot> possibilitysNew = GetPositions(board);

            var bestValue = 0;
            for (int i = 0; i < possibilitysNew.Count; i++)
            {
                board[i].MyValue = 1;
                var value = Minimax(board, currentPlayer, table);
                board[i].MyValue = 0;

                if (bestValue == 0)
                {
                    bestValue = value;
                }
                else if (currentPlayer == 0)
                {
                    if (value > bestValue)
                    {
                        bestValue = value;
                    }
                }
                else if (currentPlayer == 1)
                {
                    if (value < bestValue)
                    {
                        bestValue = value;
                    }
                }
            }

            return bestValue;
        }
    }
}