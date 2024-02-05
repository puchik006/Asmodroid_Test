using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    private const float REFRESH_TIME = 30;
    [SerializeField] private float timer = REFRESH_TIME;

    public static event Action Updated;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Updated?.Invoke();
            timer = REFRESH_TIME;
            Debug.Log("Update");
        }
    }
}