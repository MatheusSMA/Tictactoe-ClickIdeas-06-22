using System.Collections.Generic;
using UnityEngine;

namespace Clickideias.TicTacToe
{
    public struct ComputerMove
    {
        public int score;
        public int point;

    }

    public class ComputerBrain : MonoBehaviour
    {
        public Table table;
        private int[,] winCombos;
        private List<ComputerMove> pcMoves = new List<ComputerMove>();
        public List<GameObject> emptyPoints;
        public Slot[] testboard;
        public int count;

        void Start()
        {
            winCombos = table.winCombos;
        }

        // public ComputerMove Minimax()
        // {
        //     emptyPoints = new List<GameObject>();
        //     //TODO VERIFICAR DPS
        //     Slot[] board = new Slot[9]; System.Array.Copy(table._board, board, 9);
        //     pcMoves = new List<ComputerMove>();
        //     return GetBestMove(board, 2, 0);
        // }

        // private ComputerMove GetBestMove(Slot[] board, int slot, int index)
        // {
        //     //terminal states
        //     ComputerMove terminalMove = new ComputerMove();
        //     //human player wins
        //     if (CheckVictorySim(board, 1) == true)
        //     {
        //         terminalMove.score = -10;
        //         terminalMove.point = index;
        //         Debug.Log($"Terminal Human point : {terminalMove.point}");
        //         return terminalMove;
        //     }
        //     //computer wins
        //     else if (CheckVictorySim(board, 2) == true)
        //     {
        //         terminalMove.score = 10;
        //         terminalMove.point = index;
        //         Debug.Log($"Terminal Computer point : {terminalMove.point}");
        //         return terminalMove;
        //     }
        //     //aqui é emptyPoint sem o count
        //     else if (emptyPoints.Count <= 0)
        //     {
        //         terminalMove.score = 0;
        //         terminalMove.point = index;
        //         Debug.Log($"Terminal draw point : {terminalMove.point}");
        //         return terminalMove;
        //     }
        //     else
        //     {
        //         if (count >= 1)
        //         {
        //             count++;
        //             terminalMove.score = -50;
        //             terminalMove.point = index;
        //             Debug.Log("Terminal no win point: " + terminalMove.point);
        //             return terminalMove;
        //         }
        //         else
        //         {
        //             count++;
        //         }
        //     }

        //     //Recursive function is called at each iteraction
        //     for (int i = 0; i < emptyPoints.Count; i++)
        //     {
        //         ComputerMove move = new ComputerMove();

        //         if (slot == 2)
        //         {
        //             board[System.Convert.ToUInt32(emptyPoints[i].name)].GetComponent<Slot>().MyValue = slot;
        //             slot = 1;
        //             index = System.Convert.ToInt32(emptyPoints[i].name);
        //             var result = GetBestMove(board, 2, index);
        //             move.score = result.score;
        //             move.point = result.point;
        //             this.pcMoves.Add(move);
        //         }
        //         if (slot == 1)
        //         {
        //             board[System.Convert.ToUInt32(emptyPoints[i].name)].GetComponent<Slot>().MyValue = slot;
        //             slot = 2;
        //             index = System.Convert.ToInt32(emptyPoints[i].name);
        //             var result = GetBestMove(board, 1, index);
        //             move.score = result.score;
        //             move.point = result.point;
        //             this.pcMoves.Add(move);
        //         }
        //         // board[System.Convert.ToUInt32(emptyPoints[i].name)].GetComponent<Slot>().MyValue = ;

        //         Debug.Log($"point: {System.Convert.ToInt32(emptyPoints[i].name)}");
        //     }

        //     foreach (var item in this.pcMoves)
        //     {
        //         Debug.Log(item.score);
        //     }

        //     //Logic for picking the best move for current player

        //     var bestMove = 0;

        //     if (slot == 2)
        //     {
        //         int bestScore = -10000;
        //         for (int i = 0; i < pcMoves.Count; i++)
        //         {
        //             if (pcMoves[i].score > bestScore)
        //             {
        //                 bestMove = i;
        //                 bestScore = pcMoves[i].score;
        //             }
        //         }
        //     }
        //     else if (slot == 1)
        //     {
        //         int bestScore = 10000;
        //         for (int i = 0; i < pcMoves.Count; i++)
        //         {
        //             if (pcMoves[i].score < bestScore)
        //             {
        //                 bestMove = i;
        //                 bestScore = pcMoves[i].score;
        //             }
        //         }
        //     }
        //     Debug.Log("Count of: " + pcMoves.Count);
        //     Debug.Log("Best point of: " + pcMoves[bestMove].point + "score of: " + pcMoves[bestMove].score);

        //     //Zero the count value
        //     count = 0;
        // }

        private bool CheckVictorySim(Slot[] board, int slot)
        {
            testboard = board;
            int piece = slot;
            for (int i = 0; i < 8; i++)
            {
                if (board[winCombos[i, 0]].GetComponent<Slot>().MyValue == piece && board[winCombos[i, 1]].GetComponent<Slot>().MyValue == piece && board[winCombos[i, 2]].GetComponent<Slot>().MyValue == piece)
                {
                    Debug.Log("PLAYER WINS");
                    return true;
                }
            }
            return false;
        }


    }
}