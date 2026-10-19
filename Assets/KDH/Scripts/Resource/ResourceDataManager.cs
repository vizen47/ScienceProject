using System;
using System.Collections.Generic;
using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using KDH.Scripts.UI;
using UnityEngine;

namespace KDH.Scripts.Resource
{
    public class ResourceDataManager : MonoBehaviour
    {
        public static ResourceDataManager Instance;

        public ItemSO CurrentItemData { get; set; }
        
        [SerializeField] private int startCoin = 500;
        
        public Action OnCoinChanged;
        
        private int _coin;

        public int Coin
        {
            get => _coin;
            set
            {
                if (value >= 0)
                {
                    _coin = value;
                }
            }
        }

        public readonly Dictionary<ItemSO, int> ResourceDict = new();

        private readonly int _currentItemCost;
        
        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Coin = startCoin;
            InitSellCost();
        }

        public void GetResource(int count)
        {
            if (!ResourceDict.TryAdd(CraftManager.Instance.CurrentItem, count))
            {
                ResourceDict[CraftManager.Instance.CurrentItem] += count;
            }
        }

        public void UseResourceForCoin()
        {
            if (!ResourceDict.TryAdd(CurrentItemData, UIManager.Instance.InputTextBox.GetAmount()))
            {
                int value = Mathf.Min(ResourceDict[CurrentItemData], UIManager.Instance.InputTextBox.GetAmount());
                ResourceDict[CurrentItemData] -= value;
            }

            Coin += (int)CurrentItemData.tmpCost;
            
            OnCoinChanged?.Invoke();
        }
        
        void InitSellCost()
        {
            foreach (var sellCost in UIManager.Instance.SellCostAmountText)
            {
                if (sellCost.transform.parent.TryGetComponent(out ItemDataHandler data))
                    data.ItemData.Init();
            }
        }
    }
}