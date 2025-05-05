using System.Collections;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject coinPrefab;         // Prefab for the coin to spawn
    [SerializeField] private float coinLaunchVelocity = 8f; // Upward velocity for the coin
    [SerializeField] private float coinLifetime = 2f;       // How long the coin exists before disappearing

    [Header("Animation")]
    [SerializeField] private float bounceHeight = 0.2f;     // How high the block bounces
    [SerializeField] private float bounceDuration = 0.15f;  // How long the bounce animation takes
    [SerializeField] private Sprite emptyBlockSprite;       // Sprite to show after being hit
    [SerializeField] private SpriteRenderer spriteRenderer; // The block's SpriteRenderer

    private Vector3 originalPosition;
    private bool hasBeenHit = false;
    private bool isBouncing = false;

    void Start()
    {
        originalPosition = transform.position;

        // Ensure required components are assigned
        
        if (emptyBlockSprite == null)
        {
            Debug.LogWarning("EmptyBlockSprite not assigned on QuestionBlock. Block will not change sprite.", this);
        }
        if (coinPrefab == null)
        {
            Debug.LogWarning("CoinPrefab not assigned on QuestionBlock. No coin will spawn.", this);
        }
    }

    // Detect collision (Ensure the Player GameObject has the "Player" tag)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if it's the player hitting from below (optional, but common)
        // For simplicity, we'll just check the tag and if it's already hit/bouncing
        if (!hasBeenHit && !isBouncing && collision.gameObject.CompareTag("Player"))
        {
            // Check if the player hit the bottom of the block
            ContactPoint2D contact = collision.GetContact(0);
            // contact.normal.y > 0.5f means the collision normal points mostly upwards (hit from below)
            if (contact.normal.y > 0.5f)
            {
                Hit();
            }
        }
    }

    // Called when the block is hit successfully
    private void Hit()
    {
        hasBeenHit = true;
        StartCoroutine(BounceAndSpawnCoin());

        // Change to empty sprite immediately (or could be done after animation)
        if (spriteRenderer != null && emptyBlockSprite != null)
        {
            spriteRenderer.sprite = emptyBlockSprite;
        }
    }

    // Coroutine for the bounce animation and coin spawning
    IEnumerator BounceAndSpawnCoin()
    {
        isBouncing = true;

        // --- Bounce Animation ---
        Vector3 startPos = originalPosition;
        Vector3 targetPos = originalPosition + Vector3.up * bounceHeight;
        float elapsedTime = 0f;

        // Move up
        while (elapsedTime < bounceDuration / 2f)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / (bounceDuration / 2f));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        transform.position = targetPos; // Ensure it reaches the peak

        // --- Spawn Coin (at the peak of the bounce) ---
        SpawnCoin();

        // Move down
        elapsedTime = 0f; // Reset timer for downward movement
        while (elapsedTime < bounceDuration / 2f)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, elapsedTime / (bounceDuration / 2f));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        transform.position = startPos; // Ensure it returns exactly to the original position

        isBouncing = false;
    }

    // Handles spawning and launching the coin
    private void SpawnCoin()
    {
        if (coinPrefab == null) return; // Don't spawn if no prefab assigned

        // Spawn coin slightly above the block's original position
        GameObject coin = Instantiate(coinPrefab, originalPosition + Vector3.up * 0.5f, Quaternion.identity);
        Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();

        if (coinRb != null)
        {
            // Apply a simple upward force/velocity
            // Using AddForce with Impulse mode OR setting velocity directly can work.
            // Velocity change is often more direct for immediate launch speed.
            coinRb.velocity = Vector2.up * coinLaunchVelocity;

            // Optional: Add a very slight random horizontal push
            // coinRb.AddForce(Vector2.right * Random.Range(-0.5f, 0.5f), ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Spawned Coin Prefab does not have a Rigidbody2D component.", coin);
        }

        // Destroy the coin after its lifetime
        Destroy(coin, coinLifetime);
    }
}