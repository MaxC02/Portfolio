using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] public Transform holdArea;
    Rigidbody heldObj;
    Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] float pickUpForce = 150.0f;


    void OnMouseDown()
    {
        if(heldObj == null)
        {
            PickUpObject(GetComponent<Rigidbody>());
        }

    }

    void OnMouseUp()
    {
        if (heldObj != null)
        {
            DropObject();
        }
    }
    void Update()
    {

        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickUpForce);
        }
    }

    void PickUpObject(Rigidbody pickObj)
    {

            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
