using UnityEngine;
using TMPro;
namespace Clickideias.TicTacToe
{
    public class TurnManager : MonoBehaviour
    {
        //Computer simbol: X
        //Player simbol: O

        //Sprite for X and O for plays
        [SerializeField] private Sprite _xSprite;
        [SerializeField] private Sprite _oSprite;

        //Only for title purpose
        [SerializeField] private TextMeshProUGUI turnText;

        private bool computerStartTurn;
        public bool ComputerStartTurn { get => computerStartTurn; }


        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            int chance = Random.Range(1, 9);
            // System.Random random = new System.Random();
            // int chanceTwo = random.Next(1, 10);
            if (chance % 2 == 0)
            {
                SetPlayerTurn();

            }
            else
            {
                SetComputerTurn();
            }
        }

        private void SetPlayerTurn()
        {
            Debug.Log("Vez da do player");
            turnText.text = "Player turn!";
            computerStartTurn = false;
        }
        private void SetComputerTurn()
        {
            Debug.Log("Vez da máquina");
            turnText.text = "Computer turn!";
            computerStartTurn = true;
        }

    }
}
