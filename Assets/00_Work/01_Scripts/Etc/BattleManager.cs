using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Work.Scripts.Etc
{

    public class BattleManager : MonoBehaviour
    {

        private void Awake()
        {
            BattleStart();
        }

        private void BattleStart()
        {
            foreach (var a in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (a is IBattle component)
                {
                    Debug.Log(component);
                    component.Initialize();
                }

            }
        }
    }
}