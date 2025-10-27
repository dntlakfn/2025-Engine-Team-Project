using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.Etc;
using Work.Scripts.UI;

namespace Work.Scripts.Entities
{
    public struct WeaponData
    {
        public ItemSO weaponSO;

        public int durability;

    }

    public class PlayerWeapon : MonoBehaviour, IBattle
    {
        public UnityEvent<int> OnDurablityChanged;
        public UnityEvent OnBreakWeapon;
        [SerializeField] private ItemSO fist;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private WeaponData weaponData;
        public int Durability
        {
            get
            {
                return weaponData.durability;
            }
            set
            {
                if(weaponData.durability != value) OnDurablityChanged?.Invoke(value);
                weaponData.durability = value;

                if (weaponData.durability <= 0)
                {
                    OnBreakWeapon?.Invoke();
                    BattleStart();
                }
            }
        }

        public void BattleStart()
        {
            weaponData = new WeaponData();
            weaponData.weaponSO = fist;
            weaponData.durability = fist.maxDurability;
            spriteRenderer.sprite = null;
        }

        public void SetWeapon(ItemUI itemUI)
        {
            weaponData = itemUI.GetItem();
            spriteRenderer.sprite = weaponData.weaponSO.sprite;
        }

        public WeaponData GetWeaponData()
        {
            return weaponData;
        }

        public void BattleEnd()
        {
            
        }
    }
}