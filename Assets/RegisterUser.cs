using System.Collections.Generic;
using UnityEngine;

public class RegisterUser : MonoBehaviour
{
    private const string SERVER_ADDRESS = "http://45.86.183.61/Test/";
    private const string FILE_NAME = "RegUsers.php";
    private const string PHONE_NUMBER = "+7(926)5251385";

    private FormSender _sender;

    private Dictionary<string, string> _formFields = new Dictionary<string, string>()
    {
        {"ID", ""},
        {"Country", ""},
        {"Operator", ""},
        {"Number", ""}
    };

    private void Awake()
    {
        _sender = new FormSender(this);
        //IDParser.IDGott += OnIDGott;
        ParsePhoneNumber();
    }

    private void ParsePhoneNumber()
    {
        string phoneNumber = PHONE_NUMBER.Replace("+", "");
        string[] parts = phoneNumber.Split('(', ')');

        _formFields["Country"] = "+" + parts[0];
        _formFields["Operator"] = "(" + parts[1] + ")";
        _formFields["Number"] = parts[2];
    }

    private void OnIDGott(string id)
    {
        _formFields["ID"] = id.Substring(0,id.Length - 1);
        string url = SERVER_ADDRESS + FILE_NAME;
        _sender.SendForm(url, _formFields, PrintResponse);
    }

    private void PrintResponse(string response)
    {
        Debug.Log("Server Response: " + response);
    }
}

