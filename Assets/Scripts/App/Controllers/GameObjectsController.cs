using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowGame
{
    public class GameObjectsController : MonoBehaviour
    {
        [Header("Player Settings")]
        [Range(1, 5)]
        public int playerHealth;
        [Range(1, 2)]
        public int playerDamage;
        [Range(1, 2)]
        public int scoreMultiply;

        [Space]
        [Header("Enemy Settings")]
        [Range(1, 2)]
        public int enemyHealthMyltiply;
        [Range(1, 2)]
        public int enemyDamage;
        [Range(1,4)]
        public float enemySpeed;

        [Space]
        [Header("In GameSettings")]
        public int countOfWinScore;
        public int scoreFromSmallEnemy;
        public int scoreFromAverageEnemy;
        public int scoreFromLargeEnemy;
        [Range(0.1f, 5)]
        public float snowBallReloadSpeed;
        [Range(0.5f, 3)]
        public float enemyAtackSpeed;
    }
}