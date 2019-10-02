using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeQuit : MonoBehaviour
{
    public string homeScene;

    public GameObject pauseMenu;
    public CameraController camControl;
    public PlayerController playerControl;

    public WeaponManager weaponManager;

    void Start()
    {
        camControl = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        weaponManager = GameObject.Find("Weapons").GetComponent<WeaponManager>();
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(homeScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        
        camControl.camLock = false;
        weaponManager.pauseFire = false;
        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
