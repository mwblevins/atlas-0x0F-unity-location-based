using UnityEngine;
using TMPro;

public class RefreshLocation : MonoBehaviour
{
    public TMP_Text latitudeText;
    public TMP_Text longitudeText;
    public TMP_Text altitudeText;

    public void RefreshLocal()
    {
        double latitude = Input.location.lastData.latitude;
        double longitude = Input.location.lastData.longitude;
        double altitude = Input.location.lastData.altitude;

        Debug.Log("Current Coordinates: " + latitude + ", " + longitude + ", " + altitude);

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
}