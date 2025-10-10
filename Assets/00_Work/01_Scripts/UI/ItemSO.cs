using UnityEngine;

namespace Work.Scripts.UI
{
    public enum ItemType
    {
        None = 0,
        Sword = 1,
        Spear,
        BluntInstrument
    }

    public struct Stat
    {
        public int Damage;
        public int Durability;
    }

    [CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public ItemType itemType;
        public Sprite sprite;
        [field:SerializeField] public Stat stat;
        public int sizeX;
        public int sizeY;
    }
}