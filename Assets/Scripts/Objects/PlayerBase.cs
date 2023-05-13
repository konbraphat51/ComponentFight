using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Tooltip("true‚È‚ç‰EŒü‚­‰æ‘œ”½“]Bfalse‚È‚ç‹t")]
        [SerializeField] private bool reverseWhenLookingRight = false;

        /// <summary>
        /// false‚È‚ç¶‚ğŒü‚¢‚Ä‚¢‚é
        /// </summary>
        public bool lookingRight { get; private set; } = false;

        private void Update()
        {
            Look();
        }

        /// <summary>
        /// ‰E¶‚Ç‚¿‚ç‚É‚¢‚é‚©B‚±‚ê‚É‚æ‚èŒü‚­Œü‚«‚ª’è‚Ü‚é
        /// </summary>
        public void SetSide(bool isRight)
        {
            //‚¢‚é•ûŒü‚ÆŒ©‚é•ûŒü‚Í‹t
            lookingRight = !isRight;
        }

        /// <summary>
        /// Œ©‚Ä‚¢‚é•ûŒü‚ğŒü‚­
        /// </summary>
        private void Look()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            //”½“]‚·‚é‚È‚ç”½“]‚·‚é
            spriteRenderer.flipX = (lookingRight == reverseWhenLookingRight);
        }
    }
}
