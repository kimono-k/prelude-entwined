using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script changes from scene x to scene y */
public class AreaExit : MonoBehaviour
{
    // Variables
    public string areaToLoad;
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // For this to work assign tag to object in Unity
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = areaTransitionName; // Player gets set to areaExit transition
        }   
    }
}
