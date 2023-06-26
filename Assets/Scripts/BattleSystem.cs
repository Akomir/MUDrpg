using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public MainChat chat; // Ссылка на компонент MainChat

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player and Enemy collided!");
            chat.SendMessageToChat("Player and Enemy collided!", Message.MessageType.info);
            // Здесь можно добавить код для обработки боя между игроком и врагом
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy and Player collided!");
            chat.SendMessageToChat("Enemy and Player collided!", Message.MessageType.info);
            WolfStats enemyStats = other.GetComponent<WolfStats>();
            if (enemyStats != null)
            {
                enemyStats.HP -= 1; // Отнимаем 1 HP у врага
                chat.SendMessageToChat("Enemy HP: " + enemyStats.HP, Message.MessageType.info);
                if (enemyStats.HP <= 0)
                {
                    // Если HP врага меньше или равно 0, уничтожаем его
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
