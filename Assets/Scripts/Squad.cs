using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    [SerializeField]
    private Sprite pictureSq; // Картинка отряда

    [System.Serializable]
    public class WarUnitData
    {
        public GameObject warUnitPrefab; // Префаб WarUnit
        public bool useRandomCount; // Использовать случайное количество
        public int exactCount; // Точное количество воинов, если не используется случайное
        public int minRandomCount; // Минимальное случайное количество
        public int maxRandomCount; // Максимальное случайное количество
    }

    [SerializeField]
    public List<WarUnitData> warUnits = new List<WarUnitData>(); // Список данных о WarUnit

    private void Start()
    {
        // Получаем родительский объект
        GameObject parentObject = transform.parent.gameObject;

        // Устанавливаем тег текущего объекта таким же, как у родительского объекта
        gameObject.tag = parentObject.tag;

        // Делаем текущий объект дочерним объектом родительского объекта
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
