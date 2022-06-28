using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clickideias.TicTacToe
{
    public class Table : MonoBehaviour
    {
        //Gameobject "pai" que segura todos os elementos do array
        [SerializeField] private GameObject slotsParent;
        private Button[] slots = new Button[9];

        private void Start()
        {
            FillArray();
        }

        /// <summary>
        /// Preenche o array com o componente "Button" da unity 
        /// </summary>
        private void FillArray()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = slotsParent.transform.GetChild(i).GetComponent<Button>();
            }
        }

        public void SetValue(Button btn)
        {

        }
    }
}
