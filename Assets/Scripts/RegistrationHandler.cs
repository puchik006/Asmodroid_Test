using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationHandler: MonoBehaviour
{
    [SerializeField] private TMP_InputField _phoneNumber;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private Button _btnRegistration;
    private IDParser _parser;
    private UserChecker _userChecker;
    private UserRegistrator _userRegistrator;
    private string _id;

    private void Awake()
    {
        _parser = new(this);
        _parser.IDGott += OnGottID;

        _userChecker = new(this);
        _userChecker.UserChecked += OnUserChecked;

        _userRegistrator = new(this);
        _userRegistrator.UserRegistered += OnUserRegistered;

        _btnRegistration.onClick.AddListener(() => CheckUser());
    }

    public void RequestID() 
    { 
        _parser.GetId(ServerData.SERVER_ADDRESS, ServerData.GET_KEY_FILE); 
    }
    private void OnGottID(string id)
    {
        _id = id;
        _status.text = "Status: ID gott";
        _phoneNumber.gameObject.SetActive(true);
        _btnRegistration.gameObject.SetActive(true);
    }
    private void CheckUser()
    {
        _userChecker.CheckUser(ServerData.SERVER_ADDRESS + ServerData.CHECK_USER_FILE, _id, _phoneNumber.text);
    }
    private void OnUserChecked(string status)
    {
        _status.text = "Status: " + status;

        if (status == "NoExist")
        {
            RegisterUser();
        }
    }

    private void RegisterUser()
    {
        _userRegistrator.RegisterUser(ServerData.SERVER_ADDRESS + ServerData.REG_USER_FILE, _id, _phoneNumber.text);
    }

    private void OnUserRegistered(string status)
    { 
        _status.text = status;
    }
}
