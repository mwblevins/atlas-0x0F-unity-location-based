using UnityEngine;

public class InstantiateObjectOnButtonClick : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public float distanceFromCamera = 1.0f;

    public void OnButtonClick()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraForward = Camera.main.transform.forward;

        Vector3 spawnPosition = cameraPosition + cameraForward * distanceFromCamera;

        GameObject instantiatedObject = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
    }
}
