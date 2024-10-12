using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Chasing, Attacking }
    public State currentState;

    public Transform player;
    public float detectionRange = 5f;
    public float attackRange = 1f;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Idle:
                if (distance <= detectionRange)
                {
                    currentState = State.Chasing;
                }
                break;

            case State.Chasing:
                if (distance <= attackRange)
                {
                    currentState = State.Attacking;
                }
                else if (distance > detectionRange)
                {
                    currentState = State.Idle;
                }
                else
                {
                    // Move towards player
                }
                break;

            case State.Attacking:
                if (distance > attackRange)
                {
                    currentState = State.Chasing;
                }
                else
                {
                    // Attack player
                }
                break;
        }
    }
}

