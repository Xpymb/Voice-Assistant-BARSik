using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Manager;
    public AudioClip audioSynth;

    void Start()
    {
        Manager = GetComponent<AudioSource>();    
    }

    private float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length / 2];

        for (int i = 0; i < floatArr.Length; i++)
        {
            floatArr[i] = ((float)BitConverter.ToInt16(array, i * 2)) / 32768.0f;
        }

        return floatArr;
    }

    public void UpdateAudioClip(byte[] bytesArray)
    {
        float[] samples = ConvertByteToFloat(bytesArray);

        audioSynth = AudioClip.Create("Synthesized", samples.Length, 1, 48000, false);
        audioSynth.SetData(samples, 0);
    }

    public void Play()
    {
        if (audioSynth == null)
        {
            Debug.Log("AudioManager: Synthesized audio no found");
            return;
        }

        Manager.clip = audioSynth;
        Manager.volume = 0.4f;
        Manager.Play();
    }
}
