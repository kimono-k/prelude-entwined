using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Makes sure player stays in scene
        if (PlayerController.instance == null) Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
