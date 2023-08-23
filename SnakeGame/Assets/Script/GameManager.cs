using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Head head;
    [SerializeField]
    Slider speedSlider;

    public float speedS;
    int score = 0;
    int hScore;
    [SerializeField]
    TextMeshProUGUI ScoreTxt;
    [SerializeField]
    TextMeshProUGUI HighScoreTxt;
    [SerializeField]
    TextMeshProUGUI scoreTxt;
   


    private void Start()
    {
      
        LoadSpeed();
        

    }
    
    public void Score()
    {
        hScore = score;
        score += 10;
        ScoreTxt.text = "Score: " + score;
        scoreTxt.text = score.ToString();
        
        
    }
    public void SaveHighScore()
    {
        
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            hScore = score;
            PlayerPrefs.SetInt("HighScore", hScore);
            HighScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();


        }
        HighScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void SetSpeed()
    {
        SpeedSlider();
        SaveSpeed();
    }
    void SaveSpeed()
    {
        PlayerPrefs.SetFloat("SpeedS", speedSlider.value);
    }
    void LoadSpeed()
    {
        if (PlayerPrefs.HasKey("SpeedS"))
        {
            speedS = PlayerPrefs.GetFloat("SpeedS");
            speedSlider.value = PlayerPrefs.GetFloat("SpeedS");
        }
        else
        {
            PlayerPrefs.SetFloat("SpeedS", 15f);
            speedS = PlayerPrefs.GetFloat("SpeedS");
            speedSlider.value = PlayerPrefs.GetFloat("SpeedS");
        }
    }
    void SpeedSlider()
    {
        speedS = speedSlider.value;

    }
    private void Update()
    {
     
        SaveHighScore();

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




