using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRaycast : MonoBehaviour
{
    private float maxDistance = 12f;                                        //���� ��������� �� ������� ����� �����

    private void Update()
    {   if (MenuManager.isGameinProgress)                                   //���� ���� � ��������
        {
            RaycastHit hit;                                                 

            //if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward * maxDistance, out hit)) 
            /*if (Physics.BoxCast(transform.position, new Vector3(2, 2, 2), transform.forward, out hit, Quaternion.identity, maxDistance))*/ //���� ��� ��������� ������ �� ���������� ����. ��������� �������� ����-��, ��
            if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Player"))                                                              //���� ��� �����, ��
                {
                    MenuManager.gameOver = true;                                                                                //��������� ����������� ���������� gameOver ������ true
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);            //������ ��� ������ �� ���������� ����. ���������
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, new Vector3(2, 2, 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && MenuManager.isGameinProgress)                 //���� ����� �������� � ��������� � ���� � ��������, �� ��������� ����������� ���������� gameOver ������ true
        {
            MenuManager.gameOver = true;
        }
    }
}
