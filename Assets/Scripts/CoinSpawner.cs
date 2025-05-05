using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 2f; // Coins will now spawn every 2 seconds
    public float initialJumpForce = 200f;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            GameObject spawnedCoin = Instantiate(coinPrefab, transform.position, transform.rotation);

            Rigidbody coinRb = spawnedCoin.GetComponent<Rigidbody>();
            if (coinRb != null)
            {
                coinRb.AddForce(Vector3.up * initialJumpForce);
            }
            else
            {
                Debug.LogWarning("Spawned coin does not have a Rigidbody component to apply initial jump!");
            }
        }
        else
        {
            Debug.LogError("Coin Prefab is not assigned in the CoinSpawner!");
        }
    }
}