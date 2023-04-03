using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private float maxHealthPlayer = 100;
    private float currentHealthPlayer;

    private float radiationProtection;
    private float damageProtection = 0.5f;

    private void Start()
    {
        currentHealthPlayer = maxHealthPlayer;
    }

    public void GetDamage(float damage)
    {
        currentHealthPlayer -= damage * damageProtection;
    }

    private void Update()
    {
        if (currentHealthPlayer <= 0)
        {
            // animation смерти
        }
    }
}
