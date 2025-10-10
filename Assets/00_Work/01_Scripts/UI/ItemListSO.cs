using System.Collections.Generic;
using UnityEngine;

namespace Work.Scripts.UI
{
    [CreateAssetMenu(menuName ="SO/ItemList")]
    public class ItemListSO : ScriptableObject
    {
        public List<ItemSO> itemList;

        public ItemSO GetRandomItem()
        {
            int rand = Random.Range(0, itemList.Count);
            return itemList[rand];
        }
    }
}