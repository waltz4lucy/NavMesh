using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent agent;
    private float patrolRadius;
    private float patrolTimer;
    private float timer;
    private Transform target;

    void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        patrolRadius = Random.Range(3, 5);
        patrolTimer = Random.Range(1, 5);
        timer = patrolTimer;
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= patrolTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, patrolRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
