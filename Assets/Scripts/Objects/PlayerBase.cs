using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Tooltip("trueなら右向く＝画像反転。falseなら逆")]
        [SerializeField] private bool reverseWhenLookingRight = false;

        /// <summary>
        /// falseなら左を向いている
        /// </summary>
        public bool lookingRight { get; private set; } = false;

        private void Update()
        {
            Look();
        }

        /// <summary>
        /// 右左どちらにいるか。これにより向く向きが定まる
        /// </summary>
        public void SetSide(bool isRight)
        {
            //いる方向と見る方向は逆
            lookingRight = !isRight;
        }

        /// <summary>
        /// 見ている方向を向く
        /// </summary>
        private void Look()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            //反転するなら反転する
            spriteRenderer.flipX = (lookingRight == reverseWhenLookingRight);
        }
    }
}
