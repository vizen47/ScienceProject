using KDH.Scripts.Sounds;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KDH.Scripts.Minigame.Solenoid
{
    public class Grab : MonoBehaviour
    {
        [Header("Grab Settings")] 
        [SerializeField] private float detectRange;
        [SerializeField] private LayerMask whatIsSolenoid;
        
        [SerializeField] private Collider2D electricPoint;
        [SerializeField] private Solenoid solenoid;
        [SerializeField] private SFXDataSO connected, disconnected;
        private Camera _mainCam;

        void Awake()
        {
            _mainCam = Camera.main;
        }

        void Start()
        {
            solenoid.PointEffector.enabled = solenoid.CanElectronic;
        }
        
        private void OnMouseDrag()
        {
            Vector3 mousePos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;

            transform.position = mousePos;
        }

        private void OnMouseUp()
        {
            solenoid.CanElectronic = Physics2D.OverlapCircle(electricPoint.transform.position, detectRange, whatIsSolenoid);

            if (solenoid.CanElectronic)
                SoundManager.Instace.PlaySound(connected);
            else
                SoundManager.Instace.PlaySound(disconnected);
            
            solenoid.PointEffector.enabled = solenoid.CanElectronic;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(electricPoint.transform.position, detectRange);
        }
    }
}
