using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;
    GroundSpawner wallSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObsPrefab;
    [SerializeField] float tallObsChance = 0.2f;
    

    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        wallSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        //escolher qual dar spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);

        if(random < tallObsChance){
            obstacleToSpawn = tallObsPrefab;
        }

        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins ()
    {
        int coinsToSpawn = 5;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        point.x = GetRandomValue(-3f, 0f, 3f);
        return point;
    }

    float GetRandomValue(params float[] values)
    {
        int randomIndex = Random.Range(0, values.Length);
        return values[randomIndex];
    }
}