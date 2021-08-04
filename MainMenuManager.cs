using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsText;                        //������ �� ����� �� ������

    public void PlayGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButton()
    {
        if (!creditsText.activeInHierarchy) creditsText.SetActive(true);                //���� ����� �� ������ ������� - ������ �� �������� � ��������
        else creditsText.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();                                                             //������� �� ����������
    }
}
