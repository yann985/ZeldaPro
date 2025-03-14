using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] protected AudioMixerGroup _audioMixerSFX;
    [SerializeField] protected AudioMixerGroup _audioMixerMusic;
  
    

    public Sound[] MusicSounds;
    public Sound[] SfxSounds;
    
    [HideInInspector] public GameObject tempAudio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void PlaySound( Sound[] soundList, string name,Vector3 pos ,AudioMixerGroup Volume,float sonsLocale,bool loop,float baseVolume )
    {
        Sound sound = Array.Find(soundList, s => s.Name == name);
    
        if (sound == null)
        {
            Debug.Log($"{name} Not Found");
        }
        else
        {
            tempAudio=new GameObject("tempAudio");
            tempAudio.transform.position=pos;
            AudioSource audioSource= tempAudio.AddComponent<AudioSource>();
            audioSource.spatialBlend=sonsLocale;
            audioSource.clip = sound.Clip;
            audioSource.volume=baseVolume;
            audioSource.loop=loop;
            audioSource.outputAudioMixerGroup=Volume;
            audioSource.Play();
            Destroy(tempAudio,sound.Clip.length);
          
        }
    }

   

    public void PlayMusic(  string name, Vector2  pos, float baseVolume)
    {
        
        
        
        AudioMixerGroup Volume= _audioMixerMusic;
        bool loop=true;
        int sonsLocale=1;
         PlaySound( MusicSounds, name, pos,Volume,sonsLocale,loop,baseVolume);
    }

    public void PlaySFX(string name,Vector3 pos, float baseVolume, bool serverCheck = true)
    {
        
        
            
           
        float sonsLocale=1f;
        bool loop=false;
        AudioMixerGroup Volume=_audioMixerSFX;
        
        PlaySound( SfxSounds, name, pos,Volume,sonsLocale,loop,baseVolume);
    }
    
   
}