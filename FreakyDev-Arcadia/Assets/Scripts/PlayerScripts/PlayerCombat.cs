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
        // Forward the attack or heal inputs to the CombatManager's PlayerAction
        if (Input.GetKeyDown(KeyCode.A))
        {
            CombatManager.Instance.PlayerAction("attack");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            CombatManager.Instance.PlayerAction("heal");
        }
    }
}
