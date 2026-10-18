using UnityEngine;

namespace KDH.Scripts.Item
{
    public class ItemDataHandler : MonoBehaviour
    {
        [field: SerializeField] public ItemSO ItemData { get; private set; }
    }
}