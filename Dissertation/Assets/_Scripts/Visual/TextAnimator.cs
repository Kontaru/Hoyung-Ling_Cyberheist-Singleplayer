using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variable
{
    [Header("Animation Variables")]
    public Animation anim;
    public float delay;
}

public class TextAnimator : MonoBehaviour {

    public Variable[] animations;

    public bool Play;
    float currentDelay;
    int curAnimation = 0;

    // Update is called once per frame
    void Update () {
		if(Play)
            AnimationCycle();
        else
            currentDelay = Time.time + animations[0].delay;
	}

    void AnimationCycle()
    {
        if (Time.time > currentDelay)
        {
            animations[curAnimation].anim.Play();
            curAnimation += 1;
            if (curAnimation < animations.Length)
                currentDelay += animations[curAnimation].delay;
            else
            {
                curAnimation = 0;
                Play = false;
            }
        }
    }
}
