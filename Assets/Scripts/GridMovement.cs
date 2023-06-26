using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость перемещения
    public Transform gridOrigin; // Начальная позиция сетки
    public float cellSize = 1f; // Размер ячейки сетки
    

    private Vector2 targetPosition; // Целевая позиция
    private bool isMoving = false; // Флаг перемещения

    private void Start()
    {
        targetPosition = transform.position; // Установка начальной позиции объекта
    }

    private void Update()
    {
        if (isMoving)
        {
            // Перемещение объекта к целевой позиции
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Проверка достижения целевой позиции
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false; // Завершение перемещения
            }
        }
        else
        {
            // Обработка ввода для перемещения по сетке
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveToNextCell(Vector2.up); // Движение вверх
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToNextCell(Vector2.down); // Движение вниз
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToNextCell(Vector2.left); // Движение влево
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToNextCell(Vector2.right); // Движение вправо
            }
        }
    }

    private void MoveToNextCell(Vector2 direction)
    {
        // Рассчитывание следующей позиции на основе направления и размера ячейки
        Vector2 nextPosition = (Vector2)transform.position + direction * cellSize;

        // Проверка доступности следующей позиции (можете добавить свою логику проверки)

        // Получение объекта на следующей позиции
        Collider2D[] colliders = Physics2D.OverlapCircleAll(nextPosition, 0.1f); // Радиус 0.1f для поиска близлежащих объектов
        if (colliders.Length > 0)
        {
            GameObject nextObject = colliders[0].gameObject;
            string message = "Игрок наступил на объект: " + nextObject.name;
            //Debug.Log(message);
          
        }

        // Установка следующей позиции в качестве целевой позиции
        targetPosition = nextPosition;

        isMoving = true; // Запуск перемещения
    }
   
}
