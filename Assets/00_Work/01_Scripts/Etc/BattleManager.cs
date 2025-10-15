using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Work.Scripts.Etc
{
    public class BattleManager : MonoBehaviour
    {
        public Action OnResetBattle;
        private void Awake()
        {
            foreach (var a in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                IBattle component = a as IBattle;
                if (component != null)
                {
                    OnResetBattle += component.Initialize;
                }

            }
        }
    }
}