using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private int value;
        public int Value { get => value; set => this.value = value; }
    }
}