using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private LayerMask layersToHit;             //слой на который действует луч

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (MenuManager.isGameinProgress || Win.isGameEnded)                       //если игра в процессе или игра выиграна
        {
            if (Input.GetMouseButtonDown(0))                    //если нажата ЛКМ
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layersToHit))           //если луч из камеры в точку клика мыши попадает в слой
                {
                    agent.destination = hit.point;                                          //двигаем агента в эту точку
                }
            }
        }
        else if (!MenuManager.isGameinProgress)
        {
            agent.destination = transform.position;
        }
    }
}
