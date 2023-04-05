using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // ссылка на игрока
    public float moveSpeed = 5f; // скорость движения
    public float rotSpeed = 3f; // скорость поворота
    public float shootRange = 10f; // дистанция для стрельбы
    public float hideRange = 5f; // дистанция для прятания за укрытием
    public GameObject[] coverPoints; // массив точек укрытия
    public GameObject bulletPrefab; // префаб пули
    public Transform bulletSpawnPoint; // точка, откуда будут вылетать пули
    public float shootInterval = 0.5f; // интервал между выстрелами
    public float reloadTime = 2f; // время перезарядки
    private float lastShootTime; // время последнего выстрела
    private int bulletsInMagazine = 10; // количество патронов в магазине
    private bool reloading; // перезаряжается ли враг в данный момент
    private Vector3 coverPoint; // точка укрытия, за которой прячется враг
    private bool inCover; // находится ли враг за укрытием
    private Vector3 lastKnownPlayerPosition; // последнее известное положение игрока

    private void Start()
    {
        // Ищем игрока в сцене по тегу
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Выбираем случайную точку укрытия из массива
        coverPoint = coverPoints[Random.Range(0, coverPoints.Length)].transform.position;
    }

    private void Update()
    {
        // Вычисляем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Если игрок на расстоянии для стрельбы и враг не перезаряжается
        if (distanceToPlayer < shootRange && !reloading)
        {
            // Поворачиваемся к игроку
            Vector3 direction = player.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                rotSpeed * Time.deltaTime);

            // Если игрок в поле зрения и враг не за укрытием
            if (CanSeePlayer() && !inCover)
            {
                // Стреляем
                if (Time.time > lastShootTime + shootInterval)
                {
                    Shoot();
                }
            }
            else
            {
                // Если игрок не в поле зрения или враг за укрытием,
                // то прячемся за укрытием
                Hide();
            }
        }
        else
        {
            // Если игрок слишком далеко, то ищем его
            SearchPlayer();
        }
    }

    private void Shoot()
    {
        // Создаем пулю из префаба и выставляем ее направление и скорость
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Уменьшаем количество патронов в магазине
        bulletsInMagazine--;

        // Запоминаем время выстрела
        lastShootTime = Time.time;

        // Если закончились патроны в магазине, начинаем перезарядку
        if (bulletsInMagazine == 0)
        {
            reloading = true;
            Invoke("Reload", reloadTime);
        }
    }

    private void Reload()
    {
        // Перезаряжаем магазин и снимаем флаг перезарядки
        bulletsInMagazine = 10;
        reloading = false;
    }

    private bool CanSeePlayer()
    {
        RaycastHit hit;

        // Проверяем, есть ли на пути к игроку препятствия
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, shootRange))
        {
            // Если препятствия нет и взгляд направлен на игрока
            if (hit.collider.CompareTag("Player"))
            {
                // Запоминаем последнее известное положение игрока
                lastKnownPlayerPosition = player.position;
                return true;
            }
        }

        return false;
    }

    private void Hide()
    {
        // Если уже находимся за укрытием, то ничего не делаем
        if (inCover)
        {
            return;
        }

        
        print("Ищем ближайшую точку укрытия");
        float minDistance = Mathf.Infinity;
        foreach (GameObject coverPoint in coverPoints)
        {
            float distance = Vector3.Distance(transform.position, coverPoint.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                this.coverPoint = coverPoint.transform.position;
            }
        }

        // Двигаемся к точке укрытия
        transform.position = Vector3.MoveTowards(transform.position, coverPoint, moveSpeed * Time.deltaTime);

        // Если находимся достаточно близко к точке укрытия, то прячемся
        if (Vector3.Distance(transform.position, coverPoint) < hideRange)
        {
            inCover = true;
        }
    }

    private void SearchPlayer()
    {
        // Если игрок уже был найден, то двигаемся к последнему известному местоположению игрока
        if (lastKnownPlayerPosition != Vector3.zero)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, lastKnownPlayerPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Если игрок еще не был найден, то двигаемся в случайном направлении
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
            Vector3 targetPosition = hit.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
        }
    }
}