using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavmesh : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    private Vector3 lastPos;
    private Vector3 currentPos;
    

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void AnimationPlayer()
    {
        currentPos = transform.position;
        if(currentPos.x != lastPos.x)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false); 
        }

        lastPos = currentPos;
    }
}
