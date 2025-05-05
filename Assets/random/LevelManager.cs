using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCP;

    private ControlPlayer CharControl;

    private void Start()
    {
        CharControl = FindObjectOfType<ControlPlayer>();
    }
    public void RespawnPlayer()
    {
        Debug.Log("Player Respawned");

        CharControl.transform.position = currentCP.transform.position;
    }
}
