using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerController : MonoBehaviour
{
    // Variables to track player stats
    public int maxHealth = 100;  // Maximum health
    private int health;          // Current health
    public int blockDefenseValue = 10;  // Amount of damage blocked when defending
    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public float attackRate = 1f; // attacks per second
    private float nextAttackTime = 0f;

    public int attackDamage = 25;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private Rigidbody2D rb;
    private Vector2 movement;
    public Spell[] spells;
    private int selectedSpellIndex = 0;
    private float[] spellCooldownTimers;
    public float dodgeSpeed = 10f;
    public float dodgeDuration = 0.2f;
    public float dodgeCooldown = 1f;
    private bool isDodging = false;
    private float nextDodgeTime = 0f;
    public bool isBlocking = false;
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 5f;
    public int attackStaminaCost = 20;  // Stamina cost per attack
    public int blockStaminaCost = 10;   // Stamina cost for blocking


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spellCooldownTimers = new float[spells.Length];
        currentStamina = maxStamina;
    }

    void Update()
    {
        // Movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Attack input
        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttackTime)
        {
            MeleeAttack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        // Ranged attack input
        if (Input.GetButtonDown("Fire2") && Time.time >= nextAttackTime)
        {
            RangedAttack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            CastSpell();
        }

        // Spell selection input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedSpellIndex = (selectedSpellIndex + 1) % spells.Length;
        }
        if (Input.GetButtonDown("Jump") && Time.time >= nextDodgeTime)
        {
            StartCoroutine(Dodge());
            nextDodgeTime = Time.time + dodgeCooldown;
        }
        if (Input.GetButtonDown("Block"))
        {
            isBlocking = true;
            // animator.SetBool("isBlocking", true);
        }
        else if (Input.GetButtonUp("Block"))
        {
            isBlocking = false;
            // animator.SetBool("isBlocking", false);
        }
        RegenerateStamina();
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void MeleeAttack()
    {
        // Play attack animation
        // animator.SetTrigger("Attack");
            if (currentStamina >= attackStaminaCost)
            {
                currentStamina -= attackStaminaCost;
                // Detect enemies in range
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                // Damage enemies
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
                }
            }
            else
            {
                Debug.Log("Not enough stamina to attack");
            }


    }

    void RangedAttack()
    {
        // Instantiate projectile
        // Implement projectile logic in a separate script
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // Draw attack range in editor
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void CastSpell()
    {
        Spell spell = spells[selectedSpellIndex];

        if (Time.time >= spellCooldownTimers[selectedSpellIndex])
        {
            // Check if player has enough mana
            // Implement mana system accordingly

            spell.Cast(gameObject);
            spellCooldownTimers[selectedSpellIndex] = Time.time + spell.cooldownTime;
        }
        else
        {
            Debug.Log("Spell is on cooldown");
        }
    }
    IEnumerator Dodge()
    {
        isDodging = true;
        float startTime = Time.time;

        while (Time.time < startTime + dodgeDuration)
        {
            rb.MovePosition(rb.position + movement.normalized * dodgeSpeed * Time.fixedDeltaTime);
            yield return null;
        }

        isDodging = false;
    }
    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            damage = Mathf.Max(0, damage - blockDefenseValue);  // Reduce damage when blocking
            currentStamina -= blockStaminaCost;  // Deduct stamina for blocking
        }

        health -= damage;  // Apply damage to player's health

        if (health <= 0)
        {
            Die();
        }
    }
    private void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += (int)(staminaRegenRate * Time.deltaTime);
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
    }
    // Function to gain experience
    private void Die()
    {
        Debug.Log("Player has died.");
        // Handle death logic (e.g., respawn or game over)
    }
}*/

