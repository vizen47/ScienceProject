using KDH.Scripts.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace KDH.Scripts.System
{
    public class Setting : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider master;
        [SerializeField] private Slider sfx;
        [SerializeField] private Slider bgm;

        public void SetMaster()
        {
            mixer.SetFloat("Master", Mathf.Log10(master.value) * 20);
        }

        public void SetSFX()
        {
            mixer.SetFloat("SFX", Mathf.Log10(sfx.value) * 20);
        }

        public void SetBGM()
        {
            mixer.SetFloat("BGM", Mathf.Log10(bgm.value) * 20);
        }
        
        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                UIManager.Instance.ActiveSettingUI();
            }
        }

        public void GameOver()
        {
            Application.Quit();
        }
    }
}
