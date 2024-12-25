using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject switchObject; // クリックされるスイッチオブジェクト
    public Light[] roomLights;         // 部屋のライトオブジェクト

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
                light.enabled = !light.enabled; // ライトのオンオフを切り替える
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
