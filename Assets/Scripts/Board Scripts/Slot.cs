using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Slot : MonoBehaviour
    {

        //Sprite for X and O for plays
        [SerializeField] private Sprite _currentSprite;


        [Header("Value of each slot")]
        [SerializeField] private int _myValue;
        public int MyValue { get => _myValue; set => _myValue = value; }


        /// <summary>
        /// To add the sprite of human and turn off button
        /// </summary>
        public void HumanPlay()
        {
            _currentSprite = TurnManager.Instance.XSprite;
            Image spriteImage = GetComponentsInChildren<Image>()[1];
            spriteImage.color = new Color(spriteImage.color.r, spriteImage.color.g, spriteImage.color.b, 1);
            spriteImage.sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;

            //Value for "X"
            MyValue = 1;
        }

        /// <summary>
        /// To add the sprite of computer and turn off button
        /// </summary>
        public void ComputerPlay()
        {
            _currentSprite = TurnManager.Instance.OSprite;
            Image spriteImage = GetComponentsInChildren<Image>()[1];
            spriteImage.color = new Color(spriteImage.color.r, spriteImage.color.g, spriteImage.color.b, 1);
            spriteImage.sprite = _currentSprite;
            this.GetComponent<Button>().interactable = false;

            //Value for "O"
            MyValue = 2;
        }

    }
}