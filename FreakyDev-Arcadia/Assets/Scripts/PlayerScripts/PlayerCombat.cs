using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CombatManager.Instance.Attack();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            CombatManager.Instance.Heal(20);
        }
    }
}
