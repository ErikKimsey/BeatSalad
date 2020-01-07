using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    Rigidbody audioBox;

    
    public AudioSource sample;
    private bool m_isMuted = false;
    private string m_BoxName;
    DragNDrop m_DragBox;
    void Start()
    {
      audioBox = GetComponent<Rigidbody>();
      sample = GetComponent<AudioSource>();
      m_DragBox = GetComponent<DragNDrop>();
    }

    void Mute(){
      sample.mute = !sample.mute;
    }

    void UnMute(){
      sample.mute = !sample.mute;
    }

    void Update()
    {
      Debug.Log(m_DragBox.name);
      // if(m_DragBox.GetIsLive() == true) {
      //   UnMute();
      // } else {
      //   sample.mute = true;
      // }
    }
}
