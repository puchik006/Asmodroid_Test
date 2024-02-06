using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;

public class UsersPassHandler: MonoBehaviour
{
    private TestPassesCounter _passesCounter;
    private TestPassesList _passesList;
    [SerializeField] private UsersFactory _usersFactory;
    [SerializeField] private Timer _timer;
    [SerializeField] private TMP_Text _howMany;

    private void Awake()
    {
        _passesCounter = new(this);
        _passesList = new(this);
        _passesCounter.TestPassesCounted += OnTestPassesCounted;
        _passesList.TestPassesListGott += OnTestPassesListGott;
        Timer.Updated += OnTimerUpdated;
    }

    public void GetUsers()
    {
        _usersFactory.DestroyAllUsers();
        _passesCounter.CountTestPassedUsers(ServerData.SERVER_ADDRESS, ServerData.HOW_MANY_FILE);
        _passesList.GetPassesTestList(ServerData.SERVER_ADDRESS, ServerData.USERS_PASS_FILE);
        _timer.SetTimer(true);
    }

    private void OnTestPassesCounted(string userNumber)
    {
        _howMany.text = "How many: " + userNumber;
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
        GetUsers();
    }

    private void OnDisable()
    {
        _passesCounter.TestPassesCounted -= OnTestPassesCounted;
        _passesList.TestPassesListGott -= OnTestPassesListGott;
        Timer.Updated -= OnTimerUpdated;
    }
}
