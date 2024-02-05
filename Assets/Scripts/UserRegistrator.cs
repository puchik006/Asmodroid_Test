using System;
using System.Collections.Generic;
using UnityEngine;

public class UserRegistrator
{
    public Action<string> UserRegistered; 
    private FormSender _sender;

    private Dictionary<string, string> _formFields = new Dictionary<string, string>()
    {
        {"ID", ""},
        {"Country", ""},
        {"Operator", ""},
        {"Number", ""}
    };

    public UserRegistrator(MonoBehaviour context)
    {
        _sender = new FormSender(context);
    }

    public void RegisterUser(string url,string id, string phoneNumber)
    {
        OffsetID(id);
        ParsePhoneNumber(phoneNumber);
        _sender.SendForm(url, _formFields, PrintResponse);
    }

    private void OffsetID(string id)
    {
        _formFields["ID"] = id.Substring(0, id.Length - 1);
    }

    private void ParsePhoneNumber(string phoneNumber)
    {
        string numbers = phoneNumber.Replace("+", "");
        string[] parts = numbers.Split('(', ')');

        _formFields["Country"] = "+" + parts[0];
        _formFields["Operator"] = "(" + parts[1] + ")";
        _formFields["Number"] = parts[2];
    }

    private void PrintResponse(string response)
    {
        UserRegistered?.Invoke(response);
    }
}

