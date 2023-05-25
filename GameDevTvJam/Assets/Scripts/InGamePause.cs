/*
    Author: Sergey

Этот скрипт используется на паузе в MainScene.
Другой можно удалять.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGamePause : MonoBehaviour
{
    // создаем переменную для хранения состояния паузы
    public static bool isPaused = false;
    [SerializeField] private GameObject _pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        _pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Если игрок нажимает клавишу Escape, мы переключаем состояние паузы
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // функция для возобновления игры (снять паузу)
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // возобновляем ход времени
        _pausePanel.SetActive(false);
    }

    // функция для паузы игры
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // останавливаем ход времени
        _pausePanel.SetActive(true);
    }

    // функция для выхода в главное меню
    public void GoToMainMenu()
    {
        Time.timeScale = 1; // убедимся, что время идет нормально
        SceneManager.LoadScene("startMenu"); // замените "MainMenu" на имя вашей сцены главного меню
    }

    // функция для выхода из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}
