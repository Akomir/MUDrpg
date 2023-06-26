using UnityEngine;

public class Fox : MonoBehaviour
{
    public float moveSpeed = 1f; // �������� �����������
    public Transform gridOrigin; // ��������� ������� �����
    public float cellSize = 1f; // ������ ������ �����
    public string[] targetObjectNames; // ����� ������� ��������
    public float moveInterval = 10f; // �������� ����������� (� ��������)

    private Vector2 targetPosition; // ������� �������
    private bool isMoving = false; // ���� �����������
    private bool isMovingToTarget = false; // ���� ����������� � �������� �������
    private float moveTimer = 0f; // ������ ��� �������� ��������� �����������

    private void Start()
    {
        targetPosition = transform.position; // ��������� ��������� ������� �������
    }

    private void Update()
    {
        moveTimer += Time.deltaTime; // ���������� �������

        if (isMoving)
        {
            // ����������� ������� � ������� �������
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // �������� ���������� ������� �������
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false; // ���������� �����������
                moveTimer = 0f; // ����� �������
            }
        }
        else if (moveTimer >= moveInterval) // ���� ������ ���������� �������
        {
            if (!isMovingToTarget)
            {
                FindAndMoveToTargetObject(); // ����� � ����������� � �������� �������
            }
            else
            {
                MoveToRandomAdjacentCell(); // ����������� �� ��������� �������� ������
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

        // ������������� ��������� ������� �� ������ ����������� � ������� ������
        Vector2 nextPosition = (Vector2)transform.position + randomDirection * cellSize;

        // �������� ����������� ��������� ������� (������ �������� ���� ������ ��������)

        // ��������� ��������� ������� � �������� ������� �������
        targetPosition = nextPosition;

        isMoving = true; // ������ �����������
        isMovingToTarget = false; // ����� ����� ����������� � �������� �������
    }
}
