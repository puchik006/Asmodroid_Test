using TMPro;
using UnityEngine;

public class RegistrationHandler: MonoBehaviour
{
    [SerializeField] private TMP_Text _phoneNumber;
    [SerializeField] private TMP_Text _status;

    private IDParser _parser;
    private UserChecker _userChecker;
    private UserRegistrator _userRegistrator;

    [SerializeField] private string _id;
    [SerializeField] private string _userStatus;
    [SerializeField] private string _registrationStatus;

    private void Awake()
    {
        _parser = new(this);
        _parser.IDGott += OnGottID;

        _userChecker = new(this);
        _userChecker.UserChecked += OnUserChecked;

        _userRegistrator = new(this);
        _userRegistrator.UserRegistered += OnUserRegistered;
    }

    public void RequestID() => _parser.GetId(ServerData.SERVER_ADDRESS, ServerData.GET_KEY_FILE);
    public void CheckUser() => _userChecker.CheckUser(ServerData.SERVER_ADDRESS + ServerData.CHECK_USER_FILE, _id, _phoneNumber.text);
    public void RegisterUser() => _userRegistrator.RegisterUser(ServerData.SERVER_ADDRESS + ServerData.REG_USER_FILE, _id, _phoneNumber.text);

    private void OnGottID(string id) => _id = id;
    private void OnUserChecked(string status) => _userStatus = status;
    private void OnUserRegistered(string status) => _registrationStatus = status;

}
