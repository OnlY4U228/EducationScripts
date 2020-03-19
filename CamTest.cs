using UnityEngine;
using System.Collections;

public class CamTest : MonoBehaviour {


    //Done
	public float xRotation;
	public float yRotation;
	public float lookSensitivity = 5;
	public float currXRotation;
	public float currYRotation;
	public float xRotationVelocity;

    public Camera cam;

	public float yRotationVelocity;
	public float smoothDampTime = 0.1f;

	void Update () 
    {
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -10, 10);

        currXRotation = Mathf.SmoothDamp(currXRotation, xRotation, ref xRotationVelocity, smoothDampTime);
        currYRotation = Mathf.SmoothDamp(currYRotation, yRotation, ref yRotationVelocity, smoothDampTime);

        transform.rotation = Quaternion.Euler(0, currYRotation, 0);
        cam.transform.rotation = Quaternion.Euler(currXRotation, currYRotation, 0);
    }
}