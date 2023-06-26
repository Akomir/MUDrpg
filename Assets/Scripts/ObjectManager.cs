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
        // «десь вы можете добавить логику дл€ получени€ описани€ локации по ее имени
        switch (locationName)
        {
            case "ForestLvl1":
                return "¬ы находитесь в густом лесу первого уровн€. ќсторожно, здесь могут скрыватьс€ опасности.";
            case "ForestLvl2":
                return "¬ы попали в лес второго уровн€. «десь стало еще темнее и таинственнее.";
            // ƒобавьте описани€ дл€ других локаций
            default:
                return string.Empty;
        }
    }
}