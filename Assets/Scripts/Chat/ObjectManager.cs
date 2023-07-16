using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public MainChat chatManager;

    public void DisplayLocationDescription(string locationName)
    {
        string description = GetLocationDescription(locationName);
        if (!string.IsNullOrEmpty(description))
        {
            chatManager.SendMessageToChat(description, Message.MessageType.info);
        }
    }

    private string GetLocationDescription(string locationName)
    {
        // ����� �� ������ �������� ������ ��� ��������� �������� ������� �� �� �����
        switch (locationName)
        {
            case "ForestLvl1":
                return "�� ���������� � ������ ���� ������� ������. ���������, ����� ����� ���������� ���������.";
            case "ForestLvl2":
                return "�� ������ � ��� ������� ������. ����� ����� ��� ������ � ������������.";
            // �������� �������� ��� ������ �������
            default:
                return string.Empty;
        }
    }
}