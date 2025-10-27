using UnityEngine;
using Work.Scripts.Entities;
using Work.Scripts.UI;

namespace Work.Scripts.Enemies
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ItemSO weaponData;

        public ItemSO GetEnemyWeapon()
        {
            return weaponData;
        }
    }
}