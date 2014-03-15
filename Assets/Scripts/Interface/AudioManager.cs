using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public class AudioPhase
{
    public string loopIDs;
    public string fadeTimes;
    public string volumes;

    int[] ids;
    float[] fades;
    float[] volumeLevel;

    public void convertStrings()
    {
        ids = loopIDs.Split(',').Select(s => int.Parse(s)).ToArray();

        fades = fadeTimes.Split(',').Select(s => float.Parse(s)).ToArray();

        volumeLevel = volumes.Split(',').Select(s => float.Parse(s)).ToArray();
    }

    public int[] GetIDs()
    {
        return ids;
    }

    public float GetVolume(int id)
    {
        return volumeLevel[id];
    }

    public float GetFadeTime(int i)
    {
        return fades[i];
    }
}

public class AudioManager : MonoBehaviour
{
    public Scroller scroller;
    public float startValue;
    public float maxValue;

    public AudioClip[] musicLoops;
    public AudioPhase[] audioPhases;

    int currentPhase = 0;
    float stepSize = 0;
    float startTime = 0;
    AudioSource[] musicSources;

    // Use this for initialization
    void Start()
    {
        musicSources = new AudioSource[musicLoops.Length];

        for (int i = 0; i < musicLoops.Length; i++)
        {
            musicSources[i] = gameObject.AddComponent<AudioSource>();
            musicSources[i].clip = musicLoops[i];
            musicSources[i].loop = true;
            //musicSources[i].volume = 0;
        }

        foreach (AudioPhase phase in audioPhases)
        {
            phase.convertStrings();
        }

        stepSize = (maxValue - startValue) / audioPhases.Length;
        print(stepSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (scroller.scrollSpeed > startValue + stepSize * currentPhase)
        {
            currentPhase++;
            SetPhase();
        }
        if (currentPhase > 0 && startTime < 1)
        {
            AudioPhase phase = audioPhases[currentPhase - 1];
            int[] phaseIDs = audioPhases[currentPhase - 1].GetIDs();
            for (int i = 0; i < phaseIDs.Length; i++)
            {
                musicSources[phaseIDs[i]].volume = Mathf.Lerp(0, phase.GetVolume(i), startTime / phase.GetFadeTime(i));

            }
            startTime += Time.deltaTime;
        }
    }

    void SetPhase()
    {
        foreach (AudioSource source in musicSources)
        {
            source.volume = 0;
            source.Stop();
        }
        int[] phaseIDs = audioPhases[currentPhase - 1].GetIDs();
        for (int i = 0; i < phaseIDs.Length; i++)
        {
            //musicSources[phaseIDs[i]].volume = audioPhases[currentPhase - 1].GetVolume(i);
            musicSources[phaseIDs[i]].Play();
        }
        startTime = 0;

    }
}
