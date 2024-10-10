using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fireball Spell", menuName = "Spells/Fireball")]
public class FireballSpell : Spell
{
    public GameObject projectilePrefab;
    public float projectileSpeed;

    public override void Cast(GameObject caster)
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, caster.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = caster.transform.right * projectileSpeed;

        // Implement projectile behavior (damage, effects) in projectile script
    }
}
