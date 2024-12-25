using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ServerLink : MonoBehaviour
{
    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public Button triggerButton; // �\������{�^��
    public InputField inputField; // �\������InputField
    public Button put;

    void Start()
    {
        // �{�^����InputField���\���ɐݒ�
        triggerButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        put.gameObject.SetActive(false);

        // �{�^���Ƀ��X�i�[��ǉ�
        triggerButton.onClick.AddListener(ToggleInputFieldAndButton);
    }

    void OnTriggerEnter(Collider other)
    {
        // �v���C���[���G���A�ɓ������Ƃ�
        if (other.gameObject == player)
        {
            // �{�^����\��
            triggerButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // �v���C���[���G���A����o���Ƃ�
        if (other.gameObject == player)
        {
            // �{�^����InputField���\��
            triggerButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
            put.gameObject.SetActive(false);
        }
    }

    void ToggleInputFieldAndButton()
    {
        // InputField��put�{�^���̕\��/��\�����g�O��
        bool isActive = inputField.gameObject.activeSelf;
        inputField.gameObject.SetActive(!isActive);
        put.gameObject.SetActive(!isActive);
    }
}

