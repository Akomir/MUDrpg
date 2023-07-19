using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Префаб игрока")]
    private GameObject playerPrefab;

    [SerializeField]
    [Tooltip("Префаб врага")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("Точки спавна для игрока на глобальной карте")]
    private Transform[] playerSpawnPoints;

    [SerializeField]
    [Tooltip("Точки спавна для врагов на глобальной карте")]
    private Transform[] enemySpawnPoints;

    [SerializeField]
    [Tooltip("Общее количество врагов для спауна")]
    private int numberOfEnemies;

    private List<GameObject> activeEnemies = new List<GameObject>(); // Список активных врагов

    void Start()
    {
        // Проверяем, есть ли префаб игрока и точки спавна для игрока
        if (playerPrefab != null && playerSpawnPoints != null && playerSpawnPoints.Length > 0)
        {
            // Спауним игрока на глобальной карте
            Instantiate(playerPrefab, playerSpawnPoints[0].position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Укажите префаб игрока и точки спавна для игрока!");
        }

        // Проверяем, есть ли префаб врага и точки спавна для врагов
        if (enemyPrefab != null && enemySpawnPoints != null && enemySpawnPoints.Length > 0)
        {
            // Спауним врагов на глобальной карте
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int randPoint = Random.Range(0, enemySpawnPoints.Length);
                GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPoints[randPoint].position, Quaternion.identity);
                activeEnemies.Add(newEnemy); // Добавляем нового врага в список активных врагов
            }
        }
        else
        {
            Debug.LogError("Укажите префаб врага и точки спавна для врагов!");
        }
    }
}