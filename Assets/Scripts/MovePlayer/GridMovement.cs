using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // �������� �����������
    public Transform gridOrigin; // ��������� ������� �����
    public float cellSize = 1f; // ������ ������ �����
    

    private Vector2 targetPosition; // ������� �������
    private bool isMoving = false; // ���� �����������

    private void Start()
    {
        targetPosition = transform.position; // ��������� ��������� ������� �������
    }

    private void Update()
    {
        if (isMoving)
        {
            // ����������� ������� � ������� �������
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // �������� ���������� ������� �������
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false; // ���������� �����������
            }
        }
        else
        {
            // ��������� ����� ��� ����������� �� �����
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveToNextCell(Vector2.up); // �������� �����
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToNextCell(Vector2.down); // �������� ����
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToNextCell(Vector2.left); // �������� �����
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToNextCell(Vector2.right); // �������� ������
            }
        }
    }

    private void MoveToNextCell(Vector2 direction)
    {
        // ������������� ��������� ������� �� ������ ����������� � ������� ������
        Vector2 nextPosition = (Vector2)transform.position + direction * cellSize;

        // �������� ����������� ��������� ������� (������ �������� ���� ������ ��������)

        // ��������� ������� �� ��������� �������
        Collider2D[] colliders = Physics2D.OverlapCircleAll(nextPosition, 0.1f); // ������ 0.1f ��� ������ ����������� ��������
        if (colliders.Length > 0)
        {
            GameObject nextObject = colliders[0].gameObject;
            string message = "����� �������� �� ������: " + nextObject.name;
            //Debug.Log(message);
          
        }

        // ��������� ��������� ������� � �������� ������� �������
        targetPosition = nextPosition;

        isMoving = true; // ������ �����������
    }
   
}
