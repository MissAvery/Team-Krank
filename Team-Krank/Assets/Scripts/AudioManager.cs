using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
   
    public float volumeM, volumeS;
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            if(s.type == "Music")
            {
                s.source.loop = true;
            }
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void NewSoundVolume(System.Single vol)
     {
        foreach (Sound s in sounds)
        {
           if(s.type == "Sound"){
                s.volume = vol;
                s.source.volume = vol;
           }
        }
     }

     public void NewMusicVolume(System.Single vol)
     {
        foreach (Sound s in sounds)
        {
           if(s.type == "Music"){
                s.volume = vol;
                s.source.volume = vol;
           }
        }
     }
}
