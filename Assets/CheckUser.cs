using System.Collections.Generic;
using UnityEngine;

public class CheckUser : MonoBehaviour
{
    private const string SERVER_ADDRESS = "http://45.86.183.61/Test/";
    private const string FILE_NAME = "CheckUser.php";
    private const string PHONE_NUMBER = "+972(53)4442115";

    private FormSender _sender;

    private Dictionary<string,string> _formFields;

    private void Awake()
    {
        IDParser.IDGott += OnIDGott;
        _sender = new FormSender(this);
    }

    private void OnIDGott(string id)
    {
        _formFields = new Dictionary<string, string>()
        {
            {"ID", id},
            {"Phone", PHONE_NUMBER}
        };

        string url = SERVER_ADDRESS + FILE_NAME;

        _sender.SendForm(url, _formFields, PrintResponse);
    }

    private void PrintResponse(string response)
    {
        Debug.Log(response);
    }
}
