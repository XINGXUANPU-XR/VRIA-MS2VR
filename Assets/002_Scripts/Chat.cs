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
        // InputField���A�N�e�B�u�ɂ��Ă���
        inputField.gameObject.SetActive(false);
    }

    void Update()
    {
        // Enter�L�[�������ꂽ��InputField���A�N�e�B�u�ɂ���
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter�L�[��������܂���");
            inputField.gameObject.SetActive(true);
            inputField.ActivateInputField();
        }

        // Escape�L�[�������ꂽ��InputField���A�N�e�B�u�ɂ���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape�L�[��������܂���");
            inputField.gameObject.SetActive(false);
        }

        // InputField����A�N�e�B�u�ɂȂ����ꍇ�Ƀe�L�X�g��TV�I�u�W�F�N�g�ɕ\������
        if (!inputField.isFocused && inputField.gameObject.activeSelf)
        {
            Debug.Log("InputField����A�N�e�B�u�ɂȂ�܂���");
            chatText.text = inputField.text;
            inputField.gameObject.SetActive(true);
        }
    }
}
