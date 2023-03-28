using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DronePatrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject currentWaypoint;
    GameObject PreviousWaypoint;
    GameObject[] allWaypoints;
    bool travelling;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        allWaypoints=GameObject.FindGameObjectsWithTag("Waypoint");
        currentWaypoint = GetRandomWaypoint();
        SetDestination();
    }
    void Update()
    {
        if (travelling && navMeshAgent.remainingDistance <=1f)
        {
            travelling = false;
            SetDestination();
        }
    }
    private void SetDestination()
    {
        PreviousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        travelling = true;
    }

    public GameObject GetRandomWaypoint()
    {
        if(allWaypoints.Length==0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }
}
