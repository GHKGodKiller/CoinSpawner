using UnityEngine;
using System.Collections;

public class CoinMovement : MonoBehaviour
{
    Rigidbody rb;

    void Start() // Use Start instead of Anake, as it's a standard Unity function
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Rotate(0, 2, 0); // Rotate the object around the Y-axis
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
        StartCoroutine(AparitionRoutine());
    }

    IEnumerator AparitionRoutine()
    {
        Debug.Log("AddForce");
        if (rb != null) // Ensure the Rigidbody exists
        {
            rb.AddForce(Vector3.up * 1000f); // Apply an upward force
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Disable");
        gameObject.SetActive(false); // Deactivate the GameObject
    }
}