using UnityEngine;
using UnityEngine.InputSystem;

namespace KDH.Scripts.Minigame.Solenoid
{
    public class ElectricMachine : MonoBehaviour
    {
        [SerializeField] private Solenoid solenoid;
        private Camera _mainCam;

        void Awake()
        {
            _mainCam = Camera.main;
        }
        
        private void OnMouseDrag()
        {
            if (!solenoid.CanElectronic) return;
            
            Vector3 mousePos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;

            transform.position = mousePos;
        }
    }
}
