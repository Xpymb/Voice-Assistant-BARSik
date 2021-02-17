using System;
using System.IO;
using UnityEngine;

namespace AudioManager
{
    [RequireComponent(typeof(AudioSource))]
    public class MicrophoneManager : MonoBehaviour
    {
        public string microphoneId = null; //null = default
        public static new AudioClip audio;
        public int AudioSampleRate = 48000;
        AudioSource manager;

        void Start()
        {
            manager = GetComponent<AudioSource>();
        }

        #region Record
        public void Record()
        {
            if (!HasConnectedMicDevices())
                return;

            Debug.Log("recording started with " + microphoneId);

            audio = Microphone.Start(microphoneId, true, 10, AudioSampleRate);

            Debug.Log(Microphone.IsRecording(microphoneId).ToString());

            manager.clip = audio;
            manager.Play();
        }

        public void Stop()
        {
            manager.Stop();

            if (!HasConnectedMicDevices() || !IsRecordingNow(microphoneId))
                return;

            Microphone.End(microphoneId);
        }

        public void Play()
        {
            if (audio == null)
                return;

            manager.clip = audio;
            manager.Play();
            manager.Play();
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
        public AudioClip GetAudio()
        {
            return audio;
        }

        public byte[] GetBytes(AudioClip clip)
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
                intData[i] = (short)(samples[i] * rescaleFactor);
                Byte[] byteArr = new Byte[2];
                byteArr = BitConverter.GetBytes(intData[i]);
                byteArr.CopyTo(bytesData, i * 2);
            }

            return bytesData;
        }
        #endregion
    }
}