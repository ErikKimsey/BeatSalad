using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragNDrop : MonoBehaviour
{

    private Rigidbody box;
    private Vector3 m_Offset;

    private float m_ZCoord;
    void Start(){
      box = GetComponent<Rigidbody>();
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
}
