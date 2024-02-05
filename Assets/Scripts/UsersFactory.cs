using UnityEngine;

public class UsersFactory: MonoBehaviour
{
    [SerializeField] private User _userPrefab;
    [SerializeField] private RectTransform _usersList;

    public User GetUser(string phoneNumber)
    {
        User instance = Instantiate(_userPrefab,_usersList);
        instance.Initialize(phoneNumber);
        return instance;
    }
}
