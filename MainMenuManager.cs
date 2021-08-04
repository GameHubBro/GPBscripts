using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsText;                        //ссылка на текст об авторе

    public void PlayGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButton()
    {
        if (!creditsText.activeInHierarchy) creditsText.SetActive(true);                //если текст об авторе активен - делаем не активным и наоборот
        else creditsText.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();                                                             //выходим из приложения
    }
}
