using System;
using UnityEngine;

public class TestPassesCounter
{
    private JSONParser _jsonParser;
    public static Action<string> TestPassesCounted;

    public TestPassesCounter(MonoBehaviour context)
    {
        _jsonParser = new JSONParser(context);
    }

    public void CountTestPassedUsers(string url, string fileName)
    {
        _jsonParser.GetJSONString(url, fileName, ProcessJSON);
    }

    private void ProcessJSON(string response)
    {
        TestPassesCounted?.Invoke(response);
    }
}
