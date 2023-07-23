using UnityEngine;

public class WarUnit : MonoBehaviour
{
    private Sprite pictureUnit; // �������� ������� �����

    [SerializeField]
    private int hp = 100; // �������� ������� �����

    [SerializeField]
    private int attack = 10; // ���� ����� ������� �����

    [SerializeField]
    private float speedAttack = 1.0f; // �������� ����� ������� ����� �� 1 ���

    [SerializeField]
    private float moveSpeed = 5.0f; // �������� ����������� ������� ����� �� ������ �����

    private void Start()
    {
        // ������������� ��� ������� ����� ����� ��, ��� � ������������ ������
        SetUnitTag();
    }

    private void SetUnitTag()
    {
        // ���������, ��� � ����� ���� ������������ ������
        Transform parent = transform.parent;
        if (parent != null)
        {
            // �������� ��� ������������ ������ � ������������� ��� ��� ������� �����
            gameObject.tag = parent.tag;
        }
        else
        {
            Debug.LogError("WarUnit: " + gameObject.name + " �� ����� ������������ ������!");
        }
    }

    // �������������� ������ ��� ���������� ��������� � ������ ����� �������� �����

    // ��������, ����� ��� ��������� �����
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // ��������� �������� ��� ������ ����� (���� �����)
            Destroy(gameObject);
        }
    }
}
