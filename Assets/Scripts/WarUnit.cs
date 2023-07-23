using UnityEngine;

public class WarUnit : MonoBehaviour
{
    private Sprite pictureUnit; // Картинка боевого юнита

    [SerializeField]
    private int hp = 100; // Здоровье боевого юнита

    [SerializeField]
    private int attack = 10; // Сила урона боевого юнита

    [SerializeField]
    private float speedAttack = 1.0f; // Скорость атаки боевого юнита за 1 ход

    [SerializeField]
    private float moveSpeed = 5.0f; // Скорость перемещения боевого юнита по боевой карте

    private void Start()
    {
        // Устанавливаем тег боевого юнита таким же, как у родительской группы
        SetUnitTag();
    }

    private void SetUnitTag()
    {
        // Проверяем, что у юнита есть родительская группа
        Transform parent = transform.parent;
        if (parent != null)
        {
            // Получаем тег родительской группы и устанавливаем его для боевого юнита
            gameObject.tag = parent.tag;
        }
        else
        {
            Debug.LogError("WarUnit: " + gameObject.name + " не имеет родительской группы!");
        }
    }

    // Дополнительные методы для управления здоровьем и атакой можно добавить здесь

    // Например, метод для получения урона
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // Выполнить действия при смерти юнита (если нужно)
            Destroy(gameObject);
        }
    }
}
