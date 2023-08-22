using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerMain : MonoBehaviour
{
    GameObject music;
    AudioSource mAudioSource;
    float mVolume = .5f;
    float volum;
    [SerializeField]
    Slider audioSlider;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        mAudioSource = music.GetComponent<AudioSource>();

    }

    void Update()
    {
        volum = audioSlider.value;
        mAudioSource.volume = mVolume;

    }
    public void SetAudio()
    {
        mVolume = volum;
    }
    public void  SceneLoad()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void SettingButton(GameObject ActiveSettingPanel)
    {

        if (ActiveSettingPanel.activeSelf == false)
        {
            ActiveSettingPanel.SetActive(true);

        }
        else
        {
            ActiveSettingPanel.SetActive(false);

        }

    }
}
