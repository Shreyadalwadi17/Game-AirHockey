using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;


public class PlayerScript : MonoBehaviourPunCallbacks
{
    public GameObject selectedObject;
  
    void Update()
    {

        if (photonView.IsMine)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z+10.3f + Camera.main.nearClipPlane;

            selectedObject.transform.position = mousePosition;
            Debug.Log(selectedObject.transform.position);
            Debug.Log("mouse" + mousePosition);


            if (Input.GetMouseButtonUp(0))
            {
                selectedObject = null;
            }

        }
       

    }
}





