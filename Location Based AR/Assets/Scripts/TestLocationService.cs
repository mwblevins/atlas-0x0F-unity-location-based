using UnityEngine;
using System.Collections;
using TMPro;
public class TestLocationService : MonoBehaviour
{
    public TMP_Text latitudeText;
    public TMP_Text longitudeText;
    public TMP_Text altitudeText;

    IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            Debug.Log("Location not enabled on device or app does not have permission to access location");

        // Starts the location service.
        Input.location.Start();

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        
        double latitude = Input.location.lastData.latitude;
        double longitude = Input.location.lastData.longitude;
        double altitude = Input.location.lastData.altitude;
        
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
        Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        if (latitudeText != null)
        {
            latitudeText.text = "Latitude: " + latitude.ToString();
        }
        if (longitudeText != null)
        {
            longitudeText.text = "Longitude: " + longitude.ToString();
        }
        if (altitudeText != null)
        {
            altitudeText.text = "Altitude: " + altitude.ToString();
        }

    }

    void OnDisable()
    {
        Input.location.Stop();
    }
}