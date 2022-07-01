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
        private Button[] slots = new Button[9];



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
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = _slotsParent.transform.GetChild(i).GetComponent<Button>();
            }
        }

        public void SetValue(Button btn)
        {

        }
    }
}
