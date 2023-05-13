using UnityEngine;
using InGame.Player;

namespace InGame
{
    /// <summary>
    /// プレイヤーの相互関係を整理する
    /// </summary>
    public class PlayersManager : SingletonMonoBehaviour<PlayersManager>
    {
        [SerializeField] private PlayerBase[] players;

        private void Update()
        {
            CheckSides();
        }

        /// <summary>
        /// プレイヤー同士の向きを定める
        /// </summary>
        private void CheckSides()
        {
            Debug.Assert(players.Length == 2);

            //どちらが左か確認
            int left;
            if (players[0].transform.position.x < players[1].transform.position.x)
            {
                left = 0;
            }
            else
            {
                left = 1;
            }

            //向きを伝える
            players[left].SetSide(false);
            players[ReversePlayerIndex(left)].SetSide(true);
        }

        /// <summary>
        /// 0→1、1→0
        /// </summary>
        private int ReversePlayerIndex(int original)
        {
            if (original == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
