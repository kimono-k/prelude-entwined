using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    public string transitionName;

    // Start is called before the first frame update
    void Start()
    {
        // The player must exist, only then execute this script
        if (PlayerController.instance != null)
        {
            if (transitionName == PlayerController.instance.areaTransitionName) PlayerController.instance.transform.position = transform.position;
            
            UIFade.instance.FadeToTransparent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
