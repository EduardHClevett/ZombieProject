using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public AudioMixer mixer;

    public TMP_Dropdown resDropdown;
    public TMP_Dropdown qualityDropdown;

    public int qualityIndex;
    //public string sceneName;

    public GameObject optionsMenu;
    public GameObject fovText;
    public GameObject fovSlider;

    public GameObject sensText;
    public GameObject sensSlider;

    public GameObject mapMenu;

    Resolution[] resolutions;

    public List<string> resList = new List<string>();

    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        foreach(Resolution res in resolutions)
        {
            resList.Add(res.ToString());
        }

        int currentResIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                currentResIndex = i;
        }

        resDropdown.AddOptions(resList);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

        qualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = qualityIndex;

        fovText.GetComponent<TextMeshProUGUI>().text = "Field of View: " + PlayerPrefs.GetFloat("playerFOV");
        fovSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("playerFOV");

        sensText.GetComponent<TextMeshProUGUI>().text = "Sensitivity: " + PlayerPrefs.GetFloat("playerSens");
        sensSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("playerSens");
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("masterVol", volume);
    }

    public void SetQuality(int setQualityIndex)
    {
        QualitySettings.SetQualityLevel(setQualityIndex);
        qualityIndex = setQualityIndex;
        qualityDropdown.RefreshShownValue();

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("App quit!");
        Application.Quit();
    }

    public void OptionsToggle()
    {
        if(!optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFOV(float fov)
    {
        fov = Mathf.Round(fov);

        PlayerPrefs.SetFloat("playerFOV", fov);
        fovText.GetComponent<TextMeshProUGUI>().text = "Field of View: "+ fov;
    }
    
    public void SetSensitivity(float sens)
    {
        sens = Mathf.Round(sens * 10) / 10;

        PlayerPrefs.SetFloat("playerSens", sens);
        sensText.GetComponent<TextMeshProUGUI>().text = "Sensitivity: " + sens;
    }

    public void MapSelectToggle()
    {
        if (!mapMenu.activeSelf)
        {
            mapMenu.SetActive(true);

            optionsMenu.SetActive(false);
        }
        else
        {
            mapMenu.SetActive(false);
        }
    }
}