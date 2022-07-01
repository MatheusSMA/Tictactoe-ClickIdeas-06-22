using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public struct ComputerMove
    {
        public int score;
        public int point;
        public ComputerMove(int _score, int _point)
        {
            score = _score;
            point = _point;
        }
    }

    public class ComputerBrain : MonoBehaviour
    {
        public Table table;
        private int[,] winCombos;
        private List<ComputerMove> pcMoves = new List<ComputerMove>();
        public List<GameObject> emptyPoints;
        public int count;

        void Start()
        {
            winCombos = table.winCombos;
        }

        public ComputerMove Minimax()
        {
            // emptyPoints = new List<GameObject>(emptyPoints)
            //TODO VERIFICAR DPS
            Slot[] board = new Slot[9]; System.Array.Copy(table._board, board, 9);
            pcMoves = new List<ComputerMove>();
            return GetBestMove(board, /*slot*/, 0);
        }

        private ComputerMove GetBestMove(Slot[] board, Slot slot, int index)
        {
            //terminal states
            ComputerMove terminalMove = new ComputerMove();
            //human player wins
            if (CheckVictorySim(board, GameManager.Player1Piece) == true)
            {
                terminalMove.score = -10;
                terminalMove.point = index;
                Debug.Log($"Terminal Human point : {terminalMove.point}");
                return terminalMove;
            }
            //computer wins
            else if (CheckVictorySim(board, GameManager.Player2Piece) == true)
            {
                terminalMove.score = 10;
                terminalMove.point = index;
                Debug.Log($"Terminal Computer point : {terminalMove.point}");
                return terminalMove;
            }
            //draw
            else if (emptyPoints <= 0)
            {
                terminalMove.score = 0;
                terminalMove.point = index;
                Debug.Log($"Terminal draw point : {terminalMove.point}");
                return terminalMove;
            }
            else
            {
                if (count >= 1)
                {
                    count++;
                    terminalMove.score = -50;
                    terminalMove.point = index;
                    Debug.Log("Terminal no win point: " + terminalMove.point);
                    return terminalMove;
                }
                else
                {
                    count++;
                }
            }
        }

    }
}