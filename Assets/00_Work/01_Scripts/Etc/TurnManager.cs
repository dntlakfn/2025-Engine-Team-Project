using System.Collections;
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
            GetBattleEnemies();
            StartPlayerTurn();
        }

        public void BattleEnd()
        {

        }

        public void GetBattleEnemies()
        {
            enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None);

        }

        public void StartPlayerTurn()
        {
            OnPlayerTurnStart?.Invoke();

        }

        private IEnumerator PlayEnemiesTurn()
        {
            foreach(EnemyController enemy in enemies)
            {
                enemy.StartAction();
                yield return new WaitForSeconds(4.5f);
            }
            StartPlayerTurn();
            
        }

        public void StartEnemyTurn()
        {
            OnEnemyTurnStart?.Invoke();
            StartCoroutine(PlayEnemiesTurn());
        }


    }
}