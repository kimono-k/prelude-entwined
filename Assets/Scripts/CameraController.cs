using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap theMap;
    private Vector3 bottomLeftLimit; // Limit of tilemap
    private Vector3 topRightLimit; // Limit of tilemap


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance != null)
        {
            target = PlayerController.instance.transform; // Data of position player
            bottomLeftLimit = theMap.localBounds.min; // Bottom of x and y on the map
            topRightLimit = theMap.localBounds.max; // Top of x and y on the map
        }
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // Main camera stalks the player

        // Keep the camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
