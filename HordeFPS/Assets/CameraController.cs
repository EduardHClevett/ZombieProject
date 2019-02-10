using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector2 mouseCam;
    Vector2 smoothVect;

    public float sensitivity = 5f;
    public float smoothing = 2f;

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        var mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDir = Vector2.Scale(mouseDir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothVect.x = Mathf.Lerp(smoothVect.x, mouseDir.x, 1f / smoothing);
        smoothVect.y = Mathf.Lerp(smoothVect.y, mouseDir.y, 1f / smoothing);

        mouseCam += smoothVect;

        mouseCam.y = Mathf.Clamp(mouseCam.y, -66, 90);

        transform.localRotation = Quaternion.AngleAxis(-mouseCam.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseCam.x, Player.transform.up);
	}
}
