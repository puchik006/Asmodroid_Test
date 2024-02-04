using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using System.Linq;

public class IDParser : MonoBehaviour
{
    private const string SERVER_ADDRESS = "http://45.86.183.61/Test/";
    private const string FILE_NAME = "GetKey.php";

    public static Action<string> IDGott;

    private JSONParser _jsonParser;

    private void Awake()
    {
        _jsonParser = new JSONParser(this);
    }

    public void GetId()
    {
        _jsonParser.GetJSONString(SERVER_ADDRESS, FILE_NAME, ProcessJSON);
    }

    private void ProcessJSON(string jsonString)
    {
        List<string> parsedIDs = ParseIDs(jsonString);
        string uniqueID = GetUniqueID(parsedIDs);
        string decryptedID = DecryptId(uniqueID);
        IDGott?.Invoke(decryptedID);
    }

    private List<string> ParseIDs(string jsonString)
    {
        KeysContainer keysContainer = JsonUtility.FromJson<KeysContainer>(jsonString);
        List<string> extractedKeys = keysContainer.Keys.Select(keyResponse => keyResponse.Key).ToList();
        return extractedKeys;
    }

    private string GetUniqueID(List<string> idList)
    {
        return idList.FirstOrDefault(key => key != "No Key");
    }

    private string DecryptId(string input)
    {
        StringBuilder resultBuilder = new();

        for (int i = 0; i < input.Length; i += 2) // ya by skazala eto ne kajdyi vtoroi, a cherez odin nachinaya s pervogo ili vse nechetnye
        {
            resultBuilder.Append(input[i]);
        }

        return resultBuilder.ToString();
    }
}
