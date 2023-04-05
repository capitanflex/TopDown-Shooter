using UnityEngine;

public class EquipController : MonoBehaviour
{
    public EquipmentData equipmentData;
    
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>()
            .GetStats(equipmentData.radiationProtection,
                equipmentData.damageProtection);  
    }
}
