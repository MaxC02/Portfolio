using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Floater : MonoBehaviour {

    public float underWaterDrag = 3f;

    public float underWaterAngularDrag = 1f;

    public float airDrag = 0f;

    public float airAngularDrag = 0.05f;

    public float floatingPower = 15f;

    public float waterHeight = 0f;

    public float vCancelHeight = 14.5f;
    public float tpDistOffset = 0.1f;

    public float maxSpeed;

    public Rigidbody boat;

    bool underwater;


    void Update()
    {
        if (boat.velocity.magnitude > maxSpeed)
        {
            boat.velocity = boat.velocity.normalized * maxSpeed;
        }
    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if(difference < 0)
        {
            boat.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if(!underwater)
            {
                underwater = true;
            }
        }
        else if(underwater)
        {
            underwater = false;
        }

        if(boat.transform.position.y > vCancelHeight)
        {
            boat.velocity = new Vector3(boat.velocity.x, 0f, boat.velocity.z);
            boat.transform.position = new Vector3(boat.transform.position.x, vCancelHeight - tpDistOffset, boat.transform.position.z);
        }

    }

    void SwitchState(bool isUnderwater)
    {
        if(isUnderwater)
        {
            boat.drag = underWaterDrag;
            boat.angularDrag = underWaterAngularDrag;
        }
        else
        {
            boat.drag = airDrag;
            boat.angularDrag = airAngularDrag;
        }
    }

}
