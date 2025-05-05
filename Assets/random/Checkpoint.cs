using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private LevelManager LvlMan;

    private void Start()
    {
        LvlMan = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.tag == "Player")
        {
            LvlMan.currentCP = gameObject;

            Debug.Log("CP active " + transform.position);
        }
    }
}
