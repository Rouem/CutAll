using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    public Transform target;


    void Start()
    {
        if (target == null)
        {
            target = GameManager.cutterController.transform;
        }
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameManager.cutterController.transform;
            return;
        }
        transform.position = Vector3.Lerp(
            transform.position,
            target.position - offset,
            Time.deltaTime
        );
    }
}
