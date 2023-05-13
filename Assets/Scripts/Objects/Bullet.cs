using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame.Player;

namespace InGame
{
    public class Bullet : MonoBehaviour
    {
        private PlayerBase whose;
        private int damage;
        private bool goingRight;
        private float speed;

        public void Init(PlayerBase whose, int damage, bool goingRight, float speed)
        {
            this.whose = whose;
            this.damage = damage;
            this.goingRight = goingRight;
            this.speed = speed;
        }

        private void Update()
        {
            if (goingRight)
            {
                transform.position += (Vector3)(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.position += (Vector3)(Vector2.left * speed * Time.deltaTime);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerBase>() != null)
            {
                if (collision.gameObject.GetComponent<PlayerBase>() == whose)
                {
                    return;
                }

                collision.gameObject.GetComponent<PlayerBase>().TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}