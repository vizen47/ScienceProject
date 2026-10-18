using System;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Sell
{
    public class Sell : MonoBehaviour
    {
        private void OnEnable()
        {
            UIManager.Instance.SetResourceAmountText();
        }
    }
}