using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MicrophoneManager))]
public class Yandex : MonoBehaviour
{
    [Header("API's settings")]
    public string oauthToken = "AgAAAAAQt4xZAATuwacF_qkkxEP7pG4WwRNX2xU";
    public string folderId = "b1gldqr9q0t8qtsfr738";
    public string apiUri = "https://stt.api.cloud.yandex.net/speech/v1/";
    public string iamUri = "https://iam.api.cloud.yandex.net/iam/v1/tokens";
    string iamToken = "AQVNyhou-goyFAgSYZH2KM7RQdfKWMktqkl2jUjr";
    AudioManager Manager;

    [Space]
    [Header("Synthesize's settings")]
    public InputField textSynth;
    public string voice = "oksana";
    public string speedVoice = "1.0";
    public string format = "lpcm";
    public string sampleRateHertz = "48000";
    

    void Start()
    {
        Manager = GetComponent<AudioManager>();
    }

    async public void Recognize() //Yandex SpeechKit Recognize Request
    {
        AudioClip audio = MicrophoneManager.Audio;

        if(audio == null)
        {
            Debug.Log("Recognize: Audioclip not found, please record audio and try again");
            return;
        }

        byte[] bytesArray = MicrophoneManager.GetBytes(audio);

        using(HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("UserAgent", "");
            client.DefaultRequestHeaders.Add("Authorization", "Api-Key " + iamToken);
                
            var values = new List<string>
            {
                "lang=ru-RU",
                "topic=general",
                "format=lpcm",
                "sampleRateHertz=48000"
            };

            var uriValues = String.Join("&", values);
            var content = CreateContent(new Uri($"{apiUri}stt:recognize?{uriValues}"), bytesArray);
            var response = await client.SendAsync(content);

            byte[] responseArray = await response.Content.ReadAsByteArrayAsync();

            Debug.Log($"Recognize is done: {Encode(responseArray)}");
        }
    }

    async public void Synthesize() //Yandex SpeechKit Synthesize Request
    {
        string text = textSynth.text;

        if (text == "")
        {
            Debug.Log("Synthesize: Please enter text in InputField and try again");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("UserAgent", "");
            client.DefaultRequestHeaders.Add("Authorization", "Api-Key " + iamToken);

            var values = new Dictionary<string, string>
            {
                { "text", text },
                { "lang", "ru-RU" },
                { "format", format },
                { "voice", voice },
                { "sampleRateHertz", sampleRateHertz },
                { "speed", speedVoice }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://tts.api.cloud.yandex.net/speech/v1/tts:synthesize", content);
            var responseArray = await response.Content.ReadAsByteArrayAsync();

            Manager.UpdateAudioClip(responseArray);

            Debug.Log("Synthesize is done, you can click on play button");
        }
    }

    HttpRequestMessage CreateContent(Uri uri) //Create HTTPRequest without body content
    {
        return new HttpRequestMessage { RequestUri = uri, Method = HttpMethod.Post, Content = null };
    }

    HttpRequestMessage CreateContent(Uri uri, byte[] bytesArray) //Create HTTPRequest with body content
    {
        return new HttpRequestMessage { RequestUri = uri, Method = HttpMethod.Post, Content = new ByteArrayContent(bytesArray) };
    }

    string Encode(byte[] responseArray) //Encode HTTP byte[] response into Unity's string compatibility format (UTF-8)
    {
        return Encoding.UTF8.GetString(responseArray); 
    }
}
