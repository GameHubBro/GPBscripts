using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement: MonoBehaviour
{
    
    [SerializeField] private Transform[] targets;                               //массив целей врага
    [SerializeField] private bool isCycle = false;                              //заклено ли движение врага

    private NavMeshAgent agent;                                                 
    private int targetIndex = 0;                                                //индекс цели
    private bool isMovingForward = true;                                        //переменная двигается ли враг вперед

    private void Start()
    {    
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ChangeTarget();
    }

    private void ChangeTarget()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)                  //если враг достигает цели
        {
            if (isCycle)                                                        //если  враг двигается в цикле, то если не последняя цель в массиве, то целью становится следующая в массиве цель. А если последняя в массиве цель
            {
                if (targetIndex < targets.Length - 1)
                {
                    targetIndex++;
                }
                else          
                {
                    targetIndex = 0;
                }  
            }
            else                                                               //если враг двигается не в цикле
            {
                if (isMovingForward)                                            //и если движется вперед, то
                {
                    if (targetIndex < targets.Length - 1)                       //если цель не последняя в массиве, то делаем целью следующую в массиве
                    {
                        targetIndex++;
                    }
                    else                                                        //если цель последняя в массиве, то целью делаем предыдущую и разворачиваем врага
                    {
                        isMovingForward = false;
                        targetIndex--;
                    }
                }
                else                                                           //если враг движется назад, то
                {
                    if (targetIndex > 0)                                       //если цель не первая, то делаем целью предыдущую
                    {
                        targetIndex--;
                    }
                    else                                                       //если цель первая, то делаем целью следующую в массиве и разворачиваем врага
                    {
                        isMovingForward = true;
                        targetIndex++;
                    }
                }
            }
            agent.destination = targets[targetIndex].position;                  //устанавливаем агенту пункт назначения - цель под индексом
        }
    }
}
