    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public Transform doorModel1; // ドアのモデルオブジェクト
    public Transform doorModel2; // ドアのモデルオブジェクト

    public float openAngle = 90f; // ドアが開く角度
    public float openSpeed = 2f;  // ドアが開く速度
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = doorModel1.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;


    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three)) // マウスの左クリックを検出
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            if (Physics.Raycast(ray))
            {
                 isOpen = !isOpen;

            }
        }

        if (doorModel1 != null)
        {
            if (isOpen)
            {
                doorModel1.rotation = Quaternion.Slerp(doorModel1.rotation, openRotation, Time.deltaTime * openSpeed);

                doorModel2.rotation = Quaternion.Slerp(doorModel2.rotation, openRotation, Time.deltaTime * openSpeed);

            }
            else
            {
                doorModel1.rotation = Quaternion.Slerp(doorModel1.rotation, closedRotation, Time.deltaTime * openSpeed);

                doorModel2.rotation = Quaternion.Slerp(doorModel2.rotation, closedRotation, Time.deltaTime * openSpeed);

            }
        }
    }
}

