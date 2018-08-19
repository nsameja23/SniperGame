using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;


    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 basePlayerRotation;

    private Camera mainCamera;

    public GunController theGun;
    public Vector3 playerStartingPosition;
    public bool hasPositiveStartAxis;
    public Vector3 currentPointToLookAt;

    public float positionZ;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        playerStartingPosition = this.gameObject.transform.position;

        if (playerStartingPosition.z < 0)
        {
            hasPositiveStartAxis = false;
            basePlayerRotation = new Vector3(0f, -180f, 0);
        }
        else
        {
            hasPositiveStartAxis = true;
            basePlayerRotation = new Vector3(0f, 180f, 0);
        }
        this.gameObject.transform.eulerAngles = basePlayerRotation;

        currentPointToLookAt = new Vector3(0f, playerStartingPosition.y, 0f);

    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))

        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);
            Debug.Log(" pointo " + pointToLook.z);
            Debug.Log(" player " + transform.position.z);

            currentPointToLookAt = pointToLook;

            if (hasPositiveStartAxis && pointToLook.z <= this.gameObject.transform.position.z
                || !hasPositiveStartAxis && pointToLook.z >= this.gameObject.transform.position.z)
            {
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                //Debug.Log("x= " + this.gameObject.transform.eulerAngles.x);
                //Debug.Log("y= " + this.gameObject.transform.eulerAngles.y);
                //Debug.Log("z= " + this.gameObject.transform.eulerAngles.z);
            }
            else
            {
                positionZ = transform.position.z + (transform.position.z - pointToLook.z);
                
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, positionZ));
            }

            if (Input.GetMouseButtonDown(0))
                theGun.isFiring = true;
            /*if (Input.GetMouseButtonUp(0))
                theGun.isFiring = false;*/
        }
    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
