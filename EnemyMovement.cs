using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement: MonoBehaviour
{
    
    [SerializeField] private Transform[] targets;                               //������ ����� �����
    [SerializeField] private bool isCycle = false;                              //������� �� �������� �����

    private NavMeshAgent agent;                                                 
    private int targetIndex = 0;                                                //������ ����
    private bool isMovingForward = true;                                        //���������� ��������� �� ���� ������

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
        if (agent.remainingDistance <= agent.stoppingDistance)                  //���� ���� ��������� ����
        {
            if (isCycle)                                                        //����  ���� ��������� � �����, �� ���� �� ��������� ���� � �������, �� ����� ���������� ��������� � ������� ����. � ���� ��������� � ������� ����
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
            else                                                               //���� ���� ��������� �� � �����
            {
                if (isMovingForward)                                            //� ���� �������� ������, ��
                {
                    if (targetIndex < targets.Length - 1)                       //���� ���� �� ��������� � �������, �� ������ ����� ��������� � �������
                    {
                        targetIndex++;
                    }
                    else                                                        //���� ���� ��������� � �������, �� ����� ������ ���������� � ������������� �����
                    {
                        isMovingForward = false;
                        targetIndex--;
                    }
                }
                else                                                           //���� ���� �������� �����, ��
                {
                    if (targetIndex > 0)                                       //���� ���� �� ������, �� ������ ����� ����������
                    {
                        targetIndex--;
                    }
                    else                                                       //���� ���� ������, �� ������ ����� ��������� � ������� � ������������� �����
                    {
                        isMovingForward = true;
                        targetIndex++;
                    }
                }
            }
            agent.destination = targets[targetIndex].position;                  //������������� ������ ����� ���������� - ���� ��� ��������
        }
    }
}
