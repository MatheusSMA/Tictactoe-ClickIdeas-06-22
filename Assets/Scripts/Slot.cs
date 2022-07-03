using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Slot : MonoBehaviour
    {
        //Computer simbol: O = 2
        //Player simbol: X  = 1
        //Free space = 0                     

        //Sprite for X and O for plays
        [SerializeField] private Sprite _currentSprite;

        [Header("Value of each slot")]

        [SerializeField] private int _myValue;
        public int MyValue { get => _myValue; set => _myValue = value; }

        public void SetPlayerPlay()
        {
            _currentSprite = TurnManager.Instance.XSprite;
            transform.GetChild(0).GetComponent<Image>().sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;

            MyValue = 1;
            //Set next play for computer
            TurnManager.Instance.SetComputerTurn();
        }

        public void SetComputerPlay()
        {
            _currentSprite = TurnManager.Instance.OSprite;
            transform.GetChild(0).GetComponent<Image>().sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;

            MyValue = 2;
            //Set next play for player
            TurnManager.Instance.SetPlayerTurn();
        }

    }
}