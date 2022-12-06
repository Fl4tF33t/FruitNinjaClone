using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject closeButton;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider scoreSlider;


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameManager gmInfo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your score is: " + GameManager.score;
        livesText.text = "You have " + GameManager.lives + " left";
        scoreSlider.value = (float)GameManager.score;
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(!pauseButton.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        settingsButton.SetActive(true);
        closeButton.SetActive(false);
        playButton.SetActive(!playButton.activeSelf);
        pauseButton.SetActive(!pauseButton.activeSelf);
        volumeSlider.transform.gameObject.SetActive(false);
    }

    public void SettingButton()
    {
        Time.timeScale = 0;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
        settingsButton.SetActive(!settingsButton.activeSelf);
        closeButton.SetActive(!closeButton.activeSelf);
        volumeSlider.transform.gameObject.SetActive(true);
    }

    public void CloseButton()
    {
        Time.timeScale = 1;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        closeButton.SetActive(!closeButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
        volumeSlider.transform.gameObject.SetActive(false);
    }

    public void VolumeSlider()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void MusicToggle()
    {
        audioSource.mute = !audioSource.mute;
        audioSource2.mute = !audioSource2.mute;
    }

    
}
