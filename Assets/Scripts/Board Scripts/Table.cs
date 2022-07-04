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
        [SerializeField] private ComputerAI _computerAI;

        [Header("Board")]
        //Parent gameobject that holds all buttons childrens
        [SerializeField] private GameObject _slotsParent;
        public GameObject SlotsParent { get => _slotsParent; }

        //Matrix of slots
        private Slot[,] _board = new Slot[3, 3];
        public Slot[,] Board { get => _board; set => _board = value; }

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
                Board[0, i] = SlotsParent.transform.GetChild(i).GetComponent<Slot>();
            }
            for (int i = 0; i < 3; i++)
            {
                Board[1, i] = SlotsParent.transform.GetChild(i + 3).GetComponent<Slot>();
            }
            for (int i = 0; i < 3; i++)
            {
                Board[2, i] = SlotsParent.transform.GetChild(i + 6).GetComponent<Slot>();
            }
        }

        /// <summary>
        /// Set value for slot on component Button on unity
        /// </summary>
        /// <param name="slot"></param>
        public void SetValue(Slot slot)
        {
            //if currentplayer are human
            if (TurnManager.Instance.CurrentPlayer == 1)
            {
                slot.HumanPlay();
                CheckWinner();
                TurnManager.Instance.SetComputerTurn();
                StartCoroutine(WaitForComputerPlay());
            }
        }

        private IEnumerator WaitForComputerPlay()
        {
            yield return new WaitForSeconds(1);
            _computerAI.AIMove();
            CheckWinner();
        }

        private void CheckWinner()
        {
            var result = BoardRules();
            if (result != null)
            {
                if (result == "DRAW")
                {
                    TurnManager.Instance.SetEndGame(this);
                }
                else
                {
                    TurnManager.Instance.SetEndGame(this);
                }

            }
        }

        /// <summary>
        /// Equals the value of slot (Slot.MyValue) to a token play
        /// </summary>
        private static Dictionary<int, string> score = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "O"},
            {0, "DRAW"}
        };


        /// <summary>
        /// To compare the 3 paramters and verify if the first is not null
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool CompareSlots(Slot a, Slot b, Slot c)
        {
            return a.MyValue == b.MyValue && b.MyValue == c.MyValue && a.MyValue != 0;
        }

        /// <summary>
        /// Compare slots and returns the winner or draw
        /// </summary>
        /// <returns>winner(string)</returns>
        public string BoardRules()
        {
            string winner = null;


            //* Horizontal
            for (int i = 0; i < 3; i++)
            {
                if (CompareSlots(Board[i, 0], Board[i, 1], Board[i, 2]))
                {
                    winner = score[Board[i, 0].MyValue];
                }
            }
            //* Vertical
            for (int i = 0; i < 3; i++)
            {
                if (CompareSlots(Board[0, i], Board[1, i], Board[2, i]))
                {
                    winner = score[Board[0, i].MyValue];
                }
            }
            //* Diagonal

            if (CompareSlots(Board[0, 0], Board[1, 1], Board[2, 2]))
            {
                winner = score[Board[0, 0].MyValue];
            }
            if (CompareSlots(Board[2, 0], Board[1, 1], Board[0, 2]))
            {
                winner = score[Board[2, 0].MyValue];
            }

            //* Check freeSlots
            int emptySpaces = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j].MyValue == 0)
                    {
                        emptySpaces++;
                    }
                }
            }

            if (winner == null && emptySpaces == 0)
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



