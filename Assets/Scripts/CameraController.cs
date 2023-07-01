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

    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance != null)
        {
            target = PlayerController.instance.transform; // Data of position player
            
            // Blue space is the half of the camera, so omit the half to remove blue excess space
            halfHeight = Camera.main.orthographicSize; // 5 (size) / 2 = 2.5
            halfWidth = Camera.main.aspect * halfHeight; // Half of the width camera's view
            theMap.CompressBounds(); // Removes excess blue space
            bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f); // Bottom of x and y on the map
            topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f); // Top of x and y on the map

            PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
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
