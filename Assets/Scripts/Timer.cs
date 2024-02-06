using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerView;
    private const float REFRESH_TIME = 30;
    private float _timer = REFRESH_TIME;
    private bool _isTimerStart = true;
    
    public static event Action Updated;

    private void Update()
    {
        if (_isTimerStart)
        {
            _timer -= Time.deltaTime;

            _timerView.text = "Time before update: " + _timer.ToString("F0");

            if (_timer < 0)
            {
                Updated?.Invoke();
                _timer = REFRESH_TIME;
            }
        }
    }
}