using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRaycast : MonoBehaviour
{
    private float maxDistance = 12f;                                        //макс дистанция на которую видят враги

    private void Update()
    {   if (MenuManager.isGameinProgress)                                   //если игра в процессе
        {
            RaycastHit hit;                                                 

            //if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward * maxDistance, out hit)) 
            /*if (Physics.BoxCast(transform.position, new Vector3(2, 2, 2), transform.forward, out hit, Quaternion.identity, maxDistance))*/ //если куб смотрящий вперед на расстояние макс. дистанции попадает куда-то, то
            if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Player"))                                                              //если это игрок, то
                {
                    MenuManager.gameOver = true;                                                                                //публичную статическую переменную gameOver делаем true
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);            //рисуем луч вперед на расстояние макс. дистанции
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, new Vector3(2, 2, 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && MenuManager.isGameinProgress)                 //если игрок попадает в коллайдер и игра в процессе, то публичную статическую переменную gameOver делаем true
        {
            MenuManager.gameOver = true;
        }
    }
}
