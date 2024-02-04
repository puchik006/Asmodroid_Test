using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RegistrationScript : MonoBehaviour
{
    // Your server URL
    private string serverURL = "http://45.86.183.61/Test/RegUsers.php";

    // Example data
    private string id = "QrFBaDG11";
    private string country = "+972";
    private string operatorCode = "53";
    private string phoneNumber = "4442115";

    public void AAa()
    {
        StartCoroutine(RegisterUser());
    }

    IEnumerator RegisterUser()
    {
        string formattedPhoneNumber = $"{country}({operatorCode}){phoneNumber}";

        // Create a WWWForm
        WWWForm form = new WWWForm();
        form.AddField("ID", id);
        form.AddField("Country", country);
        form.AddField("Operator", operatorCode);
        form.AddField("Number", phoneNumber);
        //form.AddField("User", formattedPhoneNumber);

        // Send the request
        using (UnityWebRequest www = UnityWebRequest.Post(serverURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Check the response
                if (www.downloadHandler.text.Equals("RegOK"))
                {
                    Debug.Log("Registration successful!");
                }
                else
                {
                    Debug.LogError("Registration failed. Server response: " + www.downloadHandler.text);
                }
            }
            else
            {
                Debug.LogError("Error sending request: " + www.error);
            }
        }
    }
}

