using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    [TextArea(2, 10)]
    public string description;

    public bool LerpAudio = false;

    public bool useGraph;           //set to true if graph is used
    public AnimationCurve AC;

    public float lerpTime = 3;      //time lerp should take

    [Range(0f, 1f)]
    public float startVol = 0;      //volume at beginning of lerp

    [Range(0f, 1f)]
    public float endVol = 0.5f;     //volume at end of lerp

    public bool isLerping;
    [HideInInspector]
    public bool wasLerping;
    [HideInInspector]
    public float currentTime;             //'t' in lerp
    [HideInInspector]
    public float lerpStartTime;            //Time.time at beginning of lerp

    void Start()
    {
        if (isLerping)
            volume = startVol;
    }
    public void LerpVolume()
    {
        if (useGraph)
        {
            currentTime += Time.deltaTime;
            source.volume = AC.Evaluate(currentTime);
        }
        else
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, endVol, currentTime / lerpTime);
        }
    }

    public void ChangeBool()
    {
        isLerping = !isLerping;
    }
}
