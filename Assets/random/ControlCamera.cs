using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public bool isFollowing;
    public float xOffset;
    public float yOffset;

    private ControlPlayer CharControl;

    private void Start()
    {
        CharControl = FindObjectOfType<ControlPlayer>();

        isFollowing = true;
    }

    private void Update()
    {
        if (isFollowing)
        {
            transform.position = new Vector3(CharControl.transform.position.x + xOffset,CharControl.transform.position.y + yOffset,transform.position.z);
        }
    }
}
