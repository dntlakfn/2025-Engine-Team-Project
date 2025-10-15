using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.UI;

namespace Work.Scripts.Entities
{
    public struct WeaponData
    {
        public ItemSO weaponSO;

        public int durability;

    }

    public class Weapon : MonoBehaviour
    {
        public UnityEvent<int> OnDurablityChanged;
        public UnityEvent OnBreakWeapon;
        private WeaponType itemType;
        private Sprite sprite;
        private int damage;
        private int maxDurability;
        private int durability;
        public int Durability
        {
            get
            {
                return durability;
            }
            set
            {
                durability = value;

                if(durability != value) OnDurablityChanged?.Invoke(durability/maxDurability);

                if(durability <= 0)
                {
                    OnBreakWeapon?.Invoke();
                }
            }
        }

        public void Initialize(ItemUI itemUI)
        {
            WeaponData item = itemUI.GetItem();
            itemType = item.weaponSO.weaponType;
            sprite = item.weaponSO.sprite;
            damage = item.weaponSO.Damage;
            maxDurability = item.weaponSO.maxDurability;
            durability = item.durability;
        }

    }
}