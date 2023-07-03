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
    public AreaEntrance theEntrance; // Reference to object
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        // Reads identical exits to entrances, so it connects with each other
        if (areaTransitionName != null) theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // For this to work assign tag to object in Unity
        if (other.tag == "Player")
        {
            // SceneManager.LoadScene(areaToLoad);
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName; // Player gets set to areaExit transition
        }   
    }
}
