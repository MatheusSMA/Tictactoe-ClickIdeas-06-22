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



    }
}