using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KDH.Scripts.Minigame.CircleWire
{
    public class Magnetic : MonoBehaviour
    {
        private Camera _mainCam;
    
        private void Awake()
        {
            _mainCam = Camera.main;
        }
    
        private void OnMouseDrag()
        {
            Vector3 mousePos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;

            transform.position = mousePos;
        }
    }
}