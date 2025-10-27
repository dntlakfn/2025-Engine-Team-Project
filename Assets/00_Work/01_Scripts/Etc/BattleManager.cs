using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Work.Scripts.Enemies;

namespace Work.Scripts.Etc
{

    public class BattleManager : MonoBehaviour
    {

        public static BattleManager Instance;
        [SerializeField] private AttackCamera attackCamera;


        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            BattleStart();
        }

        public void BattleStart()
        {

            foreach (var a in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (a is IBattle component)
                {
                    Debug.Log(component);
                    component.BattleStart();
                }

            }
        }

        public void BattleEnd()
        {

        }

        public void StageClear()
        {

        }
    }
}