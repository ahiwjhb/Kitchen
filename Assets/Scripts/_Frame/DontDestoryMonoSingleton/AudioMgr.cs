using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : DontDestoryMonoSingleton<AudioMgr>
{
    [SerializeField] private AudioSource oncePlayer;
    [SerializeField] private AudioSource continuousPlayer;
    private const float MAX_PITCH = 1.1f;
    private const float MIN_PITCH = 0.9f;

    public float Volume { get; set; }

    protected override void Awake() {
        base.Awake();
        Volume = 1f;
    }

    public void PlaySFX(AudioData data){// 播放持续音效
        AudioClip audioClip = data.audioClip;
        float volume = data.volume;
        if(!continuousPlayer.isPlaying) continuousPlayer.Play();
    }

    public void PlayOnceSFX(AudioClip audioClip, float volume = 1f){// 播放单次音效
        oncePlayer.PlayOneShot(audioClip, volume * Volume);
    }

    public void PlayOnceRandomSFX(AudioData data){// 播放随机音高音效
        oncePlayer.pitch = Random.Range(MIN_PITCH, MAX_PITCH);
        oncePlayer.PlayOneShot(data.audioClip, data.volume);
    }

    public void PlayOnceRandomSFX(params AudioData[] datas){// 播放随机音效
        AudioData data = datas[Random.Range(0, datas.Length)];
        PlayOnceRandomSFX(data);
    }

    public void PausePlay(){// 暂停播放
        continuousPlayer.Stop();
    }
}

[System.Serializable]
public class AudioData{// 音频数据
    [SerializeField] public AudioClip audioClip;
    [SerializeField] public float volume;
}
