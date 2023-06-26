using UnityEngine;

public class Fox : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость перемещения
    public Transform gridOrigin; // Начальная позиция сетки
    public float cellSize = 1f; // Размер ячейки сетки
    public string[] targetObjectNames; // Имена целевых объектов
    public float moveInterval = 10f; // Интервал перемещения (в секундах)

    private Vector2 targetPosition; // Целевая позиция
    private bool isMoving = false; // Флаг перемещения
    private bool isMovingToTarget = false; // Флаг перемещения к целевому объекту
    private float moveTimer = 0f; // Таймер для контроля интервала перемещения

    private void Start()
    {
        targetPosition = transform.position; // Установка начальной позиции объекта
    }

    private void Update()
    {
        moveTimer += Time.deltaTime; // Обновление таймера

        if (isMoving)
        {
            // Перемещение объекта к целевой позиции
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Проверка достижения целевой позиции
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false; // Завершение перемещения
                moveTimer = 0f; // Сброс таймера
            }
        }
        else if (moveTimer >= moveInterval) // Если прошло достаточно времени
        {
            if (!isMovingToTarget)
            {
                FindAndMoveToTargetObject(); // Поиск и перемещение к целевому объекту
            }
            else
            {
                MoveToRandomAdjacentCell(); // Перемещение на случайную соседнюю ячейку
            }
        }
    }

    private void FindAndMoveToTargetObject()
    {
        GameObject[] targetObjects = new GameObject[targetObjectNames.Length];

        for (int i = 0; i < targetObjectNames.Length; i++)
        {
            targetObjects[i] = GameObject.Find(targetObjectNames[i]);
        }

        if (targetObjects.Length > 0)
        {
            GameObject randomTargetObject = targetObjects[Random.Range(0, targetObjects.Length)];
            targetPosition = randomTargetObject.transform.position;
            isMoving = true;
            isMovingToTarget = true;
        }
    }

    private void MoveToRandomAdjacentCell()
    {
        Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        Vector2 randomDirection = adjacentDirections[Random.Range(0, adjacentDirections.Length)];

        // Рассчитывание следующей позиции на основе направления и размера ячейки
        Vector2 nextPosition = (Vector2)transform.position + randomDirection * cellSize;

        // Проверка доступности следующей позиции (можете добавить свою логику проверки)

        // Установка следующей позиции в качестве целевой позиции
        targetPosition = nextPosition;

        isMoving = true; // Запуск перемещения
        isMovingToTarget = false; // Сброс флага перемещения к целевому объекту
    }
}
