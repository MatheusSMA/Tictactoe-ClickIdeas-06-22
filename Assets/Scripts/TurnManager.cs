using UnityEngine;
using TMPro;
namespace Clickideias.TicTacToe
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;

        [Header("'X' and 'O' sprites")]
        //Computer simbol: O
        //Player simbol: X        
        [SerializeField] private Sprite _xSprite;
        [SerializeField] private Sprite _oSprite;
        public Sprite XSprite { get => _xSprite; }
        public Sprite OSprite { get => _oSprite; }

        [Header("Title text")]
        //Only for title purpose
        [SerializeField] private TextMeshProUGUI turnText;

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }


        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }

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
            currentPlayer = 1;
        }
        private void SetComputerTurn()
        {
            Debug.Log("Vez da máquina");
            turnText.text = "Computer turn!";
            currentPlayer = 2;
        }

    }
}
