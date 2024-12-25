using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class VRInputManager : MonoBehaviour
{
    private AudioRecorder audioRecorder;
    private AudioPlayer audioPlayer;
    private bool isRecording = false;

    void Start()
    {
        audioRecorder = GetComponent<AudioRecorder>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        // Oculus Touchコントローラーの例 (Oculus SDKを使用)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (isRecording)
            {
                audioRecorder.StopRecording();
                isRecording = false;
            }
            else
            {
                audioRecorder.StartRecording();
                isRecording = true;
            }
        }
        
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            audioPlayer.PlayAudio(audioRecorder.GetAudioClip());
        }


    }
}
