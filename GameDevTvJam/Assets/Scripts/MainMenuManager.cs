using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject optionsUI; // Предположим, что у вас есть объект для UI окна параметров
    [SerializeField] GameObject authorsUI; // Предположим, что у вас есть объект для UI окна авторов

    // Start is called before the first frame update
    void Start()
    {
        optionsUI.SetActive(false); // Изначально окна настроек и авторов не активны
        authorsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // функция для начала игры (level_1)
    public void StartGame()
    {
        SceneManager.LoadScene("level_1"); // Замените "Level_1" на имя вашей сцены с первым уровнем
    }

    // функция для открытия UI окна для параметров
    public void OpenSettingsUI()
    {
        optionsUI.SetActive(true);
    }

    // функция для открытия окна с авторами
    public void OpenAuthorsUI()
    {
        authorsUI.SetActive(true);
    }

    // функция для закрытия игры и выхода
    public void QuitGame()
    {
        Application.Quit();
    }
}
