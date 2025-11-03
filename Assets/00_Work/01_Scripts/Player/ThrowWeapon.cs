using UnityEngine;
using Work.Scripts.Entities;
using Work.Scripts.UI;

namespace Work.Scripts.Players
{
    public class ThrowWeapon : MonoBehaviour
    {
        private WeaponData weaponData;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private DamageText damageText;
        public Transform canvas;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("aa");
            if (collision.transform.parent.TryGetComponent(out EntityHealth entity))
            {
                entity.HP -= weaponData.weaponSO.Damage;
                damageText.Show(weaponData.weaponSO.Damage, entity.transform.position + (Vector3.up * 4) - (Vector3.forward * 4), canvas);
                Destroy(gameObject);
            }
        }

        private void SetSprite(Sprite sprite)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        public void Throw(WeaponData weapon)
        {
            rb = GetComponent<Rigidbody2D>();
            weaponData = weapon;
            SetSprite(weapon.weaponSO.sprite);
            rb.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        }
    }
}