using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform attackPos;
    [SerializeField] Transform target;

    NavMeshAgent agent;

    private void Start()
    {
        attackPos = GameObject.FindGameObjectWithTag("AttackPos").transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(attackPos.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttackPos")
        {
            transform.LookAt(target);
        }
    }
}
