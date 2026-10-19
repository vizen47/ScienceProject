using System.Collections.Generic;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Minigame.CircleWire
{
    public class DeadZone : MonoBehaviour
    {
        public List<GameObject> irons;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (irons.Contains(other.gameObject)) return;

            if (other.TryGetComponent(out IronHolder _))
            {
                irons.Add(other.gameObject);
                other.transform.gameObject.SetActive(false);
            }

            if (irons.Count >= 300)
            {
                UIManager.Instance.SuccessUI.SetActive(true);
            }
        }
    }
}
