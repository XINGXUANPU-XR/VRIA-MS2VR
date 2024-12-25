using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChange : MonoBehaviour
{
    public Dropdown roomDropdown;
    public GameObject room1;
    public GameObject room2;

    public Button triggerButton; // 表示するボタン
    public InputField inputField; // 表示するInputField
    public Button put;

    public Text screen1;
    public Text screen2;

    void Start()
    {
        // 初期状態で部屋1を表示、部屋2を非表示
        room1.SetActive(true);
        room2.SetActive(false);
        screen2.gameObject.SetActive(false);

        // Dropdownのイベントリスナーを追加
        roomDropdown.onValueChanged.AddListener(delegate {
            SwitchRoom(roomDropdown.value);
        });
    }

    void SwitchRoom(int index)
    {
        if (index == 0)
        {
            room1.SetActive(true);
            room2.SetActive(false);

            triggerButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
            put.gameObject.SetActive(false);

            screen1.gameObject.SetActive(true);
            screen2.gameObject.SetActive(false);
        }
        else if (index == 1)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(true);
        }
    }
}
