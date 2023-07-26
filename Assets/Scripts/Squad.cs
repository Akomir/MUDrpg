using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    [SerializeField]
    private Sprite pictureSq; // �������� ������

    [System.Serializable]
    public class WarUnitData
    {
        public GameObject warUnitPrefab; // ������ WarUnit
        public bool useRandomCount; // ������������ ��������� ����������
        public int exactCount; // ������ ���������� ������, ���� �� ������������ ���������
        public int minRandomCount; // ����������� ��������� ����������
        public int maxRandomCount; // ������������ ��������� ����������
    }

    [SerializeField]
    public List<WarUnitData> warUnits = new List<WarUnitData>(); // ������ ������ � WarUnit

    private void Start()
    {
        // �������� ������������ ������
        GameObject parentObject = transform.parent.gameObject;

        // ������������� ��� �������� ������� ����� ��, ��� � ������������� �������
        gameObject.tag = parentObject.tag;

        // ������ ������� ������ �������� �������� ������������� �������
        transform.SetParent(parentObject.transform);
    }

    public void SpawnWarUnits(Vector2 spawnPosition)
    {
        foreach (var unitData in warUnits)
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
