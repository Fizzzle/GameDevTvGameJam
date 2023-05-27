/*
 * AUTHOR: SERHII
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    [SerializeField] private ParticleSystem victoryParticles; // партиклы для победы

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        victoryParticles.Play();
        // дописать здесь еще вылет партиклов на финише

        Invoke("LoadNext", 3f);
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
