using UnityEngine;
using System.Collections.Generic;

public class UsersPassHandler: MonoBehaviour
{
    [SerializeField] private UsersFactory _usersFactory;

    private void Awake()
    {
        TestPassesList.TestPassesListGott += OnTestPassesListGott;
        Timer.Updated += OnTimerUpdated;
    }

    private void OnTestPassesListGott(List<string> usersList)
    {
        foreach (var user in usersList)
        {
            _usersFactory.GetUser(user);
        }
    }

    private void OnTimerUpdated()
    {
        
    }

    private void OnDisable()
    {
        TestPassesList.TestPassesListGott -= OnTestPassesListGott;
        Timer.Updated -= OnTimerUpdated;
    }
}
