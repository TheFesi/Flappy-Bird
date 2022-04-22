using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] private Audio[] audios;
    private AudioSource audioSource;
    private List<AudioSource> loopAudioSources = new List<AudioSource>(0);

    protected override void Awake()
    {
        base.Awake();
        SetAudioSources();
    }
    private void SetAudioSources()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < audios.Length; i++)
        {
            Audio audio = audios[i];
            if (audios[i].loop)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                loopAudioSources.Add(audioSource);
                audioSource.clip = audio.audioClip;
                audioSource.playOnAwake = audio.playOnAwake;
                audioSource.loop = audio.loop;
                audioSource.volume = audio.volume;
                if (audios[i].playOnAwake) audioSource.Play();
            }
        }
    }
    private AudioSource GetAudioSource(AudioClip audioClip)
    {
        for (int i = 0; i < loopAudioSources.Count; i++)
            if (loopAudioSources[i].clip == audioClip) return loopAudioSources[i];
        return null;
    }
    public void PlayAudio(string audioName)
    {
        for (int i = 0; i < audios.Length; i++)
        {
            Audio audio = audios[i];
            if (audio.audioName == audioName)
            {
                if (audio.loop) GetAudioSource(audio.audioClip).Play();
                else audioSource.PlayOneShot(audio.audioClip, audio.volume);
            }
        }
    }
}

[System.Serializable]
public class Audio
{
    [Header("Audio Clip")]
    public string audioName;
    public AudioClip audioClip;
    [Header("Play Settings")]
    public bool playOnAwake;
    public bool loop;
    [Header("Volume")]
    [Range(0f, 1f)] public float volume = 1f;
}