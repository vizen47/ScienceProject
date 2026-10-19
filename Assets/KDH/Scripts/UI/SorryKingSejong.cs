using TMPro;
using UnityEngine;

namespace KDH.Scripts.UI
{
    public class SorryKingSejong : MonoBehaviour
    {
        private TMP_InputField _inputField;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        void Update()
        {
            if (_inputField.isFocused)
            {
                Input.imeCompositionMode = IMECompositionMode.Off; // 한글을 막음. 영어와 숫자까지.
            }
            else
            {
                Input.imeCompositionMode = IMECompositionMode.Auto; // 평소와 같은 입력 방식을 사용.
            }
        }
    }
}