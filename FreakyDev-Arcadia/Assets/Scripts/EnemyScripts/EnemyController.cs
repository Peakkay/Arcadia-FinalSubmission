using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int maxHealth = 100;
    private int currentHealth;

    public Transform player;
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public int enemyHealth = 50;


    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null)
            return;

        // Calculate direction towards player
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction;

        // Attack player if in range
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            StartCoroutine(Attack());
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void FixedUpdate()
    {
        // Move enemy towards player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Attack()
    {
        // Play attack animation
        // animator.SetTrigger("Attack");

        // Wait for animation to finish
        yield return new WaitForSeconds(0.5f);

        // Deal damage to player
        player.GetComponent<PlayerController>().TakeDamage(attackDamage);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    

    private void Die()
    {
        Destroy(gameObject);
    }
}

