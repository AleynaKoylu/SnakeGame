using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerMain : MonoBehaviour
{
    GameObject music;
    AudioSource mAudioSource;

    float volum;
    [SerializeField]
    Slider audioSlider;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        mAudioSource = music.GetComponent<AudioSource>();
       LoadAudio();
       

    }

    public void SetAudio( )
    {
        volum = audioSlider.value;
        mAudioSource.volume = volum;
        if (volum == 0)
        {
            mAudioSource.volume = 0;
        }
        SaveAuido();
    }
    void SaveAuido()
    {
        PlayerPrefs.SetFloat("AudioS", mAudioSource.volume);
    }
   public void LoadAudio()
    {
        if (PlayerPrefs.HasKey("AudioS"))
        {
           mAudioSource.volume = PlayerPrefs.GetFloat("AudioS");
            audioSlider.value = PlayerPrefs.GetFloat("AudioS");
        }
        else
        {
            PlayerPrefs.SetFloat("AudioS", .3f);
            mAudioSource.volume = PlayerPrefs.GetFloat("AudioS");
            audioSlider.value = PlayerPrefs.GetFloat("AudioS");
        }
    }
   


    public void  SceneLoad()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
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
