using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Work.Scripts.Entities;

namespace Work.Scripts.UI
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private ItemSO fist;

        [SerializeField] private Image weaponImage;
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private TextMeshProUGUI weaponDamage;
        [SerializeField] private TextMeshProUGUI weaponDurability;
        [SerializeField] private TextMeshProUGUI weaponTooltip;
        [SerializeField] private Image weaponDurabilityBar;

        private WeaponData equipedWeapon;

        private void Awake()
        {
            // 테스트용 초기화 (나중에 지워라)
            ResetUI();
        }

        public void SetUI(WeaponData weapon)
        {
            equipedWeapon = weapon;
            weaponImage.sprite = weapon.weaponSO.sprite;
            weaponName.text = weapon.weaponSO.weaponName;
            weaponDamage.text = $"Damage : {weapon.weaponSO.Damage.ToString()}";
            weaponDurability.text = $"{weapon.weaponSO.maxDurability}/{weapon.durability}";
            weaponDurabilityBar.fillAmount = (float)weapon.durability / (float)weapon.weaponSO.maxDurability;
            weaponTooltip.text = weapon.weaponSO.Tooltip;
        }

        public void SetDurabilityUI(int current)
        {
            equipedWeapon.durability = current;
            weaponDurability.text = $"{equipedWeapon.durability}/{equipedWeapon.weaponSO.maxDurability}";
            weaponDurabilityBar.fillAmount = (float)equipedWeapon.durability / (float)equipedWeapon.weaponSO.maxDurability;
        }

        public void ResetUI()
        {
            equipedWeapon = new WeaponData();
            equipedWeapon.weaponSO = fist;
            equipedWeapon.durability = fist.maxDurability;
            SetUI(equipedWeapon);
        }

        public void ChangeWeaponUI(ItemUI item)
        {
            WeaponData equiped = item.GetItem();
            item.SetItemUI(equipedWeapon);
            SetUI(equiped);
        }

    }
}