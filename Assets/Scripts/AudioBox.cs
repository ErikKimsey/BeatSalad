using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    Rigidbody audioBox;
    public AudioSource sample;

    private bool m_Play;
    private bool m_isMuted = false;
    void Start()
    {
      audioBox = GetComponent<Rigidbody>();
      sample = GetComponent<AudioSource>();
      ToggleMute();

    }

    void ToggleMute(){
      sample.mute = !sample.mute;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.touchCount > 0){
        Debug.Log("DUN BEEN TOUCHED");
      }

      if(Input.GetMouseButtonDown(0)){
        Debug.Log("DONE BEEN CLICKED!");
      }
    }
}
