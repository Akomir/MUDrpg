using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemySpawnPoint; // ����� ������ ������ ������

    // ��������� ������ �������� ������ ��� ��������� ��������� ������� �� ���������� �����
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    private void Start()
    {
        // ������� ������ ������� �� ��������� ������� � ������� enemyUnitPrefab
        //SpawnUnitsAtPosition(enemySpawnPoint.position);
    }

    // ����� ��� ������ ������ ������ �� ��������� ������� � �������� �������� �����
    public void SpawnUnitsAtPosition(Vector2 spawnPosition, GameObject selectedEnemyPrefab)
    {
        // �������� ������ ������ �����
        GameObject enemyPrefab = selectedEnemyPrefab;

        // ���� ��������� Squad � �������� �������� ���������� ������� �����
        Squad squad = enemyPrefab.GetComponentInChildren<Squad>();

        if (squad != null)
        {
            // ������� ������ � ����� SpawnWarUnits, ����� �������� ���������� �����
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
