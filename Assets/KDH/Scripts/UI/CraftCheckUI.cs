using UnityEngine;

namespace KDH.Scripts.UI
{
    public class CraftCheckUI : MonoBehaviour
    {
        public void OnEnable()
        {
            UIManager.Instance.SetBuyCosts();
            UIManager.Instance.CanCostChange = false;
        }

        private void OnDisable()
        {
            UIManager.Instance.CanCostChange = true;
        }
    }
}
