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
        // 録音の開始/停止をトリガーするキー入力
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioRecorder.StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            audioRecorder.StopRecording();
        }

        // 録音した音声を再生するキー入力
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioPlayer.PlayAudio(audioRecorder.GetAudioClip());
        }
    }
}
