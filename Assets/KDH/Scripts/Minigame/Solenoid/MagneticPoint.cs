using System;
using System.Collections.Generic;
using KDH.Scripts.Minigame.CircleWire;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Minigame.Solenoid
{
    public class MagneticPoint : MonoBehaviour
    {
        [SerializeField] private int clipCount;
        public Stack<Collider2D> Clips { get; private set; } = new();
        
        void CheckWin()
        {
            if (Clips.Count >= clipCount)
                UIManager.Instance.SuccessUI.SetActive(true);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IronHolder clip))
            {
                if (clip.TryGetComponent(out Collider2D item))
                {
                    Clips.Push(item);

                    CheckWin();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IronHolder clip))
            {
                if (clip.TryGetComponent(out Collider2D item))
                    Clips.Pop();
            }
        }
    }
}