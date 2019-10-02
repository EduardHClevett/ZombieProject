using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector2 mouseCam;
    Vector2 smoothVect;

    public float sensitivity = 5f;

    public float ySensMultiplier = 0.75f;
    public float smoothing = 2f;

    public bool camLock = false;

    public GameObject Player;

    public float playerFOV;

    public Inputs input;

    [Range(-50, 50)]
    public float deltaInputX;
    [Range(-50, 50)]
    public float deltaInputY;

    void Awake()
    {
        input = new Inputs();

        //input.InGame.LookX.performed += ctx => deltaInputX = ctx.ReadValue<float>();
        //input.InGame.LookY.performed += ctx => deltaInputY = ctx.ReadValue<float>();

        //input.InGame.LookX.canceled += _ => deltaInputX = 0;
        //input.InGame.LookY.canceled += _ => deltaInputY = 0;

        playerFOV = PlayerPrefs.GetFloat("playerFOV");
        gameObject.GetComponent<Camera>().fieldOfView = playerFOV;
    }

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        sensitivity = PlayerPrefs.GetFloat("playerSens");
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!camLock)
        {
            if (deltaInputX > 50)
                deltaInputX = 50;
            if (deltaInputX < -50)
                deltaInputX = -50;
            if (deltaInputY > 50)
                deltaInputY = 50;
            if (deltaInputY < -50)
                deltaInputY = -50;

            deltaInputX = input.InGame.LookX.ReadValue<float>();
            deltaInputY = input.InGame.LookY.ReadValue<float>();

            Vector2 selfRot = new Vector2(deltaInputY, 0) * (sensitivity * ySensMultiplier) * Time.fixedDeltaTime;
            Vector2 fullRot = new Vector2(0, deltaInputX) * sensitivity * Time.fixedDeltaTime;

            transform.Rotate(selfRot);
            Player.transform.Rotate(fullRot);

            float x = transform.localEulerAngles.x;

            x = ClampAngle(x, -66, 66);

            transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, 0);

        }

        if (recoil > 0f)
        {
            recoil -= (Time.deltaTime * 2);
        }
        else
        {
            recoil = 0f;
        }


        if (deltaInputX > 0.75)
            deltaInputX = 0;
        if (deltaInputY > 0.75)
            deltaInputY = 0;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private float recoil = 0.0f;
    public void StartRecoil(float recoilFeedthrough)
    {
        recoil = recoilFeedthrough;
    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < 0f)
            angle = 360 + angle;
        if (angle > 180f)
            return Mathf.Max(angle, 360 + min);

        return Mathf.Min(angle, max);
    }
}