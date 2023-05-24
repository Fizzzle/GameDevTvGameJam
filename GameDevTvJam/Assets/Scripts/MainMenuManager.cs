/*
    Author: Sergey
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject optionsUI; // объект для UI окна параметров
    [SerializeField] GameObject authorsUI; // объект для UI окна авторов
    [SerializeField] AudioSource menuMusic; // объект для UI окна авторов
    [SerializeField] Toggle musicOnOff; // объект для UI окна авторов

    // Start is called before the first frame update
    void Start()
    {
        optionsUI.SetActive(false); // Изначально окна настроек и авторов не активны
        authorsUI.SetActive(false);
        musicOnOff.onValueChanged.AddListener(ToggleMusic);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // функция для начала игры (level_1) - Sergey
    public void StartGame()
    {
        SceneManager.LoadScene("level_1"); // Замените "Level_1" на имя вашей сцены с первым уровнем
    }

    // функция для открытия UI окна для параметров - Sergey
    public void OpenSettingsUI()
    {
        optionsUI.SetActive(true);
        authorsUI.SetActive(false);
    }

    // функция для открытия окна с авторами - Sergey
    public void OpenAuthorsUI()
    {
        authorsUI.SetActive(true);
        optionsUI.SetActive(false);
    }

    // функция для закрытия игры и выхода - Sergey
    public void QuitGame()
    {
        Application.Quit();
    }

    // функция для включения выключения музыки в меню - Sergey
    public void ToggleMusic(bool isMusicEnabled)
    {
        if (isMusicEnabled)
        {
            menuMusic.Play();
        }
        else
        {
            menuMusic.Stop();
        }
    }
}
