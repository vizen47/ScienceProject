using KDH.Scripts.Minigame.StraightWire;
using UnityEngine;
using UnityEngine.InputSystem;

public class Block : MonoBehaviour
{
    public enum blockType { red, yellow, blue, cyan }
    [field: SerializeField] public blockType CurrentType { get; private set; }
    [field: SerializeField] public GameObject Line { get; private set; }

    public bool isCleared;
    
    private StraightWire _parent;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _parent = GetComponentInParent<StraightWire>();
    }
    public void OnMouseDown()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0; 
        _parent.StartPos = _mainCamera.ScreenToWorldPoint(mouseScreenPos);
    }
    
    public void OnMouseUp()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;
        _parent.EndPos = _mainCamera.ScreenToWorldPoint(mouseScreenPos);
        
        _parent.CalcDrag(_parent.StartPos, _parent.EndPos);
    }
}
