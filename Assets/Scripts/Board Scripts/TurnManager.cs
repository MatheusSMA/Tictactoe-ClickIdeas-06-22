using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

namespace Clickideias.TicTacToe
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;

        [SerializeField] private ComputerAI _computerAI;

        [Header("'X' and 'O' sprites")]
        [SerializeField] private Sprite _xSprite;
        [SerializeField] private Sprite _oSprite;
        public Sprite XSprite { get => _xSprite; }
        public Sprite OSprite { get => _oSprite; }

        [Header("Title text")]
        //Only for title purpose
        [SerializeField] private TextMeshProUGUI turnText;
        [SerializeField] private TextMeshProUGUI winnerText;

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        //Currentplayer = 0 -> Computer
        //Currentplayer = 1 -> player


        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            //For singleton
            Instance = this;
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            int chance = Random.Range(1, 9);
            if (chance % 2 == 0)
            {
                SetPlayerTurn();

            }
            else
            {
                SetComputerTurn();
                StartCoroutine(WaitForComputerPlay());
            }
        }

        private IEnumerator WaitForComputerPlay()
        {
            yield return new WaitForSeconds(1);
            _computerAI.AIMove();
        }

        public void SetComputerTurn()
        {
            turnText.text = "Computer turn!";
            currentPlayer = 0;
        }
        public void SetPlayerTurn()
        {
            turnText.text = "Player turn!";
            currentPlayer = 1;
        }

        /// <summary>
        /// Shows winner text and desactive all buttons
        /// </summary>
        /// <param name="table"></param>
        public void SetEndGame(Table table)
        {
            winnerText.gameObject.SetActive(true);
            if (table.BoardRules() != "DRAW")
            {
                winnerText.text = $"Computer wins!";
            }
            else
            {
                winnerText.text = "Tie!";
            }


            for (int i = 0; i < 9; i++)
            {
                table.SlotsParent.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }

    }
}
