using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public float speed;
    public Transform target;

	void Start ()
    {
        
    }
	
	void FixedUpdate ()
    {
        if (FindObjectOfType<LevelManager>().HasPlayerStarted)
            MoveCamera();
	}

    private void MoveCamera()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
