using UnityEngine;
using TMPro;

public class CalculateDistance : MonoBehaviour
{
    public TMP_Text distanceText;
    public TMP_Text localPositionText;
    public void Calculate()
    {
        // Retrieve stored
        double storedLatitude = double.Parse(PlayerPrefs.GetString("StoredLatitude", "0"));
        double storedLongitude = double.Parse(PlayerPrefs.GetString("StoredLongitude", "0"));

        // Retrieve current
        double currentLatitude = Input.location.lastData.latitude;
        double currentLongitude = Input.location.lastData.longitude;

        Vector3 storedLocalPosition = GPSEncoder.GPSToUCS((float)storedLatitude, (float)storedLongitude);
        Vector3 currentLocalPosition = GPSEncoder.GPSToUCS((float)currentLatitude, (float)currentLongitude);

        if (localPositionText != null)
        {
            localPositionText.text = "Unity Local Position\n" + currentLocalPosition.x.ToString("F2") + "\n" + currentLocalPosition.y.ToString("F2") + "\n" + currentLocalPosition.z.ToString("F2");
        }
        float distance = Vector3.Distance(new Vector2((float)storedLatitude, (float)storedLongitude), new Vector2((float)currentLatitude, (float)currentLongitude));

        if (distanceText != null)
        {
            distanceText.text = "Distance: " + distance.ToString("F2");
        }
        Debug.Log("Distance between stored and current coordinates: " + distance);
    }
}