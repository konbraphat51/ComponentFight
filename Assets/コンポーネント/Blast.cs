using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class Blast : PlayerAction
    {
        private const string animationName = "Blast";

        [Header("=������Ȃ���=")]
        [SerializeField] private Bullet bulletPrefab;

        [Header("�_���[�W")]
        [SerializeField] private int damage;

        [Header("�e�̃X�s�[�h")]
        [SerializeField] private float bulletSpeed = 15f;

        public override void StartAction()
        {
            //����
            Bullet bullet = Instantiate(bulletPrefab.gameObject, transform.parent).GetComponent<Bullet>();
            bullet.Init(player, damage, player.lookingRight, bulletSpeed);
            bullet.gameObject.transform.position = player.GetHitArea().transform.position;

            player.StartAnimation(animationName);
        }

        public override void UpdateAction()
        {
            
        }

        public override void OnAnimationEnd()
        {
            base.OnAnimationEnd();
            player.QuitAction(this);
        }
    }
}
