using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame.Player;

namespace InGame
{
    public class HitArea : MonoBehaviour
    {
        [SerializeField] private PlayerBase whose;

        public bool opponentIn { get; private set; }
        public PlayerBase playerIn { get; private set; }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if ((collision.gameObject.GetComponent<PlayerBase>() != null) 
                && (collision.gameObject.GetComponent<PlayerBase>() != whose))
            {
                opponentIn = true;
                playerIn = collision.gameObject.GetComponent<PlayerBase>();
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if ((collision.gameObject.GetComponent<PlayerBase>() != null)
                && (collision.gameObject.GetComponent<PlayerBase>() != whose))
            {
                opponentIn = false;
            }
        }
    }
}