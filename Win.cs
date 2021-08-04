using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static bool isGameWon = false;                       //переменная выиграна ли игра
    public static bool isGameEnded = false;                     //переменная конца игры

    private void OnTriggerEnter(Collider other)                
    {
        if (other.CompareTag("Player"))
        {
            isGameWon = true;
            isGameEnded = true;
        }
    }  
}
