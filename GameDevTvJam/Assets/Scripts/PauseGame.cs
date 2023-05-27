/*
    Author: Sergey
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;      // объкт для UI окна паузы Panel
    public static bool isPaused = false;

    private bool _isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        _pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseUI.SetActive(true);
            Pause();
        }
    }

    // функция для паузы игры - Sergey
    void Pause()
    {
        _isGamePaused = !_isGamePaused; // переключаем состояние паузы
        Time.timeScale = _isGamePaused ? 0 : 1; // если игра на паузе, устанавливаем временной масштаб в 0, иначе в 1
        _pauseUI.SetActive(_isGamePaused); // активируем или деактивируем UI паузы в зависимости от состояния паузы
    }

    // функция для возобновления игры (снять паузу)
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // возобновляем ход времени
        _pauseUI.SetActive(false);
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
