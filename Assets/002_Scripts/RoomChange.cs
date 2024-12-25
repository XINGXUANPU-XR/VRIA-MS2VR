using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChange : MonoBehaviour
{
    public Dropdown roomDropdown;
    public GameObject room1;
    public GameObject room2;

    public Button triggerButton; // �\������{�^��
    public InputField inputField; // �\������InputField
    public Button put;

    public Text screen1;
    public Text screen2;

    void Start()
    {
        // ������Ԃŕ���1��\���A����2���\��
        room1.SetActive(true);
        room2.SetActive(false);
        screen2.gameObject.SetActive(false);

        // Dropdown�̃C�x���g���X�i�[��ǉ�
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
