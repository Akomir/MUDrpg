using UnityEngine;

public class RespawnButton : MonoBehaviour
{
    public Transform playerRespawnPoint; // ������ �� ������� �������� ������
    public GameObject playerPrefab; // ������ ������

    public void RespawnPlayer()
    {
        // ���������� ������������ �����, ���� �� ��� ����������
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer != null)
        {
            Destroy(existingPlayer);
        }

        // ������� ������ ������ �� ����� ��������
        Instantiate(playerPrefab, playerRespawnPoint.position, playerRespawnPoint.rotation);

    }
}
