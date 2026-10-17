using UnityEngine;

namespace KDH.Scripts.Minigame.CircleWire
{
    public class IronHolder : MonoBehaviour
    {
        private Vector2 _offset = new Vector2(0.05f, 0.15f);
        private Vector3 _myPos;
        private Vector3 _minVec;
        private Vector3 _maxVec;
        private Camera _mainCam;
        
        void Awake()
        {
            _mainCam = Camera.main;

            if (_mainCam == null) return;
            
            _minVec = _mainCam.ViewportToWorldPoint(new Vector2(0, 0));
            _maxVec = _mainCam.ViewportToWorldPoint(new Vector2(1, 1));
        }
        
        private void Update()
        {            
            if (_mainCam == null) return;

            _myPos.x = Mathf.Clamp(transform.position.x, _minVec.x + _offset.x, _maxVec.x - _offset.x);
            _myPos.y = Mathf.Clamp(transform.position.y, _minVec.y + _offset.x, _maxVec.y - _offset.y);
            
            transform.position = _myPos;
        }
    }
}