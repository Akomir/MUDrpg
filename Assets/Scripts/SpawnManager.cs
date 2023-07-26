using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemySpawnPoint; // Точка спавна боевых единиц

    // Добавляем список префабов врагов для различных вражеских сквадов на глобальной карте
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    private void Start()
    {
        // Спавним боевые единицы на указанной позиции с помощью enemyUnitPrefab
        //SpawnUnitsAtPosition(enemySpawnPoint.position);
    }

    // Метод для спавна боевых единиц на указанной позиции с заданным префабом врага
    public void SpawnUnitsAtPosition(Vector2 spawnPosition, GameObject selectedEnemyPrefab)
    {
        // Получаем нужный префаб врага
        GameObject enemyPrefab = selectedEnemyPrefab;

        // Ищем компонент Squad в дочерних объектах выбранного префаба врага
        Squad squad = enemyPrefab.GetComponentInChildren<Squad>();

        if (squad != null)
        {
            // Передаём префаб в метод SpawnWarUnits, чтобы спавнить выбранного врага
            SpawnWarUnits(enemyPrefab, spawnPosition, squad);
        }
        else
        {
            Debug.LogError("Selected enemy prefab does not have the Squad script attached.");
        }
    }

    private void SpawnWarUnits(GameObject enemyPrefab, Vector2 spawnPosition, Squad squad)
    {
        foreach (var unitData in squad.warUnits)
        {
            int count = unitData.useRandomCount ?
                Random.Range(unitData.minRandomCount, unitData.maxRandomCount + 1) :
                unitData.exactCount;

            for (int i = 0; i < count; i++)
            {
                Instantiate(unitData.warUnitPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
