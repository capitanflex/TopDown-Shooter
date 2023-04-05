using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New GunParameters", menuName = "GunParameters", order = 51)]
public class GunParams : ScriptableObject
{
    public int currentMagazineSize;
    public int magazineSize;
    public float reloadTime;
    public float fireRate;
    public GameObject bulletPrefab;
    public GameObject gunPrefab;

    public Sprite icon;
}
