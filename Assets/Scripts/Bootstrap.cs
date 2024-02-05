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
    private UserRegistrator _userRegistrator;
    private TestPassesCounter _passesCounter;

    [SerializeField] private string _id;
    [SerializeField] private string _userStatus;
    [SerializeField] private string _registrationStatus;
    [SerializeField] private string _howManyPass;

    private void Awake()
    {
        _parser = new(this);
        _parser.IDGott += OnGottID;

        _userChecker = new(this);
        _userChecker.UserChecked += OnUserChecked;

        _userRegistrator = new(this);
        _userRegistrator.UserRegistered += OnUserRegistered;

        _passesCounter = new(this);
        _passesCounter.TestPassesCounted += OnTestPassesCounted;
    }

    public void RequestID()
    {
        _parser.GetId(SERVER_ADDRESS, GET_KEY_FILE);
    }

    private void OnGottID(string id)
    {
        _id = id;
    }

    public void CheckUser()
    {
        _userChecker.CheckUser(SERVER_ADDRESS + CHECK_USER_FILE, _id, PHONE_NUMBER);
    }

    private void OnUserChecked(string status)
    {
        _userStatus = status;
    }

    public void RegisterUser()
    {
        _userRegistrator.RegisterUser(SERVER_ADDRESS + REG_USER_FILE, _id, PHONE_NUMBER);
    }

    private void OnUserRegistered(string status)
    {
        _registrationStatus = status;
    }

    public void CheckGuysPassesTest()
    {
        _passesCounter.CountTestPassedUsers(SERVER_ADDRESS, HOW_MANY_FILE);
    }

    private void OnTestPassesCounted(string howMany)
    {
        _howManyPass = howMany;
    }
}
