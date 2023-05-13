using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Player
{
    public class RunRight : PlayerAction {
        private const string animationName = "RunRight";

        [Header("走るスピード")]
        [SerializeField] private float runningSpeed = 10f;

        public override void StartAction()
        {
            player.StartAnimation(animationName);
        }

        public override void UpdateAction()
        {
            DisableFlip();
            Run();
            DetectQuit();
        }

        private void DisableFlip()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.flipX = false;
        }

        private void Run()
        {
            transform.position += (Vector3)(Vector2.right * runningSpeed * Time.deltaTime);
        }

        private void DetectQuit()
        {
            if (!Input.GetKey(triggerKey))
            {
                player.QuitAction(this);
            }
        }
    }
}
