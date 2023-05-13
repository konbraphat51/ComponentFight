using UnityEngine;

namespace InGame.Player
{
    /// <summary>
    /// アクションコンポーネントのbaseクラス
    /// </summary>
    public abstract class PlayerAction : MonoBehaviour
    {
        [Header("左のボタン")] 
        [SerializeField] private KeyCode keyLeft = KeyCode.Space;
        [Header("右のボタン")] 
        [SerializeField] private KeyCode keyRight = KeyCode.Space;

        protected KeyCode triggerKey;
        public bool interruptionAllowed { get; protected set; } = false;

        protected PlayerBase player { get; private set; }

        protected virtual void Start()
        {
            //本プレイヤーを取得
            player = GetComponent<PlayerBase>();

            //変数初期化
            if (player.isRightPlayer)
            {
                triggerKey = keyRight;
            }
            else
            {
                triggerKey = keyLeft;
            }
        }

        protected virtual void Update()
        {
            CheckKey();
        }

        /// <summary>
        /// トリガーされたか確認
        /// </summary>
        private void CheckKey()
        {
            if (Input.GetKeyDown(triggerKey))
            {
                Trigger();
            }
        }

        /// <summary>
        /// アクション開始できるかPlayerBaseに確認
        /// </summary>
        private void Trigger()
        {
            if (player.AskTrigger(this))
            {
                StartAction();
            }
        }

        public abstract void StartAction();
        public abstract void UpdateAction();

        public virtual void OnAnimationEnd() { }
    }
}
