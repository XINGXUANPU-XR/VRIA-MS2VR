using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public TMP_InputField inputField;  // TextMeshPro Input Field
    public Text chatText;    // TextMeshPro component on TV object

    void Start()
    {
        // InputFieldを非アクティブにしておく
        inputField.gameObject.SetActive(false);
    }

    void Update()
    {
        // Enterキーが押されたらInputFieldをアクティブにする
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enterキーが押されました");
            inputField.gameObject.SetActive(true);
            inputField.ActivateInputField();
        }

        // Escapeキーが押されたらInputFieldを非アクティブにする
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escapeキーが押されました");
            inputField.gameObject.SetActive(false);
        }

        // InputFieldが非アクティブになった場合にテキストをTVオブジェクトに表示する
        if (!inputField.isFocused && inputField.gameObject.activeSelf)
        {
            Debug.Log("InputFieldが非アクティブになりました");
            chatText.text = inputField.text;
            inputField.gameObject.SetActive(true);
        }
    }
}
