using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class TapController : MonoBehaviour
{
    public float tapForce;
    public float waterForce;
    public float tiltSmooth;
    public Vector3 startPos;
    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -15);
        forwardRotation = Quaternion.Euler(0, 0, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.left * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        rigidbody.AddForce(Vector2.right * waterForce, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //check collisions with objects tagged as "ScoreZone"
        // if(col.gameObject.tag == "ScoreZone")
        // {
        //     //score event
        // }

        // if (col.gameObject.tag == "DeadZone")
        // {
        //makes boat freeze and end physics stuff when we lose
        //      rigidbody.simulated = false;
        //     //go to gameover
        // }
    }
}
