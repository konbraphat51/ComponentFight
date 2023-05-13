using UnityEngine;
using InGame.Player;

namespace InGame
{
    /// <summary>
    /// �v���C���[�̑��݊֌W�𐮗�����
    /// </summary>
    public class PlayersManager : SingletonMonoBehaviour<PlayersManager>
    {
        [SerializeField] private PlayerBase[] players;

        private void Update()
        {
            CheckSides();
        }

        /// <summary>
        /// �v���C���[���m�̌������߂�
        /// </summary>
        private void CheckSides()
        {
            Debug.Assert(players.Length == 2);

            //�ǂ��炪�����m�F
            int left;
            if (players[0].transform.position.x < players[1].transform.position.x)
            {
                left = 0;
            }
            else
            {
                left = 1;
            }

            //������`����
            players[left].SetSide(false);
            players[ReversePlayerIndex(left)].SetSide(true);
        }

        /// <summary>
        /// 0��1�A1��0
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
