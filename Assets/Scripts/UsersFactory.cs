using UnityEngine;
using System.Collections.Generic;

public class UsersFactory : MonoBehaviour
{
    [SerializeField] private User _userPrefab;
    [SerializeField] private RectTransform _usersList;

    private List<User> instantiatedUsers = new List<User>();

    public User GetUser(string phoneNumber)
    {
        User instance = Instantiate(_userPrefab, _usersList);
        instance.Initialize(phoneNumber);
        instantiatedUsers.Add(instance);
        return instance;
    }

    public void DestroyAllUsers()
    {
        foreach (User user in instantiatedUsers)
        {
            Destroy(user.gameObject);
        }

        instantiatedUsers.Clear();
    }
}
