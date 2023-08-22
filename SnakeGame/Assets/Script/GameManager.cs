using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Head head;
    [SerializeField]
    Slider speedSlider;
    [SerializeField]
    Slider audioSlider;
    GameObject music;
    AudioSource mAudioSource;
    float mVolume = .5f;
    float volum;
    float speedS;
    float speedH=15f;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        mAudioSource = music.GetComponent<AudioSource>();

    }
    public void SetSpeed()
    {
        speedH = speedS;
    }
    
    private void Update()
    {
     
        AudioSlider();

        SpeedSlider();

    }
   void AudioSlider()
    {
        volum = audioSlider.value;
        mAudioSource.volume = mVolume;

    }
    void SpeedSlider()
    {
        speedS = speedSlider.value;
        head.speed = speedH;

    }
    public void SetAudio()
    {
        mVolume = volum;
    }
    public void ActiveButton(GameObject activeGameObject)
    {
        activeGameObject.SetActive(true);
    }
    public void InactiveButton(GameObject inactiveGameObject)
    {
        inactiveGameObject.SetActive(false);
    }
    public void SettingButton(GameObject ActiveSettingPanel)
    {

        if (ActiveSettingPanel.activeSelf==false)
        {
            ActiveSettingPanel.SetActive(true);
            
        }
        else
        {
            ActiveSettingPanel.SetActive(false);
            
        }

    }
    public void RetryButton()
    {
       
           SceneManager.LoadScene(1);
        
    }
    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void TimeStats(int time)
    {
        Time.timeScale=time;
        
    }
   }




