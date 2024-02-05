using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;
using System;

public class IDParser
{
    private JSONParser _jsonParser;
    public Action<string> IDGott; 

    public IDParser(MonoBehaviour context)
    {
        _jsonParser = new JSONParser(context);
    }

    public void GetId(string url, string fileName)
    {
        _jsonParser.GetJSONString(url, fileName, ProcessJSON);
    }

    private void ProcessJSON(string jsonString)
    {
        List<string> parsedIDs = ParsedIDs(jsonString);
        string uniqueID = GetUniqueID(parsedIDs);
        string deencryptedID = DeencryptId(uniqueID);
        IDGott?.Invoke(deencryptedID);
    }

    private List<string> ParsedIDs(string jsonString)
    {
        KeysContainer keysContainer = JsonUtility.FromJson<KeysContainer>(jsonString);
        List<string> extractedKeys = keysContainer.Keys.Select(keyResponse => keyResponse.Key).ToList();
        return extractedKeys;
    }

    private string GetUniqueID(List<string> idList)
    {
        return idList.FirstOrDefault(key => key != "No Key");
    }

    private string DeencryptId(string input)
    {
        StringBuilder resultBuilder = new();

        for (int i = 0; i < input.Length; i += 2)
        {
            resultBuilder.Append(input[i]);
        }

        return resultBuilder.ToString();
    }
}
