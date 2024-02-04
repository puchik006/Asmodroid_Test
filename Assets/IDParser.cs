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

    private List<string> _unfilteredID = new();

    private JSONParser _jsonParser;

    public void GetId()
    {
        _jsonParser = new JSONParser();

        _jsonParser.GetJSONString(SERVER_ADDRESS, FILE_NAME, ParseID);

    }

    private void ParseID(string jsonString)
    {
        throw new NotImplementedException();
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
