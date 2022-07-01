using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Slot : MonoBehaviour
    {
        //Sprite for X and O for plays
        [SerializeField] private Sprite _currentSprite;
        [SerializeField] private int _myValue = 0;

        public int MyValue { get => _myValue; set => _myValue = value; }

        public void SetPlayerPlay()
        {
            MyValue = 1;
            _currentSprite = TurnManager.Instance.XSprite;
            transform.GetChild(0).GetComponent<Image>().sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;
        }
        public void SetComputerPlay()
        {
            MyValue = 2;
            _currentSprite = TurnManager.Instance.OSprite;
            transform.GetChild(0).GetComponent<Image>().sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;
        }
    }
}