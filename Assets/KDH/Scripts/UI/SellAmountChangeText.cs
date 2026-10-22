using UnityEngine;

namespace KDH.Scripts.UI
{
    public class SellAmountChangeText : MonoBehaviour
    {
        private void OnEnable()
        {
            UIManager.Instance.CorouTargetAmountText();
        }
    }
}