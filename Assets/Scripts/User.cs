using TMPro;
using UnityEngine;

public class User: MonoBehaviour
{
    [SerializeField] private TMP_Text _userPhone;

    public void Initialize(string phoneNumber)
    {
        _userPhone.text = phoneNumber;
    }
}
