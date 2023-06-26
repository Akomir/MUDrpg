using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость перемещения
    public float moveInterval = 1f; // Интервал перемещения (в секундах)
    public List<string> targetLocationIdentifiers; // Список искомых значений locationIdentifier

    private Transform currentTarget; // Текущая целевая локация
    private bool isMoving = false; // Флаг перемещения
    private float moveTimer = 0f; // Таймер для контроля интервала перемещения

    private void Start()
    {
        // Находим все объекты с компонентом LocationTrigger
        LocationTrigger[] locationTriggers = FindObjectsOfType<LocationTrigger>();

        // Выбираем случайную локацию с заданными locationIdentifier
        LocationTrigger targetLocation = GetRandomTargetLocation(locationTriggers, targetLocationIdentifiers);
        if (targetLocation != null)
        {
            currentTarget = targetLocation.transform;
        }
    }

    private void Update()
    {
        moveTimer += Time.deltaTime; // Обновление таймера

        if (!isMoving && moveTimer >= moveInterval)
        {
            // Если лисица не перемещается и прошло достаточно времени, выбираем новую целевую локацию
            LocationTrigger[] locationTriggers = FindObjectsOfType<LocationTrigger>();
            LocationTrigger targetLocation = GetRandomTargetLocation(locationTriggers, targetLocationIdentifiers);
            if (targetLocation != null)
            {
                currentTarget = targetLocation.transform;
                isMoving = true; // Запуск перемещения
            }

            moveTimer = 0f; // Сброс таймера
        }
        else if (isMoving)
        {
            // Перемещение объекта к целевой локации
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

            // Проверка достижения целевой локации
            if (transform.position == currentTarget.position)
            {
                isMoving = false; // Завершение перемещения
            }
        }
    }

    private LocationTrigger GetRandomTargetLocation(LocationTrigger[] locations, List<string> identifiers)
    {
        // Создаем список доступных локаций
        List<LocationTrigger> availableLocations = new List<LocationTrigger>();

        foreach (LocationTrigger location in locations)
        {
            if (identifiers.Contains(location.locationIdentifier) && IsAdjacentLocation(location.transform))
            {
                availableLocations.Add(location);
            }
        }

        if (availableLocations.Count > 0)
        {
            // Выбираем случайную доступную локацию
            int randomIndex = Random.Range(0, availableLocations.Count);
            return availableLocations[randomIndex];
        }

        return null;
    }

    private bool IsAdjacentLocation(Transform location)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = location.position;

        // Проверяем, что локация находится на горизонтальной или вертикальной линии от текущей позиции лисицы
        if (Mathf.Abs(currentPosition.x - targetPosition.x) <= 1f && Mathf.Abs(currentPosition.y - targetPosition.y) <= 1f)
        {
            // Проверяем, что локация находится не дальше одной клетки от текущей позиции лисицы
            if (Mathf.Abs(currentPosition.x - targetPosition.x) <= 1f && Mathf.Abs(currentPosition.y - targetPosition.y) == 0f)
                return true; // Локация находится по горизонтали

            if (Mathf.Abs(currentPosition.x - targetPosition.x) == 0f && Mathf.Abs(currentPosition.y - targetPosition.y) <= 1f)
                return true; // Локация находится по вертикали
        }

        return false;
    }
}
