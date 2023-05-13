using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Tooltip("true�Ȃ�E�������摜���]�Bfalse�Ȃ�t")]
        [SerializeField] private bool reverseWhenLookingRight = false;

        /// <summary>
        /// false�Ȃ獶�������Ă���
        /// </summary>
        public bool lookingRight { get; private set; } = false;

        private void Update()
        {
            Look();
        }

        /// <summary>
        /// �E���ǂ���ɂ��邩�B����ɂ�������������܂�
        /// </summary>
        public void SetSide(bool isRight)
        {
            //��������ƌ�������͋t
            lookingRight = !isRight;
        }

        /// <summary>
        /// ���Ă������������
        /// </summary>
        private void Look()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            //���]����Ȃ甽�]����
            spriteRenderer.flipX = (lookingRight == reverseWhenLookingRight);
        }
    }
}
