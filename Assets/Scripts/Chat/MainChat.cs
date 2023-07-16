using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class MainChat : MonoBehaviour
{

    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public ObjectManager objectManager;//ссылка обьект что бы передавать сюда данные с обьектов локации и далее в чат

    public Color playerMessage, info;


   [SerializeField]
    List<Message> messageList = new List<Message>();

    void Start()
    {

    }


    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space bar!", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
        
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count > maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);
        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch(messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;

           /* case Message.MessageType.lootInfo: // ч1 22-10 время ролика- Это пример как красить в цвет к примеру лут который ты поднял
                color = lootInfo;
                break;*/
        }
        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info,
        /*lootInfo*/ //ч1 22-10 время ролика- тут характеристики добавляем выше цвета ставим, что бы чате выделялись
    }
}
