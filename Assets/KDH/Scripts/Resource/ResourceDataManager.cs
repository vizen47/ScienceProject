using System;
using System.Collections.Generic;
using KDH.Scripts.Craft;
using KDH.Scripts.Item;
using UnityEngine;

namespace KDH.Scripts.Resource
{
    public class ResourceDataManager : MonoBehaviour
    {
        public static ResourceDataManager Instance;

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
        }

        public void GetResource(int count)
        {
            if (!ResourceDict.TryAdd(CraftManager.Instance.CurrentItem, count))
            {
                ResourceDict[CraftManager.Instance.CurrentItem] += count;
            }
        }
    }
}