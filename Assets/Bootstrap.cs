using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap: MonoBehaviour
{
    private const string SERVER_ADDRESS = "http://45.86.183.61/Test/";
    private const string GET_KEY_FILE = "GetKey.php";
    private const string CHECK_USER_FILE = "CheckUser.php";
    private const string REG_USER_FILE = "RegUsers.php";
    private const string PHONE_NUMBER = "+7(926)5251385";
    private const string HOW_MANY_FILE =  "HowMany.php";

    private IDParser _parser;
    private UserChecker _userChecker;

    [SerializeField] private string _id;
    [SerializeField] private string _userStatus;

    private void Awake()
    {
        _parser = new(this);
        _parser.IDGott += OnGottID;

        _userChecker = new(this);
        _userChecker.UserChecked += OnUserChecked;
    }

    private void OnUserChecked(string status)
    {
        _userStatus = status;
    }

    private void OnGottID(string id)
    {
        _id = id;
    }

    public void RequestID()
    {
        _parser.GetId(SERVER_ADDRESS, GET_KEY_FILE);
    }

    public void CheckUser()
    {
        _userChecker.CheckUser(SERVER_ADDRESS + CHECK_USER_FILE, new Dictionary<string, string>() {{"ID", _id},{"Phone", PHONE_NUMBER}});
    }

    public void RegisterUser()
    {

    }

    public void CheckGuysPassesTest()
    {

    }
}
