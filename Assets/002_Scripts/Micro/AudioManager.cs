using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioRecorder audioRecorder;
    private AudioPlayer audioPlayer;

    void Start()
    {
        audioRecorder = GetComponent<AudioRecorder>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        // �^���̊J�n/��~���g���K�[����L�[����
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioRecorder.StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            audioRecorder.StopRecording();
        }

        // �^�������������Đ�����L�[����
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioPlayer.PlayAudio(audioRecorder.GetAudioClip());
        }
    }
}
