using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChange : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject table;
    public GameObject[] chairs; // �z�񖼂��C��
    public Material[] materials;

    void Start()
    {
        // Dropdown�̃��X�i�[��ǉ�
        dropdown.onValueChanged.AddListener(delegate { ChangeMaterial(dropdown.value); });
    }

    void ChangeMaterial(int index)
    {
        // �I�����ꂽ�C���f�b�N�X�Ɋ�Â��ă}�e���A����ύX
        if (index >= 0 && index < materials.Length)
        {
            if (index < 2) // 0 �܂��� 1 �̏ꍇ�A�e�[�u���̃}�e���A����ύX
            {
                Renderer tableRenderer = table.GetComponent<Renderer>();
                if (tableRenderer != null)
                {
                    tableRenderer.material = materials[index];
                }
            }
            else // 2 �ȏ�̏ꍇ�A�֎q�̃}�e���A����ύX
            {
                foreach (GameObject chair in chairs)
                {
                    Renderer chairRenderer = chair.GetComponent<Renderer>();
                    if (chairRenderer != null)
                    {
                        chairRenderer.material = materials[index];
                    }
                }
            }
        }
    }
}
