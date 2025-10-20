using UnityEngine;

namespace Work.Scripts.UI
{
    public enum WeaponType
    {
        None = 0,
        Sword = 1,
        Spear,
        Axe,
        BluntInstrument
    }

    [CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public WeaponType weaponType;
        public Sprite sprite;
        public string weaponName;
        [TextArea]
        public string Tooltip;
        public int Damage;
        public int maxDurability;
        public int sizeX;
        public int sizeY;

    }
}