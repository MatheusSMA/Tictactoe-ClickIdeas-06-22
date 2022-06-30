using UnityEngine;

namespace Clickideias.TicTacToe
{
    public class TurnManager : MonoBehaviour
    {
        //.Make Turn manager in one singleton
        public static TurnManager Instance;

        void Awake()
        {
            Instance = this;
        }
    }
}