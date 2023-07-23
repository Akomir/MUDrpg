using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField]
    private List<Squad> squads = new List<Squad>(); // ������ ������� � ������

    [SerializeField]
    private bool isAggressive = false; // �������� �� ������ �����������

    [SerializeField]
    private int experience = 0; // ���� ������

    [SerializeField]
    private int gold = 0; // ���������� ������ ������

    private void Start()
    {
        // ������������� ��� ������ ��� ���� �������
        SetSquadsTag();
    }

    private void SetSquadsTag()
    {
        string groupTag = gameObject.tag;
        foreach (var squad in squads)
        {
            squad.gameObject.tag = groupTag;
        }
    }

    // ����� ��� ���������� ������ � ������
    public void AddSquad(Squad squad)
    {
        squads.Add(squad);
        squad.gameObject.tag = gameObject.tag; // ������������� ��� ������ ����� ��, ��� � ������
    }

    // ����� ��� �������� ������ �� ������
    public void RemoveSquad(Squad squad)
    {
        squads.Remove(squad);
    }

    // ����� ��� ��������� ������ ���������� ������� � ������
    public int GetSquadCount()
    {
        return squads.Count;
    }

    // ����� ��� ��������� ������������� ������
    public bool IsAggressive()
    {
        return isAggressive;
    }

    // ����� ��� ��������� ������������� ������
    public void SetAggressive(bool value)
    {
        isAggressive = value;
    }

    // ����� ��� ��������� ����� ������
    public int GetExperience()
    {
        return experience;
    }

    // ����� ��� ��������� ����� ������
    public void SetExperience(int value)
    {
        experience = value;
    }

    // ����� ��� ��������� ���������� ������ ������
    public int GetGold()
    {
        return gold;
    }

    // ����� ��� ��������� ���������� ������ ������
    public void SetGold(int value)
    {
        gold = value;
    }
}
