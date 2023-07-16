using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    public string locationName; // �������� �������
    public string locationIdentifier; // ������������� �������
    public ObjectManager objectManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectManager.DisplayLocationDescription(locationName);
        }
    }
}
