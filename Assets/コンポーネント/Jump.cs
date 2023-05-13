using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class Jump : PlayerAction
    {
        private const string animationName = "Jump";

        //y速度がこれ以下になると着地判定
        private const float landedVelocity = 0.01f;

        [Header("ジャンプ力")]
        [SerializeField] private float jumpPower = 400f;

        [Header("左右移動スピード")]
        [SerializeField] private float horizontalSpeed = 10f;

        protected override void Start()
        {
            base.Start();

            interruptionAllowed = false;
        }

        public override void StartAction()
        {
            player.StartAnimation(animationName);  
            _Jump();
        }

        public override void UpdateAction()
        {
            //左右移動
            MoveHorizontal();
        }

        private void MoveHorizontal()
        {
            if((GetComponent<RunLeft>() != null) && (Input.GetKey(GetComponent<RunLeft>().TriggerKey)))
            {
                MoveLeft();
            }

            if ((GetComponent<RunRight>() != null) && (Input.GetKey(GetComponent<RunRight>().TriggerKey)))
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            transform.position += (Vector3)(Vector2.left * horizontalSpeed * Time.deltaTime);
        }

        private void MoveRight()
        {
            transform.position += (Vector3)(Vector2.right * horizontalSpeed * Time.deltaTime);
        }

        private void _Jump()
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

            rigidbody2D.AddForce(transform.up * jumpPower);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Floor>() != null)
            {
                //床と衝突
                if (player.actionCurrent == this)
                {
                    player.QuitAction(this);
                }
            }
        }
    }
}