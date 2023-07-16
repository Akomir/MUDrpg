using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public float moveSpeed = 1f; // �������� �����������
    public float moveInterval = 1f; // �������� ����������� (� ��������)
    public List<string> targetLocationIdentifiers; // ������ ������� �������� locationIdentifier

    private Transform currentTarget; // ������� ������� �������
    private bool isMoving = false; // ���� �����������
    private float moveTimer = 0f; // ������ ��� �������� ��������� �����������

    private void Start()
    {
        // ������� ��� ������� � ����������� LocationTrigger
        LocationTrigger[] locationTriggers = FindObjectsOfType<LocationTrigger>();

        // �������� ��������� ������� � ��������� locationIdentifier
        LocationTrigger targetLocation = GetRandomTargetLocation(locationTriggers, targetLocationIdentifiers);
        if (targetLocation != null)
        {
            currentTarget = targetLocation.transform;
        }
    }

    private void Update()
    {
        moveTimer += Time.deltaTime; // ���������� �������

        if (!isMoving && moveTimer >= moveInterval)
        {
            // ���� ������ �� ������������ � ������ ���������� �������, �������� ����� ������� �������
            LocationTrigger[] locationTriggers = FindObjectsOfType<LocationTrigger>();
            LocationTrigger targetLocation = GetRandomTargetLocation(locationTriggers, targetLocationIdentifiers);
            if (targetLocation != null)
            {
                currentTarget = targetLocation.transform;
                isMoving = true; // ������ �����������
            }

            moveTimer = 0f; // ����� �������
        }
        else if (isMoving)
        {
            // ����������� ������� � ������� �������
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

            // �������� ���������� ������� �������
            if (transform.position == currentTarget.position)
            {
                isMoving = false; // ���������� �����������
            }
        }
    }

    private LocationTrigger GetRandomTargetLocation(LocationTrigger[] locations, List<string> identifiers)
    {
        // ������� ������ ��������� �������
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
            // �������� ��������� ��������� �������
            int randomIndex = Random.Range(0, availableLocations.Count);
            return availableLocations[randomIndex];
        }

        return null;
    }

    private bool IsAdjacentLocation(Transform location)
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = location.position;

        // ���������, ��� ������� ��������� �� �������������� ��� ������������ ����� �� ������� ������� ������
        if (Mathf.Abs(currentPosition.x - targetPosition.x) <= 1f && Mathf.Abs(currentPosition.y - targetPosition.y) <= 1f)
        {
            // ���������, ��� ������� ��������� �� ������ ����� ������ �� ������� ������� ������
            if (Mathf.Abs(currentPosition.x - targetPosition.x) <= 1f && Mathf.Abs(currentPosition.y - targetPosition.y) == 0f)
                return true; // ������� ��������� �� �����������

            if (Mathf.Abs(currentPosition.x - targetPosition.x) == 0f && Mathf.Abs(currentPosition.y - targetPosition.y) <= 1f)
                return true; // ������� ��������� �� ���������
        }

        return false;
    }
}
