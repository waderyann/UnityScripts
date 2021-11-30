using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour
{
    // Start is called before the first frame update
    static WebCamTexture backCam;
    //AudioSource audio = GetComponent<AudioSource>();
   

    void Start()
    {
        //audio = GetComponent<AudioSource>();
        //audio.clip = Microphone.Start(null, true, 1, 22050);
        //audio.loop = true;
        //while (!(Microphone.GetPosition(null) > 0))
        //{

        //}
        //audio.Play();

        if (backCam == null)
            backCam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = backCam;

        if (!backCam.isPlaying)
            backCam.Play();

    }

    void Update()
    {

    }
}
