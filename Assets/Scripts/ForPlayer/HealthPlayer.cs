using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private float maxHealthPlayer = 100;
    private float currentHealthPlayer;
    
    [HideInInspector]
    public float radioactiveInfection;

    private float radiationProtection;
    private float damageProtection;

    private void Start()
    {
        currentHealthPlayer = maxHealthPlayer;
        radiationProtection = 1;
        damageProtection = 1;
    }

    public void GetStats(float _radiationProtection, float _damageProtection)
    {
        this.radiationProtection = _radiationProtection;
        this.damageProtection = _damageProtection;
    }
    public void GetDamage(float damage)
    {
        currentHealthPlayer -= damage / damageProtection;
    }
    
    public void GetRadiation(float radiationDamage)
    {
        if(radioactiveInfection < 100)
        radioactiveInfection += radiationDamage;
    }

    private void GetRadDamage()
    {
        float deltaTime = Time.deltaTime;
        currentHealthPlayer -= (radioactiveInfection / radiationProtection)  * deltaTime;
    }

    private void Update()
    {
        GetRadDamage();
        if (currentHealthPlayer <= 0)
        {
            Time.timeScale = 0.1f;
            // animation смерти
        }
    }
}
