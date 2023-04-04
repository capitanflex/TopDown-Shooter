using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    private Transform radiationObj;
    private GameObject player;

    public float radiationPower;
    private float radiationDamage;
    private float distanceToPlayer;

    private void Start()
    {
        radiationObj = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            distanceToPlayer = Vector3.Distance(radiationObj.position, player.transform.position);
            radiationDamage = radiationPower * distanceToPlayer;
            player.GetComponent<HealthPlayer>().GetRadiation(radiationDamage);
        }
    }
}
