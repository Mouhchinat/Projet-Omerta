using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrategiesV2 : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public EnemyData enemyData;
    public Transform playerTransform;
    public Player player;
    
    void Start()
    {
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        if (enemyData != null)
        {
            LoadEnemy(enemyData);
        }

        current = 0;
    }
    
    private void LoadEnemy(EnemyData _data)
    {
        // Supprime tous les child de l'empty s'il y en a 
        foreach (Transform child in transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        navAgent.speed = enemyData.speed;
    }

    
    
    public void patrol()
    {
        navAgent.speed = enemyData.speed;
        if (transform.position != points[current].position)
        {
            navAgent.SetDestination(points[current].position);
        }
        else
        {
            current = (current + 1) % points.Length;
            navAgent.SetDestination(points[current].position);
        }
    }

    public void chase()
    {
        navAgent.speed = 2 * enemyData.speed;
        navAgent.SetDestination(playerTransform.position);
    }

    public void attack()
    {
        navAgent.SetDestination(navAgent.transform.position);
        transform.LookAt(playerTransform);
        enemyData.Attack(player);
    }
    
    
    public bool playerInSightRange, playerInAttackRange;
    public Transform[] points;
    private int current;

    void Update()
    {
        playerInSightRange = Vector3.Distance(transform.position, playerTransform.position) < enemyData.sightRange;
        playerInAttackRange = Vector3.Distance(transform.position, playerTransform.position) < enemyData.attackRange;
        
        
        if (playerInAttackRange)
        {
            attack();
        }
        else if (playerInSightRange)
        {
            chase();
        }
        else
        {
            patrol();
        }
    }
}