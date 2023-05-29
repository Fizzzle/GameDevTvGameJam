using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Нужно для работы с сценами

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] private ParticleSystem finishParticles;
    [SerializeField] private GameObject suggestionText;
    // Start is called before the first frame update
    void Start()
    {
        suggestionText.SetActive(false);
        Invoke("ShowSuggestion", 300f); // показать подсказку через 5 минут
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadNext();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishParticles.Play();
            Invoke("LoadNext", 3f);
        }
    }

    // показать подсказку что нажать К для перехода на следующий уровень.
    void ShowSuggestion()
    {
        suggestionText.SetActive(true);
    }

    // функция для перехода из текущей сцены на следующую и проверка, если эта сцена не последняя, если да то в главное меню
    public void LoadNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Получаем индекс текущей сцены
        int totalSceneCount = SceneManager.sceneCountInBuildSettings; // Получаем общее количество сцен

        // Если текущая сцена не последняя, переходим к следующей
        if (currentSceneIndex < totalSceneCount - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else // Если текущая сцена последняя, возвращаемся к главному меню
        {
            SceneManager.LoadScene("startMenu");
        }
    }
}
