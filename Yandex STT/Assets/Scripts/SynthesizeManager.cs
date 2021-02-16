using System;
using UnityEngine;

public class SynthesizeManager : MonoBehaviour
{
    #region Singleton
    private SynthesizeManager() { }

    private static readonly Lazy<SynthesizeManager> lazy =
        new Lazy<SynthesizeManager>(() => new SynthesizeManager());

    public static SynthesizeManager Source { get { return lazy.Value; } }
    #endregion

    public AudioSource manager;
    public static new AudioClip audio;
    public float volume = 0.4f;

    void Start()
    {
        manager = GetComponent<AudioSource>();    
    }



    public void Play()
    {
        if (audio == null)
        {
            Debug.Log("AudioManager: Synthesized audio no found");
            return;
        }

        manager.clip = audio;
        manager.volume = volume;
        manager.Play();
    }

    public void UpdateAudioClip(byte[] bytesArray)
    {
        float[] samples = ConvertByteToFloat(bytesArray);

        audio = AudioClip.Create("Synthesized", samples.Length, 1, 48000, false);
        audio.SetData(samples, 0);
    }

    float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length / 2];

        for (int i = 0; i < floatArr.Length; i++)
        {
            floatArr[i] = ((float)BitConverter.ToInt16(array, i * 2)) / 32768.0f;
        }

        return floatArr;
    }

    public static AudioClip GetAudio()
    {
        return audio;
    }
}
