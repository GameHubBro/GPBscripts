using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseCast : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.destination = hit.point;
                obj.transform.position = hit.point;
                //Instantiate(obj, hit.point + new Vector3(0, obj.transform.localScale.y/2 ,0), Quaternion.identity);
            }
        }
    }
}
