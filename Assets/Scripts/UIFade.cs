using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed;

    public bool fadeToBlack;
    public bool fadeToTransparent;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack) 
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f) fadeToBlack = false;
        }

        if (fadeToTransparent) 
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f) fadeToTransparent = false;
        }

    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeToTransparent = false;
    }

    public void FadeToTransparent()
    {
        fadeToBlack = false;
        fadeToTransparent = true;
    }

}
