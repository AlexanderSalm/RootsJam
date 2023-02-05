using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMachine : MonoBehaviour
{
    public List<AudioClip> sfx;
    public List<string> altName;

    public List<GameObject> sourceSettings;
    public List<string> sourceNames;

    public static NoiseMachine instance;

    private static Dictionary<string, AudioClip> soundMap;
    private static Dictionary<string, GameObject> settingsMap;

    void Start(){
        instance = this;

        soundMap = new Dictionary<string, AudioClip>();
        settingsMap = new Dictionary<string, GameObject>();
    }
    
    public static void Play(string name, Vector3 position, float volume){
        Play(GetClipByName(name), position, volume, GetSettingsByName("default"));
    }

    public static void Play(string name, Vector3 position, float volume, string settings){
        Play(GetClipByName(name), position, volume, GetSettingsByName(settings));
    }

    public static void Play(string name, float volume, string settings){
        Play(name, Vector3.zero, volume, settings);
    }

    public static void Play(AudioClip audioClip, Vector3 position, float volume, GameObject settings){
        GameObject clip = Instantiate(settings);
        clip.transform.SetParent(instance.transform);
        clip.transform.position = position;
        clip.GetComponent<AudioSource>().volume = volume;
        clip.GetComponent<AudioSource>().clip = audioClip;
        clip.GetComponent<SFXSettings>().Play();
    }

    public static AudioClip GetClipByName(string name){
        if(soundMap.ContainsKey(name)) return soundMap[name];

        for(int i = 0; i < Mathf.Min(instance.sfx.Count, instance.altName.Count); i++){
            if (instance.altName[i] == name){
                soundMap.Add(name, instance.sfx[i]);
                return instance.sfx[i];
            }
        }
        return null;
    }

    public static GameObject GetSettingsByName(string name){
        if (settingsMap.ContainsKey(name)) return settingsMap[name];

        for(int i = 0; i < Mathf.Min(instance.sourceSettings.Count, instance.sourceNames.Count); i++){
            if(instance.sourceNames[i] == name){
                settingsMap.Add(name, instance.sourceSettings[i]);
                return instance.sourceSettings[i];
            }
        }
        return null;
    }
}
