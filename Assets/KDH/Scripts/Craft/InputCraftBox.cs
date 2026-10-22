using System.Text.RegularExpressions;
using KDH.Scripts.UI;
using TMPro;
using UnityEngine;

namespace KDH.Scripts.Craft
{
    public class InputCraftBox : MonoBehaviour
    {
        private TMP_InputField _inputField;

        void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();

            _inputField.onValueChanged.AddListener((word) => _inputField.text = Regex.Replace(word, @"[^0-9]", "")
            );
        }
        
        public int GetAmount()
        {
            if (string.IsNullOrWhiteSpace(_inputField.text))
                return 1;
            
            return int.Parse(_inputField.text);
        }
    }
}
