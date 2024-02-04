using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;
using System.Text;

public class IDParser : MonoBehaviour
{
    private const string SERVER_ADDRESS = "http://45.86.183.61/Test/";
    private const string FILE_NAME = "GetKey.php";

    public static Action<string> IDGott;

    private JSONParser _jsonParser;

    public void GetId()
    {
        _jsonParser = new JSONParser();
        _jsonParser.GetJSONString(SERVER_ADDRESS, FILE_NAME, ParseID);
    }

    private void ParseID(string jsonString)
    {
        KeysContainer keysContainer = JsonUtility.FromJson<KeysContainer>(jsonString);

        HashSet<string> uniqueKeys = new();

        foreach (KeyResponse keyResponse in keysContainer.Keys)
        {
            uniqueKeys.Add(keyResponse.Key);
        }

        // Convert HashSet to an array if needed
        string[] uniqueKeysArray = new string[uniqueKeys.Count];
        uniqueKeys.CopyTo(uniqueKeysArray);

        // Log the unique keys
        foreach (string key in uniqueKeysArray)
        {
            Debug.Log("Unique Key: " + key);
        }
    }

    private string DeencryptId(string input)
    {
        StringBuilder resultBuilder = new StringBuilder();

        for (int i = 1; i < input.Length; i += 2)
        {
            resultBuilder.Append(input[i]);
        }

        return resultBuilder.ToString();
    }
}

public class UserChecker: MonoBehaviour
{

}
