using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragNDrop : MonoBehaviour
{

    private Rigidbody box;
    private Vector3 m_Offset;

    private float m_ZCoord;

    private bool m_IsLive;

    private string m_BoxName;

    private string[] m_BoxesContacted;

    void Start(){
      box = GetComponent<Rigidbody>();
      m_BoxName = box.name;
    }

    private void OnMouseDown() {
      m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
      m_Offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos(){
      Vector3 mousePos = Input.mousePosition;
      mousePos.z = m_ZCoord;
      return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag() {
      transform.position = GetMouseWorldPos() + m_Offset;
    }

    private void SetActive(){
      m_IsLive = !m_IsLive;
    }

    private void OnCollisionEnter(Collision other) {
      Debug.Log(other.collider.GetComponent<AudioBox>());
      if(other.collider.name != "Stage" && m_IsLive == false){
        SetActive();
      }
    }

    private void OnCollisionExit(Collision other) {
      Debug.Log(other.collider.name);
      if(m_IsLive == true){
        SetActive();
      }
    }

    public string GetBoxName(){
      return m_BoxName;
    }

    public bool GetIsLive(){
      return m_IsLive;
    }

    private void Update() {
      
    }
}
