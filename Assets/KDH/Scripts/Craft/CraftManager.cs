using System;
using System.Resources;
using KDH.Scripts.Item;
using KDH.Scripts.Resource;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Craft
{
    public class CraftManager : MonoBehaviour
    {
        public static CraftManager Instance;

        [SerializeField] private Transform minigameTrm;
        
        public ItemSO CurrentItem { get; private set; }

        private event Action MinigameStart;
        private event Action MinigameSurrender;
        private event Action MinigameEnd;

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            MinigameStart += UIManager.Instance.StartMinigame;
            MinigameSurrender += UIManager.Instance.SurrenderMinigame;
            MinigameEnd += UIManager.Instance.EndMinigame;
        }

        private void OnDestroy()
        {
            MinigameStart -= UIManager.Instance.StartMinigame;
            MinigameSurrender -= UIManager.Instance.SurrenderMinigame;
            MinigameEnd -= UIManager.Instance.EndMinigame;
        }

        public void SetCurrentItem(ItemSO data)
        {
            CurrentItem = data;
        }

        public void StartMinigame()
        {
            if (CurrentItem == null) return;
            
            Instantiate(CurrentItem.minigamePrefab, minigameTrm);
            
            MinigameStart?.Invoke();

            UIManager.Instance.CanCostChange = false;
            
            ResourceDataManager.Instance.Coin -= (int)CurrentItem.currentCost;
            ResourceDataManager.Instance.OnCoinChanged?.Invoke();
        }

        public void SurrenderMinigame()
        {
            MinigameSurrender?.Invoke();
            Destroy(minigameTrm.GetChild(0).gameObject);

            UIManager.Instance.CanCostChange = true;
        }
        
        public void EndMinigame()
        {
            MinigameEnd?.Invoke();
            Destroy(minigameTrm.GetChild(0).gameObject);
            
            UIManager.Instance.CanCostChange = true;
        }
    }
}
