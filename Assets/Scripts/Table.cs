using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Table : MonoBehaviour
    {
        [Header("Computer AI")]
        [SerializeField] private ComputerAI computerAI;

        [Header("Board vars")]
        //Parent gameobject that holds all buttons childrens
        [SerializeField] private GameObject _slotsParent;

        //Array of slots
        public Slot[,] _board = new Slot[3, 3];

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
            for (int i = 0; i < 3; i++)
            {
                _board[0, i] = _slotsParent.transform.GetChild(i).GetComponent<Slot>();
            }
            for (int i = 0; i < 3; i++)
            {
                _board[1, i] = _slotsParent.transform.GetChild(i + 3).GetComponent<Slot>();
            }
            for (int i = 0; i < 3; i++)
            {
                _board[2, i] = _slotsParent.transform.GetChild(i + 6).GetComponent<Slot>();
            }
        }

        public void SetValue(Slot slot)
        {
            if (slot.MyValue == 0)
            {
                slot.SetPlayerPlay();
                StartCoroutine(WaitForComputerPlay());
            }

        }

        private IEnumerator WaitForComputerPlay()
        {
            yield return new WaitForSeconds(3);
            computerAI.AIMove();
        }

        public static Dictionary<int, string> score = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"},
            {0, "DRAW"}
        };

        private bool equals3(Slot a, Slot b, Slot c)
        {
            return a.MyValue == b.MyValue && b.MyValue == c.MyValue && a.MyValue != 0;
        }

        public string CheckVictory()
        {
            string winner = null;


            //horizontal
            for (int i = 0; i < 3; i++)
            {
                //*if player wins X
                if (equals3(_board[i, 0], _board[i, 1], _board[i, 2]))
                {
                    // Debug.Log(score[_board[i, 0].MyValue]);
                    winner = score[_board[i, 0].MyValue];
                }
            }
            //vertical
            for (int i = 0; i < 3; i++)
            {
                if (equals3(_board[0, i], _board[1, i], _board[2, i]))
                {
                    winner = score[_board[0, i].MyValue];
                }
            }
            //Diagonal

            if (equals3(_board[0, 0], _board[1, 1], _board[2, 2]))
            {
                winner = score[_board[0, 0].MyValue];
            }
            if (equals3(_board[2, 0], _board[1, 1], _board[0, 2]))
            {
                winner = score[_board[2, 0].MyValue];
            }

            int openSpots = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j].MyValue == 0)
                    {
                        openSpots++;
                    }
                }
            }

            if (winner == null && openSpots == 0)
            {
                return "DRAW";
            }
            else
            {
                return winner;
            }

        }

    }
}
