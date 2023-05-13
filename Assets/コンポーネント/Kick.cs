using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class Kick : PlayerAction
    {
        private const string animationName = "Kick";

        [Header("���͂��Ă���_���[�W���ł�܂Łi�b�j")]
        [SerializeField] private float damageInterval = 0.4f;

        [Header("�_���[�W")]
        [SerializeField] private int damage = 15;

        private float timer;
        private bool intervalCame = false;

        public override void StartAction()
        {
            player.StartAnimation(animationName);

            timer = 0f;
            intervalCame = false;
        }

        public override void UpdateAction()
        {
            if (!intervalCame && (timer >= damageInterval))
            {
                intervalCame = true;
                TryHit();
            }

            timer += Time.deltaTime;
        }

        private void TryHit()
        {
            HitArea hitArea = player.GetHitArea();
            if (hitArea.opponentIn)
            {
                hitArea.playerIn.TakeDamage(damage);
            }
        }

        public override void OnAnimationEnd()
        {
            base.OnAnimationEnd();

            player.QuitAction(this);
        }
    }
}
