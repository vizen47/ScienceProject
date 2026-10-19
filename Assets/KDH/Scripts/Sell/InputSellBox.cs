using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.Sell
{
    public class InputSellBox : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        void Awake()
        {
            inputField.onValueChanged.AddListener(
                (word) => inputField.text = Regex.Replace(word, @"[^0-9]", "")
            );
        }
        
        public int GetAmount()
        {
            return int.Parse(inputField.text);
        }
    }
}
