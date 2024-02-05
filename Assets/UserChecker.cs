using System;
using System.Collections.Generic;
using UnityEngine;

public class UserChecker
{
    public Action<string> UserChecked;
    private FormSender _sender;

    public UserChecker(MonoBehaviour context)
    {
        _sender = new FormSender(context);
    }

    public void CheckUser(string url, Dictionary<string,string> formFields)
    {
        _sender.SendForm(url, formFields, GetResponse);
    }

    private void GetResponse(string response)
    {
        UserChecked?.Invoke(response);
    }
}
