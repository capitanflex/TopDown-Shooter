using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private EnemyParametrs enemyParametrs;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthPlayer>().GetDamage(enemyParametrs.damage);
        }
    }
}