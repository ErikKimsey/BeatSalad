using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Rigidbody draggedObj;
    Vector3 objPos;
    private float zPos;
    Camera mainCamera;

    private bool isDragged = false;

    void Start()
    {
      draggedObj = GetComponent<Rigidbody>();
      objPos = draggedObj.position;
      Debug.Log(objPos);
      mainCamera = Camera.main;
      zPos = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    /**
    - Is AudioBox touching AudioStart?  [[  ]]
    - 
    */


    private void DraggingObject(){

    }

    private bool HasInput(){
      return Input.GetMouseButtonDown(0);
    }

    void Update()
    {
      if(HasInput()){
        DraggingObject();
      }
    }
}
