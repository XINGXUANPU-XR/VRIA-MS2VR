using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ServerLink : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public Button triggerButton; // 表示するボタン
    public InputField inputField; // 表示するInputField
    public Button put;

    void Start()
    {
        // ボタンとInputFieldを非表示に設定
        triggerButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        put.gameObject.SetActive(false);

        // ボタンにリスナーを追加
        triggerButton.onClick.AddListener(ToggleInputFieldAndButton);
    }

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーがエリアに入ったとき
        if (other.gameObject == player)
        {
            // ボタンを表示
            triggerButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // プレイヤーがエリアから出たとき
        if (other.gameObject == player)
        {
            // ボタンとInputFieldを非表示
            triggerButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
            put.gameObject.SetActive(false);
        }
    }

    void ToggleInputFieldAndButton()
    {
        // InputFieldとputボタンの表示/非表示をトグル
        bool isActive = inputField.gameObject.activeSelf;
        inputField.gameObject.SetActive(!isActive);
        put.gameObject.SetActive(!isActive);
    }
}

