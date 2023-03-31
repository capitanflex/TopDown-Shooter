using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private GunParams pistol;
    [SerializeField] private GunParams automat;

    private GameObject currentGun;
    private BaseGun _baseGun;
    void Start()
    {
        currentGun = Instantiate(gunPrefab, gunPoint.position, transform.rotation);
        currentGun.transform.SetParent(gameObject.transform);
        _baseGun = new Pistol(pistol.magazineSize, pistol.reloadTime,pistol.fireRate , pistol.bulletPrefab, pistol.gunPrefab);
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _baseGun.currentMagazineSize > 0)
        {
            _baseGun.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _baseGun.Reload();
        }
        _baseGun.Update();
        ChangeGun();
    }

    private void ChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGun);
            currentGun = Instantiate( pistol.gunPrefab, gunPoint.position, transform.rotation);
            currentGun.transform.SetParent(gameObject.transform);
            _baseGun = new Pistol(pistol.magazineSize, pistol.reloadTime,pistol.fireRate , pistol.bulletPrefab, pistol.gunPrefab);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGun);
            currentGun = Instantiate( automat.gunPrefab, gunPoint.position, transform.rotation);
            currentGun.transform.SetParent(gameObject.transform);
            _baseGun = new AutomaticGun(automat.magazineSize, automat.reloadTime,automat.fireRate , automat.bulletPrefab, automat.gunPrefab);
            
            
        }
    }
    
}
