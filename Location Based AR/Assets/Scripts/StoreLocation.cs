using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLocation : MonoBehaviour
{
    public void StoreCoordinates()
    {
        double latitude = Input.location.lastData.latitude;
        double longitude = Input.location.lastData.longitude;
        double altitude = Input.location.lastData.altitude;

        PlayerPrefs.SetString("Stored Latitude", latitude.ToString());
        PlayerPrefs.SetString("Stored Longitude", longitude.ToString());
        PlayerPrefs.SetString("Stored Altitude", altitude.ToString());

        Debug.Log("Location saved");

    }

}
