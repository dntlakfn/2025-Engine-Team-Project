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
        [SerializeField] private CinemachineCamera mainCam;
        

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
            // 카메라 활성화, 진동
            gameObject.SetActive(true);
            impulseSource.GenerateImpulse();
            LayerMask enemyLayer = LayerMask.GetMask(LayerMask.LayerToName(enemyObj.layer));

            // 플레이어랑 맞은 적, 무기, 데미지택스트만 보이게 카메라 레이어 교체
            Animator enemy = enemyObj.GetComponentInChildren<Animator>();
            Camera.main.cullingMask = all ^ (LayerMask.GetMask("Player", "DamageText", "Weapon") | enemyLayer);
            _camera.cullingMask = (LayerMask.GetMask("Player", "DamageText", "Weapon") | enemyLayer);
            // 플레이어, 적 애니메이션 슬로우 모션
            player.speed = 0.1f;
            enemy.speed = 0.1f;

            // 블러 적용
            if(volume.profile.TryGet(out DepthOfField blur))
                blur.active = true;

            // 카메라 회전
            transform.DORotate(new Vector3(0,0,-3f), duration);
            mainCam.transform.DORotate(new Vector3(0,0,-3f), duration);

            // 카메라 이동
            mainCam.transform.DOMove(new Vector3(0.12f, 0.4f, -10), 0.5f);
            _camera.transform.DOMove(new Vector3(0.12f, 0.4f, -10), 0.5f);

            // 카메라 확대
            _camera.DOOrthoSize(4.5f, duration);
            DOTween.To(
                () => 5f,                                    // 현재 값 getter
                x => mainCam.Lens.OrthographicSize = x,      // 변경된 값을 적용할 setter
                4.5f,                                          // 목표 값
                0.5f                                         // 트윈 지속 시간
            );

            // 원상복구
            DOVirtual.DelayedCall(duration, () =>
            {
                mainCam.transform.DOMove(new Vector3(0f, 0f, -10), 0.5f);
                _camera.transform.DOMove(new Vector3(0f, 0f, -10), 0.5f);

                transform.DORotate(Vector3.zero, 0.5f);
                mainCam.transform.DORotate(Vector3.zero, 0.5f);

                _camera.DOOrthoSize(5f, 0.5f);
                DOTween.To(
                () => 4.5f,                                    // 현재 값 getter
                x => mainCam.Lens.OrthographicSize = x,      // 변경된 값을 적용할 setter
                5f,                                          // 목표 값
                0.5f                                         // 트윈 지속 시간
                );

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

        public void CamShutDown()
        {
            gameObject.SetActive(false);
            Camera.main.cullingMask = all;
        }
    }
}