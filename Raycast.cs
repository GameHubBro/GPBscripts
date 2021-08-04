using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private float maxDistance = 20f;                                        //макс дистанция на которую видят враги

    private void Update()
    {
            RaycastHit hit;


        /*if (Physics.BoxCast(transform.position, new Vector3(2, 2, 2), transform.forward, out hit, Quaternion.identity, maxDistance))*/ //если куб смотрящий вперед на расстояние макс. дистанции попадает куда-то, то
                                                                                                                                         //if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))    
        //if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward * maxDistance, out hit))
            if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))

        {
            Debug.Log("hit smth");
                if (hit.transform.gameObject.CompareTag("Player"))                                                              //если это игрок, то
                {
                Gizmos.color = Color.red;
                Debug.Log("hit player");                                                                              //публичную статическую переменную gameOver делаем true
                }
                
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);            //рисуем луч вперед на расстояние макс. дистанции
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, new Vector3(2, 2, 2));
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")/* && MenuManager.isGameinProgress*/)                 //если игрок попадает в коллайдер и игра в процессе, то публичную статическую переменную gameOver делаем true
    //    {
    //        Debug.Log()
    //    }
    //}
}
