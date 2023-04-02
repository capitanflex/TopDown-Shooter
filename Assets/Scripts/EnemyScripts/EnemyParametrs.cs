using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Enemy/New Enemy")]
public class EnemyParametrs : ScriptableObject
{
    public float healthPoint;
    public float damage;
    public float timeAttackDelay;
    public float zombieMovement;
    public float rangeAttack;
    public float rangeChase;
    public float rangeStopping;
}