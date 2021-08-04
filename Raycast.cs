using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private float maxDistance = 20f;                                        //���� ��������� �� ������� ����� �����

    private void Update()
    {
            RaycastHit hit;


        /*if (Physics.BoxCast(transform.position, new Vector3(2, 2, 2), transform.forward, out hit, Quaternion.identity, maxDistance))*/ //���� ��� ��������� ������ �� ���������� ����. ��������� �������� ����-��, ��
                                                                                                                                         //if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))    
        //if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward * maxDistance, out hit))
            if (Physics.Raycast(transform.position, transform.forward * maxDistance, out hit))

        {
            Debug.Log("hit smth");
                if (hit.transform.gameObject.CompareTag("Player"))                                                              //���� ��� �����, ��
                {
                Gizmos.color = Color.red;
                Debug.Log("hit player");                                                                              //��������� ����������� ���������� gameOver ������ true
                }
                
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);            //������ ��� ������ �� ���������� ����. ���������
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, new Vector3(2, 2, 2));
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")/* && MenuManager.isGameinProgress*/)                 //���� ����� �������� � ��������� � ���� � ��������, �� ��������� ����������� ���������� gameOver ������ true
    //    {
    //        Debug.Log()
    //    }
    //}
}
