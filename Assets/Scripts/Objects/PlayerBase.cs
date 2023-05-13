using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Header("=いじらないで=")]
        [Tooltip("trueなら右向く＝画像反転。falseなら逆")]
        [SerializeField] private bool reverseWhenLookingRight = false;

        [Header("=いじらないで=")]
        [Tooltip("初期状態でどっちのプレイヤーか")]
        [SerializeField] private bool _isRightPlayer = false;

        [Header("=いじらないで=")]
        [SerializeField] private HitArea _hitAreaLeft;

        [Header("=いじらないで=")]
        [SerializeField] private HitArea _hitAreaRight;

        private const string waitAnimation = "Waiting";

        public bool isRightPlayer { get { return _isRightPlayer; } }

        public HitArea hitAreaRight { get { return _hitAreaRight; } }
        public HitArea hitAreaLeft { get { return _hitAreaLeft; } }

        [Header("最初のHP")]
        [SerializeField] private int _hp = 100;
        public int hp { get { return _hp; } }
        public int hpMax { get; private set; }

        private PlayerAction[] actions;

        //nullなら静止中
        public PlayerAction actionCurrent { get; private set; }

        /// <summary>
        /// falseなら左を向いている
        /// </summary>
        public bool lookingRight { get; private set; } = false;

        private void Start()
        {
            //アクション読み込み
            actions = GetComponents<PlayerAction>();

            //最大hp記憶
            hpMax = hp;
        }

        private void Update()
        {
            Look();
            UpdateAction();
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

        /// <summary>
        /// Actionの動作を呼ぶ
        /// </summary>
        private void UpdateAction()
        {
            if (actionCurrent != null)
            {
                actionCurrent.UpdateAction();
            }
        }

        /// <summary>
        /// アクション可能か確認
        /// </summary>
        /// <returns>アクション開始ならtrue</returns>
        public bool AskTrigger(PlayerAction actioinAsked)
        {
            if (CheckInterruptable())
            {
                //割り込み可能→アクション開始
                actionCurrent = actioinAsked;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// アクションを止める
        /// </summary>
        public void QuitAction(PlayerAction actionQuit)
        {
            if (actionCurrent == actionQuit)
            {
                //静止状態に
                actionCurrent = null;
                StartAnimation(waitAnimation);
            }
        }

        private bool CheckInterruptable()
        {
            return ((actionCurrent == null) || (actionCurrent.interruptionAllowed));
        }

        public void StartAnimation(string stateName)
        {
            Animator animator = GetComponent<Animator>();

            if (animator.HasState(0, Animator.StringToHash(stateName)))
            {
                animator.Play(stateName);
            }
        }

        public void OnAnimationEnd()
        {
            if (actionCurrent != null)
            {
                actionCurrent.OnAnimationEnd();
            }
        }

        public float GetHPRatio()
        {
            return (float)hp / (float)hpMax;
        }

        /// <summary>
        /// 向いている方のHitArea
        /// </summary>
        public HitArea GetHitArea()
        {
            if (lookingRight)
            {
                return hitAreaRight;
            }
            else
            {
                return hitAreaLeft;
            }
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
        }
    }
}
