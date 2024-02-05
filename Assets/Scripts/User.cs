using TMPro;
using UnityEngine;

public class User: MonoBehaviour
{
    private TMP_Text _userPhone;

    private void OnValidate()
    {
        _userPhone = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void Initialize(string phoneNumber)
    {
        _userPhone.text = phoneNumber;
    }
}
