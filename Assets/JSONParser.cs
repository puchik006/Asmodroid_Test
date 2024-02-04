using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class JSONParser: MonoBehaviour
{

    public void GetJSONString(string address, string filename, Action<string> callback)
    {
        StartCoroutine(ParseResponse(address, filename, callback));
    }

    private IEnumerator ParseResponse(string address, string fileName, Action<string> callback)
    {
        string url = address + fileName;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
                callback(null);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                callback(jsonResponse);
            }
        }
    }
}
