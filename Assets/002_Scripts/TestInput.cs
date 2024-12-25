using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestInput : MonoBehaviour
{
    public Text chatText;
    public InputField inputField;
    public Button sendButton;
    // Start is called before the first frame update
    void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void SendMessage()
    {
        string message = inputField.text;
        if (!string.IsNullOrEmpty(message))
        {
            //NetworkManager.SendChatMessage(message);
            Debug.Log("Message sent: " + message);
            chatText.text += "\n" + message;
            inputField.text = "";
        }
    }
}
