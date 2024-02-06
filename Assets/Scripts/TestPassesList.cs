using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TestPassesList
{
    private JSONParser _jsonParser;
    public Action<List<string>> TestPassesListGott;

    public TestPassesList(MonoBehaviour context)
    {
        _jsonParser = new JSONParser(context);
    }

    public void GetPassesTestList(string url,string fileName)
    {
        _jsonParser.GetJSONString(url, fileName, ProcessJSON);
    }

    private void ProcessJSON(string response)
    {
        TestPassesListGott?.Invoke(ParsePhoneNumbers(response));
    }

    List<string> ParsePhoneNumbers(string input)
    {
        HashSet<string> uniquePhoneNumbers = new HashSet<string>();

        string pattern = @"\+\d{1,2}\(\d{3}\)\d{7}";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            uniquePhoneNumbers.Add(match.Value);
        }

        return new List<string>(uniquePhoneNumbers);
    }
}
