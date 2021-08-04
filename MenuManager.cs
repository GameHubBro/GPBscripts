using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;                     //������ ������ ����
    [SerializeField] private GameObject menuPanel;                      //������ ���� ����
    [SerializeField] private GameObject winPanel;                       //������ ��� ������
    [SerializeField] private GameObject pauseBut;                       //������ �����
    [SerializeField] private GameObject bustedImage;                    //�������� ���������
    [SerializeField] private GameObject winImage;                       //�������� ������
    [SerializeField] private AudioSource mainMusic;                     //������
    [SerializeField] private AudioSource loseSound;                     //���� ���������
    [SerializeField] private AudioSource winSound;                      //���� ������

    public static bool isGameinProgress = false;                        //���������� � �������� �� ����
    public static bool gameOver = false;                                //���������� ��������� �� ����

    private void Start()
    {
        Time.timeScale = 0f;                                            //�� ������ ������������� �����
    }

    private void LateUpdate()
    {
        if (gameOver)                                                   //���� ���� ��������� ����� ��������� ����� GameOver � ���������� ����� ���� ������ � false
        {
            GameOver();
        }

        if (Win.isGameWon)                                              //���� ���� �������� ����� ��������� ����� GameWon, ���������� ���������� � ���������� ����������� ���� ������ � false
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
        Time.timeScale = 0f;                                    //������������� �����
        menuPanel.SetActive(true);                              //������ ���� ������ ��������
        pauseBut.SetActive(false);                              //������ ����� ������ �� ��������
        isGameinProgress = false;                               //���� �� � ��������
    }

    private void GameOn()
    {
        Time.timeScale = 1f;                                    //��������� �����
        startPanel.SetActive(false);                            //��������� ������ ��������
        menuPanel.SetActive(false);                             //������ ���� ��������
        pauseBut.SetActive(true);                               //���������� ������ �����
        isGameinProgress = true;                                //���� � ��������
    }

    private void GameOver()
    {
        Time.timeScale = 0.2f;                                  //��������� �����
        bustedImage.SetActive(true);                            //�������� ��������� ������ ��������
        isGameinProgress = false;                               //���� �� � ��������
        mainMusic.Stop();                                       //������������� ������
        loseSound.Play();                                       //��������� ���� ���������
        StartCoroutine(RestartLevel(1f));                       //��������� �������� ����������� ������
        gameOver = false;      
    }

    private void GameWon()                                      
    {
        Time.timeScale = 0.5f;                                  //��������� �����
        winImage.SetActive(true);                               //�������� ������ ������ ��������
        pauseBut.SetActive(false);                              //������ ����� ������ �� ��������
        isGameinProgress = false;                               //���� �� � ��������
        mainMusic.Stop();                                           
        winSound.Play();                                        //�������� ���� ���������
        StartCoroutine(WinLevel(2f));                           //��������� �������� ������ ���������� ������
    }

    IEnumerator RestartLevel(float delay)
    {     
        yield return new WaitForSeconds(delay);
        bustedImage.SetActive(false);                                               //�������� ��������� ������ �� ��������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WinLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        winPanel.SetActive(true);                                                   //������ �������� ������ ��������
    }
}
