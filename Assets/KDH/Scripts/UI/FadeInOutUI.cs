using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.UI
{
    public class FadeInOutUI : MonoBehaviour
    {
        public static FadeInOutUI Instance;

        void Awake()
        {
            Instance = this;
        }
        
        [SerializeField] private Image[] blackLine;
        [SerializeField] private RectTransform[] startPoints;
        [SerializeField] private RectTransform[] endPoints;
        [SerializeField] private float relateTime, reachTime;

        public void FadeIn()
        {
            Sequence seq = DOTween.Sequence();
            
            for (int i = 0; i < blackLine.Length; i++)
            {
                blackLine[i].rectTransform.position = startPoints[i].position;
            }
            
            seq = DOTween.Sequence();

            for (int i = 0; i < blackLine.Length; i++)
            {
                seq.Join(blackLine[i].rectTransform.DOMoveX(960, reachTime)).SetEase(Ease.Linear);
                seq.AppendInterval(relateTime);
            }
        }

        public void FadeOut()
        {
            Sequence seq = DOTween.Sequence();
            
            for (int i = 0; i < blackLine.Length; i++)
            {
                seq.Join(blackLine[i].rectTransform.DOMoveX(endPoints[i].position.x, reachTime)).SetEase(Ease.Linear);
                seq.AppendInterval(relateTime);
            }
        }
    }
}
