using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;                     //панель старта игры
    [SerializeField] private GameObject menuPanel;                      //панель меню игры
    [SerializeField] private GameObject winPanel;                       //панель при победе
    [SerializeField] private GameObject pauseBut;                       //кнопка паузы
    [SerializeField] private GameObject bustedImage;                    //картинка проигрыша
    [SerializeField] private GameObject winImage;                       //картинка победы
    [SerializeField] private AudioSource mainMusic;                     //музыка
    [SerializeField] private AudioSource loseSound;                     //звук проигрыша
    [SerializeField] private AudioSource winSound;                      //звук победы

    public static bool isGameinProgress = false;                        //переменная в процессе ли игра
    public static bool gameOver = false;                                //переменная закончена ли игра

    private void Start()
    {
        Time.timeScale = 0f;                                            //на старте останавливаем время
    }

    private void LateUpdate()
    {
        if (gameOver)                                                   //если игра закончена тогда запускаем метод GameOver и переменную конца игры делаем в false
        {
            GameOver();
        }

        if (Win.isGameWon)                                              //если игра выиграна тогда запускаем метод GameWon, выиграшную переменную и переменную продолжения игры ставим в false
        {
            Win.isGameWon = false;
            GameWon();
            isGameinProgress = false;
        }
    }

    public void GotItButton()
    {
        GameOn();
    }

    public void ResumeGame()
    {
        GameOn();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseButton()
    {
        GamePaused();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GamePaused()
    {
        Time.timeScale = 0f;                                    //останавливаем время
        menuPanel.SetActive(true);                              //панель меню делаем активной
        pauseBut.SetActive(false);                              //кнопку паузы делаем не активной
        isGameinProgress = false;                               //игра не в процессе
    }

    private void GameOn()
    {
        Time.timeScale = 1f;                                    //запускаем время
        startPanel.SetActive(false);                            //стартовую панель скрываем
        menuPanel.SetActive(false);                             //панель меню скрываем
        pauseBut.SetActive(true);                               //показываем кнопку паузы
        isGameinProgress = true;                                //игра в процессе
    }

    private void GameOver()
    {
        Time.timeScale = 0.2f;                                  //замедляем время
        bustedImage.SetActive(true);                            //картинку проигрыша делаем активной
        isGameinProgress = false;                               //игра не в процессе
        mainMusic.Stop();                                       //останавливаем музыку
        loseSound.Play();                                       //запускаем звук проигрыша
        StartCoroutine(RestartLevel(1f));                       //запускаем курутину перезапуска уровня
        gameOver = false;      
    }

    private void GameWon()                                      
    {
        Time.timeScale = 0.5f;                                  //замедляем время
        winImage.SetActive(true);                               //картинку победы делаем активной
        pauseBut.SetActive(false);                              //кнопку паузы делаем не активной
        isGameinProgress = false;                               //игра не в процессе
        mainMusic.Stop();                                           
        winSound.Play();                                        //победный звук запускаем
        StartCoroutine(WinLevel(2f));                           //запускаем курутину показа выигрышной панели
    }

    IEnumerator RestartLevel(float delay)
    {     
        yield return new WaitForSeconds(delay);
        bustedImage.SetActive(false);                                               //картинку проигрыша делаем не активной
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WinLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        winPanel.SetActive(true);                                                   //панель выигрыша делаем активной
    }
}
