using System;
using System.Collections.Generic;
using UnityEngine;

public class UserChecker
{
    public Action<string> UserChecked;
    private FormSender _sender;

    private Dictionary<string, string> _formFields = new Dictionary<string, string>()
    {
        {"ID", ""},
        {"Phone", ""}
    };

    public UserChecker(MonoBehaviour context)
    {
        _sender = new FormSender(context);
    }

    public void CheckUser(string url, string id, string phoneNumber)
    {
        _formFields["ID"] = id;
        _formFields["Phone"] = phoneNumber;
        _sender.SendForm(url, _formFields, GetResponse);
    }

    private void GetResponse(string response)
    {
        UserChecked?.Invoke(response);
    }
}
