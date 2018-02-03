using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTo : MonoBehaviour {

    Image myImage;

    public Color alphaStart;
    public Color alphaEnd;

    public bool BeginFade = true;
    public bool Reversible = false;
    public bool Repeatable = false;

    float interval = 0;
    public float timer;
    float speed = 1;
    int count = 1;
    public int maxcount = 0;


    // Use this for initialization
    void Start()
    {
        myImage = GetComponent<Image>();

        myImage.color = alphaStart;
    }
	
	// Update is called once per frame
	void Update () {
        if (BeginFade)
        {
            myImage.color = Vector4.Lerp(alphaStart, alphaEnd, interval / timer);
            interval += Time.deltaTime * speed;
            

            if (count < maxcount || Repeatable == true)
            {
                if (interval / timer >= 1.0f && Reversible)
                {
                    speed = -speed;
                    count++;
                }

                if (interval / timer <= 0.0f && Reversible)
                {
                    speed = -speed;
                    count++;
                }
            }
        }
    }

    public void SwitchFade()
    {
        BeginFade = !BeginFade;
    }
}
