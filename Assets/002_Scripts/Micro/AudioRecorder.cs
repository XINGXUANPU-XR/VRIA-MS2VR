using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder : MonoBehaviour
{
    private AudioClip audioClip;
    private bool isRecording = false;
    private string microphone;

    void Start()
    {
        // 使用可能なマイクのリストを取得
        if (Microphone.devices.Length > 0)
        {
            microphone = Microphone.devices[0];
        }
        else
        {
            Debug.LogError("No microphone found!");
        }
    }

    public void StartRecording()
    {
        if (!isRecording && microphone != null)
        {
            audioClip = Microphone.Start(microphone, false, 10, 44100);
            isRecording = true;
            Debug.Log("Recording started");
        }
    }

    public void StopRecording()
    {
        if (isRecording)
        {
            Microphone.End(microphone);
            isRecording = false;
            Debug.Log("Recording stopped");
        }
    }

    public AudioClip GetAudioClip()
    {
        return audioClip;
    }
}
