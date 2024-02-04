using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FormSender
{
    private MonoBehaviour _context;

    public FormSender(MonoBehaviour context)
    {
        _context = context;
    }

    public void SendForm(string url, Dictionary<string, string> formFields, Action<string> callback)
    {
        _context.StartCoroutine(SendWebRequest(url, formFields, callback));
    }

    private IEnumerator SendWebRequest(string url, Dictionary<string,string> formFields, Action<string> callback)
    {
        WWWForm form = new();

        foreach (var item in formFields)
        {
            form.AddField(item.Key, item.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                callback(www.downloadHandler.text);
            }

            Debug.Log("Response Code: " + www.responseCode);
            Debug.Log("Full Response: " + www.downloadHandler.text);
            Debug.Log("Response Headers: " + www.result);
        }
    }
}
