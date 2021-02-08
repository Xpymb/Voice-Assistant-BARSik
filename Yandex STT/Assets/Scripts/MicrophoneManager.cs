using System;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneManager : MonoBehaviour 
{
	public int AudioSampleRate = 48000;
	public string _microphone = null; //null = default
    public static AudioClip Audio;
	public static AudioClip AudioSynth;
    AudioSource AudioManager;

    void Start() 
	{
        AudioManager = GetComponent<AudioSource>();
	}

	#region Record
    public void Record()
    {
        if (!HasConnectedMicDevices())
            return;

        Debug.Log("recording started with " + _microphone);

		Audio = Microphone.Start(_microphone, true, 10, AudioSampleRate);

		Debug.Log(Microphone.IsRecording(_microphone).ToString());

        AudioManager.clip = Audio;
        AudioManager.Play();
    }

    public void Stop()
    {
        AudioManager.Stop();

        if (!HasConnectedMicDevices() || !IsRecordingNow(_microphone))
            return;

        Microphone.End(_microphone);
    }

    public void Play()
    {
        if (Audio == null)
            return;

        AudioManager.clip = Audio;
        AudioManager.Play();
    }

    bool HasConnectedMicDevices()
    {
        return Microphone.devices.Length > 0;
    }

    bool IsRecordingNow(string deviceName = null)
    {
        return Microphone.IsRecording(deviceName);
    }
	#endregion

	#region Export

	public static Byte[] GetBytes(AudioClip clip)
	{
		var samples = new float[clip.samples];

		clip.GetData(samples, 0);

		Int16[] intData = new Int16[samples.Length];
		//converting in 2 float[] steps to Int16[], //then Int16[] to Byte[]

		Byte[] bytesData = new Byte[samples.Length * 2];
		//bytesData array is twice the size of
		//dataSource array because a float converted in Int16 is 2 bytes.

		int rescaleFactor = 32767; //to convert float to Int16

		for (int i = 0; i < samples.Length; i++) 
		{
			intData[i] = (short) (samples[i] * rescaleFactor);
			Byte[] byteArr = new Byte[2];
			byteArr = BitConverter.GetBytes(intData[i]);
			byteArr.CopyTo(bytesData, i * 2);
		}

		return bytesData;
	}

	#endregion
}