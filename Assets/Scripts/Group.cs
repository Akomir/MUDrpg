using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField]
    private List<Squad> squads = new List<Squad>(); // Список отрядов в группе

    [SerializeField]
    private bool isAggressive = false; // Является ли группа агрессивной

    [SerializeField]
    private int experience = 0; // Опыт группы

    [SerializeField]
    private int gold = 0; // Количество золота группы

    private void Start()
    {
        // Устанавливаем тег группы для всех отрядов
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

    // Метод для добавления отряда в группу
    public void AddSquad(Squad squad)
    {
        squads.Add(squad);
        squad.gameObject.tag = gameObject.tag; // Устанавливаем тег отряда такой же, как у группы
    }

    // Метод для удаления отряда из группы
    public void RemoveSquad(Squad squad)
    {
        squads.Remove(squad);
    }

    // Метод для получения общего количества отрядов в группе
    public int GetSquadCount()
    {
        return squads.Count;
    }

    // Метод для получения агрессивности группы
    public bool IsAggressive()
    {
        return isAggressive;
    }

    // Метод для установки агрессивности группы
    public void SetAggressive(bool value)
    {
        isAggressive = value;
    }

    // Метод для получения опыта группы
    public int GetExperience()
    {
        return experience;
    }

    // Метод для установки опыта группы
    public void SetExperience(int value)
    {
        experience = value;
    }

    // Метод для получения количества золота группы
    public int GetGold()
    {
        return gold;
    }

    // Метод для установки количества золота группы
    public void SetGold(int value)
    {
        gold = value;
    }
}
