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


        public void AIMove(Slot[] board, int currentPlayer)
        {
            List<Slot> possibilitys = new List<Slot>();
            possibilitys = GetPositions(board);
            var bestValue = 0;
            var bestMov = 0;
            for (int i = 0; i < possibilitys.Count; i++)
            {
                possibilitys[i].SetComputerPlay();
                var value = 0;
                possibilitys[i].MyValue = 0;

                if (bestValue == 0)
                {
                    value = bestValue;
                    i = bestMov;
                }
                else if (currentPlayer == 2)
                {
                    if (value > bestValue)
                    {
                        value = bestValue;
                        bestMov = i;
                    }
                }
                else if (currentPlayer == 1)
                {
                    if (value < bestValue)
                    {
                        value = bestValue;
                        bestMov = i;
                    }
                }

            }
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

        public void Minimax(Slot[] board, int currentPlayer, Table table)
        {
            table.CheckVictory();
            currentPlayer = (currentPlayer + 1) % 2;
        }
    }
}