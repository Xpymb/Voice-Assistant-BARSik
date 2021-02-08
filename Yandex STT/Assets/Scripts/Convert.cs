using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class Convert : MonoBehaviour
{
    const string apiToken = "c42ae5e449d6b2efcc8ef4c759dcff03";
    const string apiURI = "http://api.convertio.co/convert";
    public byte[] bytesArray;

    async public Task<byte[]> WAVToOGG(Byte[] bytesArray)
    {
        using (HttpClient client = new HttpClient())
        {
            var values = new Dictionary<string, string>
            {
                { "apikey", apiToken },
                { "input", "raw" },
                { "file", $"{ bytesArray }" },
                { "filename", "converted.ogg" },
                { "outputformat", "ogg" },
            };

            var content = CreateContent(values);
            var response = await client.PostAsync(apiURI, content);

            var result = await response.Content.ReadAsByteArrayAsync();

            return result;
        }
    }

    FormUrlEncodedContent CreateContent(Dictionary<string, string> values)
    {
        return new FormUrlEncodedContent(values);
    }
}
