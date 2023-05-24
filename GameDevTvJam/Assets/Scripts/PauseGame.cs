/*
    Author: Sergey
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;      // объкт для UI окна паузы Panel
    [SerializeField] private AudioSource _inGameMusic; // объект для UI окна авторов
    [SerializeField] private Toggle _musicOnOff;       // объект для UI окна авторов

    private bool _isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        _pauseUI.SetActive(false);
        _musicOnOff.onValueChanged.AddListener(ToggleMusic);
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

    // функция для включения выключения музыки в игре - Sergey
    public void ToggleMusic(bool isMusicEnabled)
    {
        if (isMusicEnabled)
        {
            _inGameMusic.Play();
        }
        else
        {
            _inGameMusic.Stop();
        }
    }
}
