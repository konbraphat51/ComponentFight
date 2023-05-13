using UnityEngine;
using UnityEngine.UI;
using InGame.Player;


namespace InGame.UI
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private PlayerBase player;

        private void Update()
        {
            Image image = GetComponent<Image>();

            image.fillAmount = player.GetHPRatio();
        }
    }
}
