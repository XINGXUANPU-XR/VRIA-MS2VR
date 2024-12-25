using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChange : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject table;
    public GameObject[] chairs; // 配列名を修正
    public Material[] materials;

    void Start()
    {
        // Dropdownのリスナーを追加
        dropdown.onValueChanged.AddListener(delegate { ChangeMaterial(dropdown.value); });
    }

    void ChangeMaterial(int index)
    {
        // 選択されたインデックスに基づいてマテリアルを変更
        if (index >= 0 && index < materials.Length)
        {
            if (index < 2) // 0 または 1 の場合、テーブルのマテリアルを変更
            {
                Renderer tableRenderer = table.GetComponent<Renderer>();
                if (tableRenderer != null)
                {
                    tableRenderer.material = materials[index];
                }
            }
            else // 2 以上の場合、椅子のマテリアルを変更
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
