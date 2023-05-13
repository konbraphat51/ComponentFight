using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [Header("=������Ȃ���=")]
        [Tooltip("true�Ȃ�E�������摜���]�Bfalse�Ȃ�t")]
        [SerializeField] private bool reverseWhenLookingRight = false;

        [Header("=������Ȃ���=")]
        [Tooltip("������Ԃłǂ����̃v���C���[��")]
        [SerializeField] private bool _isRightPlayer = false;

        private const string waitAnimation = "Waiting";

        public bool isRightPlayer { get { return _isRightPlayer; } }

        private PlayerAction[] actions;

        //null�Ȃ�Î~��
        private PlayerAction actionCurrent;

        /// <summary>
        /// false�Ȃ獶�������Ă���
        /// </summary>
        public bool lookingRight { get; private set; } = false;

        private void Start()
        {
            //�A�N�V�����ǂݍ���
            actions = GetComponents<PlayerAction>();
        }

        private void Update()
        {
            Look();
            UpdateAction();
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

        /// <summary>
        /// Action�̓�����Ă�
        /// </summary>
        private void UpdateAction()
        {
            if (actionCurrent != null)
            {
                actionCurrent.UpdateAction();
            }
        }

        /// <summary>
        /// �A�N�V�����\���m�F
        /// </summary>
        /// <returns>�A�N�V�����J�n�Ȃ�true</returns>
        public bool AskTrigger(PlayerAction actioinAsked)
        {
            if (CheckInterruptable())
            {
                //���荞�݉\���A�N�V�����J�n
                actionCurrent = actioinAsked;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// �A�N�V�������~�߂�
        /// </summary>
        public void QuitAction(PlayerAction actionQuit)
        {
            if (actionCurrent == actionQuit)
            {
                //�Î~��Ԃ�
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
    }
}
