using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3;
    public float runSpeed = 4;
    public float jumpVelocity = 3;
    public float health;
    public float maxHealth = 150;

    public int playerPoints;

    public float regenWait = 5;
    public float regenAmount = 5;
    public GameObject gameManager;
    public GameManager manager;
    public UIManager uiManager;
    public Rigidbody rb;
    public CapsuleCollider col;
    public CameraController camControl;

    public GameObject deathCam;
    public GameObject deathUI;
    public GameObject pauseMenu;

    public WeaponManager weaponManager;

    public LayerMask groundLayers;

    private float moveSpeed;

    public bool isPaused = false;

    public Inputs input;

    public CustomGame customGame;

    void Awake()
    {
        input = new Inputs();

        customGame = GameObject.Find("CustomGameSettings").GetComponent<CustomGame>();

        //input.InGame.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        input.InGame.Jump.performed += _ => Jump();
        input.InGame.Pause.performed += _ => PauseGame();

        input.InGame.Sprint.started += _ => StartSprint();
        input.InGame.Sprint.canceled += _ => StopSprint();

        if (customGame.isCustom)
        {
            playerPoints = customGame.customStartPoints;
        }
        else
        {
            playerPoints = 500;
        }
    }

    void OnEnable()
    {
        input.Enable();
    }
    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        gameManager = GameObject.FindWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        camControl = GetComponentInChildren<CameraController>();

        weaponManager = GetComponentInChildren<WeaponManager>();

        Cursor.visible = false;

        isPaused = false;

        StartCoroutine(RegenHealth());

        moveSpeed = walkSpeed;
    }

    void Update()
    {
        uiManager = gameManager.GetComponent<UIManager>();

        if(health <= 0)
        {
            PlayerDie();
        }

        Move(input.InGame.Move.ReadValue<Vector2>());
    }

    IEnumerator RegenHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenWait);

            if (health < maxHealth)
            {
                health += regenAmount;
                yield return new WaitForSeconds(regenWait);
            }
            else
                yield return null;
        }
            
        
    }

    void Move(Vector2 movement)
    {
        float h = (movement.x * moveSpeed * Time.deltaTime);
        float v = (movement.y * moveSpeed * Time.deltaTime);

        transform.Translate(h, 0, v);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    [SerializeField]
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 0.01f, groundLayers);
    }

    public float GetHealthPercent()
    {
        return (float)health / maxHealth;
    }

    void PlayerDie()
    {
        gameObject.SetActive(false);
        deathCam.SetActive(true);
        deathUI.SetActive(true);

        if ((manager.round > PlayerPrefs.GetInt("Highest Round")) && !customGame.isCustom)
            PlayerPrefs.SetInt("Highest Round", manager.round);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            camControl.camLock = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
            weaponManager.pauseFire = true;
            pauseMenu.SetActive(true);
        }
        else if (isPaused || !weaponManager.pauseFire)
        {
            Time.timeScale = 1f;
            camControl.camLock = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
            weaponManager.pauseFire = false;
            pauseMenu.SetActive(false);
        }
    }

    void StartSprint()
    {
        moveSpeed = runSpeed;
    }

    void StopSprint()
    {
        moveSpeed = walkSpeed;
    }
}