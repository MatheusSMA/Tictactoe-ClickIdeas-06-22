using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Table : MonoBehaviour
    {
        //Parent gameobject that holds all buttons childrens
        [SerializeField] private GameObject _slotsParent;

        //Array of slots
        public Slot[] _board = new Slot[9];

        public int[,] winCombos = new int[8, 3]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {6,4,2},
        };

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            FillArray();
        }

        /// <summary>
        /// Fill arrays with "Button" component of unity 
        /// </summary>
        private void FillArray()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = _slotsParent.transform.GetChild(i).GetComponent<Slot>();
            }
        }

        public void SetValue(Slot slot)
        {
            slot.SetPlayerPlay();

            for (int i = 0; i < 8; i++)
            {
                //*if player
                if (_board[winCombos[i, 0]].MyValue == 1 && _board[winCombos[i, 1]].MyValue == 1 && _board[winCombos[i, 2]].MyValue == 1)
                {
                    Debug.Log("Player Wins");
                }
                //*else computer
            }

        }
    }
}
