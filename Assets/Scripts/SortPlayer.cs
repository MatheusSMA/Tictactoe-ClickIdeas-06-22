using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class SortPlayer : MonoBehaviour
    {
        private int playerStartTurn = 0;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            Sort();
        }

        private void Sort()
        {
            int turn = Random.Range(1, 100);
            int aux = Random.Range(1, 10);
            Debug.Log(turn % aux);
            if (turn % aux == 0)
            {
                Debug.Log("Vez do player");
            }
            else
            {
                Debug.Log("Vez da máquina");
            }

        }
    }
}
