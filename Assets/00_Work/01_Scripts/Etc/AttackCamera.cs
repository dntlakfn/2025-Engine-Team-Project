using DG.Tweening;
using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Work.Scripts.Etc
{
    public class AttackCamera : MonoBehaviour
    {
        
        [SerializeField] private float duration;
        [SerializeField] private LayerMask all;
        [SerializeField] private CinemachineImpulseSource impulseSource;
        private Camera _camera;
        

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        [ContextMenu("Test")]
        public void Test()
        {
        }

        public void MoveAction(Animator player, GameObject enemyObj, Volume volume)
        {
            gameObject.SetActive(true);
            impulseSource.GenerateImpulse();
            LayerMask enemyLayer = LayerMask.GetMask(LayerMask.LayerToName(enemyObj.layer));

            Animator enemy = enemyObj.GetComponentInChildren<Animator>();
            Camera.main.cullingMask = all ^ (LayerMask.GetMask("Player", "DamageText", "Weapon") | enemyLayer);
            _camera.cullingMask = (LayerMask.GetMask("Player", "DamageText", "Weapon") | enemyLayer);
            player.speed = 0.1f;
            enemy.speed = 0.1f;
            if(volume.profile.TryGet(out DepthOfField blur))
                blur.active = true;

            transform.DORotate(new Vector3(0,0,-3f), duration);
            _camera.DOOrthoSize(4.5f, duration);
            DOVirtual.DelayedCall(duration, () =>
            {

                transform.DORotate(Vector3.zero, 0.5f);
                _camera.DOOrthoSize(5f, 0.5f);
                player.speed = 1f;
                enemy.speed = 1f;
                blur.active = false;
                DOVirtual.DelayedCall(0.5f, () =>
                {
                    gameObject.SetActive(false);
                    Camera.main.cullingMask = all;
                });
            });
            
        }
    }
}