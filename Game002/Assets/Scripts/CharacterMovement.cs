using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializePrivateVariables]
public class CharacterMovement : MonoBehaviour {

    public float speed;
    public Camera cam;

    private Rigidbody rBody;
    private Vector3 velocity;

    private float horizontal;
    private float vertical;

    private Vector3 mousePos;
    private Vector3 targetLocation;

    private Ray cast;
    private RaycastHit hit;
    private bool isMoving;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        isMoving = false;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        GetInput();
        Debug.Log(isMoving);
    }

    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 castPoint = mousePos;
            cast = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(cast, out hit, Mathf.Infinity))
            {
                targetLocation = hit.point;
                targetLocation.y = 1;
            }
            isMoving = true;
        }    
    }

    void Movement()
    {
        velocity = new Vector3(horizontal * speed, 0, vertical * speed);
        rBody.velocity = velocity;

        if(isMoving)
        {
            rBody.position = Vector3.MoveTowards(rBody.position, targetLocation, speed * Time.deltaTime);
            rBody.transform.LookAt(targetLocation);
        }

        if (targetLocation.x == rBody.position.x 
            && targetLocation.z == rBody.position.z) isMoving = false;
    }


}
