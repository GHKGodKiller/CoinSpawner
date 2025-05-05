using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public bool isFollowing;
    public float xOffset;
    public float yOffset;

    private PlayerNavmesh CharControl;

    private void Start()
    {
        CharControl = FindObjectOfType<PlayerNavmesh>();

        isFollowing = true;
    }

    private void Update()
    {
        if (isFollowing)
        {
            transform.position = new Vector3(CharControl.transform.position.x + xOffset, CharControl.transform.position.y + yOffset, transform.position.z);
        }
    }
}

