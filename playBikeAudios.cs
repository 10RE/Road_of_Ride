using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBikeAudios : MonoBehaviour
{

    public AudioSource slideIn;
    public AudioSource engineStart;
    public AudioSource engineStop;
    public AudioSource lowRpm;
    private bool startFlagOne = false;
    private bool startFlagTwo = false;
    private bool workingFlag = false;
    public AudioSource highRpm;


    private float targetPitch = 1f;
    private float targetStartPitchHigh = 2f;
    private float targetStartPitchLow = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (startFlagOne)
        {
            lowRpm.pitch = Mathf.Lerp(lowRpm.pitch, targetStartPitchHigh, 0.02f);
        }
        if (startFlagOne && Mathf.Abs(lowRpm.pitch - targetStartPitchHigh) < 0.1f)
        {
            startFlagOne = false;
            startFlagTwo = true;
        }
        if (startFlagTwo)
        {
            lowRpm.pitch = Mathf.Lerp(lowRpm.pitch, targetStartPitchLow, 0.008f);
        }
        if (startFlagTwo && Mathf.Abs(lowRpm.pitch - targetStartPitchLow) < 0.1f)
        {
            startFlagTwo = false;
            workingFlag = true;
        }
        if (workingFlag)
        {
            lowRpm.pitch = Mathf.Lerp(lowRpm.pitch, targetPitch, 0.03f);
        }
    }

    // Update is called once per frame
    public void SlideInAndStartEngine()
    {
        slideIn.Play();
        engineStart.PlayDelayed(slideIn.clip.length);
        lowRpm.loop = true;
        lowRpm.PlayDelayed(slideIn.clip.length + engineStart.clip.length - 0.5f);
        startFlagOne = true;
    }

    public void StopEngine()
    {
        lowRpm.loop = false;
        lowRpm.Stop();
        engineStop.Play();
        
    }

    public void UpdatePitch(float pitch)
    {
        targetPitch = pitch * 2f + targetStartPitchLow;
    }

}
