using System;
using System.Threading.Tasks;
using KDH.Scripts.Item;
using KDH.Scripts.Resource;
using KDH.Scripts.Sounds;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Craft
{
    public class CraftManager : MonoBehaviour
    {
        public static CraftManager Instance;

        [SerializeField] private Transform minigameTrm;
        
        public ItemSO CurrentItem { get; private set; }
        public int MadeItemAmount { get; private set; }
        
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

        public async void StartMinigame()
        {
            if (CurrentItem == null) return;
        
            FadeInOutUI.Instance.FadeIn();

            await Task.Delay(500);
        
            FadeInOutUI.Instance.FadeOut();

            SoundManager.Instace.PlayBGM(CurrentItem.gameBgm);
            
            Instantiate(CurrentItem.minigamePrefab, minigameTrm);
        
            MinigameStart?.Invoke();

            UIManager.Instance.CanCostChange = false;

            int value = 0;

            // 계산식에서 오류가 있는 듯
            if (ResourceDataManager.Instance.Coin >= (int)(CurrentItem.currentCost * CurrentItem.personnelExpenses) * UIManager.Instance.InputCraftBox.GetAmount())
            {
                value = (int)(CurrentItem.currentCost * CurrentItem.personnelExpenses) * UIManager.Instance.InputCraftBox.GetAmount();
                MadeItemAmount = UIManager.Instance.InputCraftBox.GetAmount();
            }
            else
            {
                for (int i = 0; i < UIManager.Instance.InputCraftBox.GetAmount(); i++)
                {
                    if (ResourceDataManager.Instance.Coin < (int)(CurrentItem.currentCost * CurrentItem.personnelExpenses) * i)
                    {
                        value = (int)(CurrentItem.currentCost * CurrentItem.personnelExpenses) * (i - 1);
                        MadeItemAmount = i - 1;
                        break;
                    }
                }
            }
            // 계산식에서 오류가 있는 듯
        
            ResourceDataManager.Instance.Coin -= value;
            ResourceDataManager.Instance.OnCoinChanged?.Invoke();
        
            // FadeInOutUI.Instance.FadeOut();
        }

        public async void SurrenderMinigame()
        {
            FadeInOutUI.Instance.FadeIn();
            MinigameSurrender?.Invoke();
            await Task.Delay(500);
            
            Destroy(minigameTrm.GetChild(0).gameObject);
            
            UIManager.Instance.CanCostChange = true;

            FadeInOutUI.Instance.FadeOut();
        }
        
        public async void EndMinigame()
        {
            
            FadeInOutUI.Instance.FadeIn();
            MinigameEnd?.Invoke();
            await Task.Delay(500);
            
            Destroy(minigameTrm.GetChild(0).gameObject);
            
            UIManager.Instance.CanCostChange = true;
            
            FadeInOutUI.Instance.FadeOut();
        }
    }
}
