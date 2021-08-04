using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private LayerMask layersToHit;             //���� �� ������� ��������� ���

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (MenuManager.isGameinProgress || Win.isGameEnded)                       //���� ���� � �������� ��� ���� ��������
        {
            if (Input.GetMouseButtonDown(0))                    //���� ������ ���
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layersToHit))           //���� ��� �� ������ � ����� ����� ���� �������� � ����
                {
                    agent.destination = hit.point;                                          //������� ������ � ��� �����
                }
            }
        }
        else if (!MenuManager.isGameinProgress)
        {
            agent.destination = transform.position;
        }
    }
}
