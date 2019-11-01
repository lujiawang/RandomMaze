using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Vector3 move;
    public Transform parent;
    public Transform start;

    private float rotateAngle;
    private Rigidbody rb;

    private int mark = 0;

    void Start()
    {

        

        //startPos.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,0,10);
    }

    void Update()
    {
        if (mark == 0)
        {
            this.transform.position = start.position ;
            mark = 1;
        }
        
        rotateAngle = parent.rotation.z;

        move = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            transform.rotation = Quaternion.Euler(-90, -90, 90+ rotateAngle);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            transform.rotation = Quaternion.Euler(90, -90, 90+ rotateAngle);
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            transform.rotation = Quaternion.Euler(0, -90, 90+ rotateAngle);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            transform.rotation = Quaternion.Euler(-180, -90, 90+ rotateAngle);


        if (Input.GetKey(KeyCode.R))
            transform.position = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //move = Vector3.left;
            move = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //move = Vector3.right;
            move = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //move = Vector3.down;
            move = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //move = Vector3.up;
            move = Vector3.forward;
        }

        transform.Translate((move) * Time.deltaTime, Space.Self);
        //rb.AddForce(move * Time.deltaTime*10);
        
    }
}
