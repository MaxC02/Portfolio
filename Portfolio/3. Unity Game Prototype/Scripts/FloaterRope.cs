using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FloaterRope : MonoBehaviour
{

    public float underWaterDrag = 3f;

    public float underWaterAngularDrag = 1f;

    public float airDrag = 0f;

    public float airAngularDrag = 0.05f;

    public float floatingPower = 15f;

    public float waterHeight = 0f;

    public float vCancelHeight = 14.5f;
    public float tpDistOffset = 0.1f;

    public float maxSpeed;

    Rigidbody rope;

    bool underwater;


    void Start()
    {
        rope = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rope.velocity.magnitude > maxSpeed)
        {
            rope.velocity = rope.velocity.normalized * maxSpeed;
        }
    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            rope.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
            }
        }
        else if (underwater)
        {
            underwater = false;
        }

        if (rope.transform.position.y > vCancelHeight)
        {
            rope.velocity = new Vector3(rope.velocity.x, 0f, rope.velocity.z);
            rope.transform.position = new Vector3(rope.transform.position.x, vCancelHeight - tpDistOffset, rope.transform.position.z);
        }

    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rope.drag = underWaterDrag;
            rope.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rope.drag = airDrag;
            rope.angularDrag = airAngularDrag;
        }
    }

}