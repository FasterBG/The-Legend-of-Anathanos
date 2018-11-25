using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour {

	public void SetVolume(float volume)
    {

    }
    public void getBackToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SetQuaility(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
