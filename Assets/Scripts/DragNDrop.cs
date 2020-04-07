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
   public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
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
          if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase) {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    
                    directionChosen = false;
                    m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                    m_Offset = gameObject.transform.position - GetMouseWorldPos();
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    transform.position = GetMouseWorldPos() + m_Offset;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
    }
}
