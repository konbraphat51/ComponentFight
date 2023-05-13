using UnityEngine;

namespace InGame.Player
{
    /// <summary>
    /// �A�N�V�����R���|�[�l���g��base�N���X
    /// </summary>
    public abstract class PlayerAction : MonoBehaviour
    {
        [Header("���̃{�^��")] 
        [SerializeField] private KeyCode keyLeft = KeyCode.Space;
        [Header("�E�̃{�^��")] 
        [SerializeField] private KeyCode keyRight = KeyCode.Space;

        protected KeyCode triggerKey;
        public bool interruptionAllowed { get; protected set; } = false;

        protected PlayerBase player { get; private set; }

        protected virtual void Start()
        {
            //�{�v���C���[���擾
            player = GetComponent<PlayerBase>();

            //�ϐ�������
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
        /// �g���K�[���ꂽ���m�F
        /// </summary>
        private void CheckKey()
        {
            if (Input.GetKeyDown(triggerKey))
            {
                Trigger();
            }
        }

        /// <summary>
        /// �A�N�V�����J�n�ł��邩PlayerBase�Ɋm�F
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
