using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{


    private float hitName;
    Rigidbody box;
    void Start(){
      box = GetComponent<Rigidbody>();
      Debug.Log(box);
    }

    private void Drag(){
      if(Input.GetMouseButton(0)){
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit)){
          if(hit.collider.name == box.name){
            Debug.Log(transform.position);
            Debug.Log(hit.transform.position);
            transform.position = hit.transform.position;
          }
        }
      }
    }
    void Update(){
      Drag();
    }
}
