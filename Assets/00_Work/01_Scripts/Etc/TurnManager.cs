
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Work.Scripts.Enemies;


namespace Work.Scripts.Etc
{
    public class TurnManager : MonoBehaviour, IBattle
    {
        public UnityEvent OnPlayerTurnStart;
        public UnityEvent OnEnemyTurnStart;
        private EnemyController[] enemies;

        public void BattleStart()
        {
            StartPlayerTurn();
        }

        public void BattleEnd()
        {

        }


        public void StartPlayerTurn()
        {
            OnPlayerTurnStart?.Invoke();

        }

        private IEnumerator PlayEnemiesTurn()
        {
            yield return new WaitForSeconds(4.5f);
            foreach (EnemyController enemy in enemies)
            {
                if(enemy._myHealth.isDead) continue;

                enemy.StartAction(); 
                yield return new WaitForSeconds(4.5f);
            }
            StartPlayerTurn();
            
        }

        public void StartEnemyTurn()
        {
            OnEnemyTurnStart?.Invoke();
            List<EnemyController> t = new List<EnemyController>();
            foreach(var enemy in BattleManager.Instance.enemies)
            {
                t.Add(enemy);
            }
            enemies = t.ToArray();
            Debug.Log(enemies.Length);
            StartCoroutine("PlayEnemiesTurn");
        }

        public void StopTurn()
        {
            StopCoroutine("PlayEnemiesTurn");
        }


    }
}