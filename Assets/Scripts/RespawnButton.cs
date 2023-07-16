using UnityEngine;

public class RespawnButton : MonoBehaviour
{
    public Transform playerRespawnPoint; // Ссылка на позицию респауна игрока
    public GameObject playerPrefab; // Префаб игрока

    public void RespawnPlayer()
    {
        // Уничтожаем существующий игрок, если он уже существует
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer != null)
        {
            Destroy(existingPlayer);
        }

        // Создаем нового игрока на месте респауна
        Instantiate(playerPrefab, playerRespawnPoint.position, playerRespawnPoint.rotation);

    }
}
