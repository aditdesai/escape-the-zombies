using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
