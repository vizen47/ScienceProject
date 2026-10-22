using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.Sell
{
    public class InputSellBox : MonoBehaviour
    {
        [field: SerializeField] public TMP_InputField InputField { get; private set; }

        void Awake()
        {
            InputField.onValueChanged.AddListener(
                (word) => InputField.text = Regex.Replace(word, @"[^0-9]", "")
            );
        }
        
        public int GetAmount()
        {
            if (string.IsNullOrWhiteSpace(InputField.text))
                return 1;
            
            return int.Parse(InputField.text);
        }
    }
}
