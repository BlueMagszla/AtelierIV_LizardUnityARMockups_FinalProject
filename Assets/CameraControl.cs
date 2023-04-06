using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f; //how fast camera moves
    public float sensitivity = 5.0f; //how sensitive mouse movement is for rotating camera

    private Transform jointToFollow1; //first joint to follow
    private Transform jointToFollow2; //second joint to follow

    // Start is called before the first frame update
    void Start()
    {
        // Find the first joint to follow by name
        jointToFollow1 = GameObject.Find("PhotogrammetryClean_Lizard2:joint9").transform;
        if (jointToFollow1 == null)
        {
            Debug.LogError("Could not find the first joint to follow by name.");
        }

        // Find the second joint to follow by name
        jointToFollow2 = GameObject.Find("PhotogrammetryClean_Lizard2:joint9Sec").transform;
        if (jointToFollow2 == null)
        {
            Debug.LogError("Could not find the second joint to follow by name.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move camera around, forward, backward, left, right
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);

        //Make the first joint point towards the camera
        if (jointToFollow1 != null)
        {
            jointToFollow1.LookAt(transform.position);
        }

        //Make the second joint point towards the camera
        if (jointToFollow2 != null)
        {
            jointToFollow2.LookAt(transform.position);
        }
    }
}