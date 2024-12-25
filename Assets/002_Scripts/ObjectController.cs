using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject switchObject; // �N���b�N�����X�C�b�`�I�u�W�F�N�g
    public Light[] roomLights;         // �����̃��C�g�I�u�W�F�N�g

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        foreach (Light light in roomLights)
        {
            if (light != null)
            {
                light.enabled = !light.enabled; // ���C�g�̃I���I�t��؂�ւ���
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            ToggleLight();
        }
    }

}
