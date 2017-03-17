using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
[RequireComponent(typeof(BoxCollider2D))]
public class PetManager : MonoBehaviour, IOnTouchEvent
{
    [SerializeField]
    private List<Transform> listOfPoints;
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float distanceToPlayer;
    [SerializeField]
    private float killingDistance;

    [SerializeField]
    private bool isAttacking;
    [SerializeField]
    private bool isGrumble;

    private PlayerManager playerManager;

    public List<Transform> ListOfPoints
    {
        get
        {
            return listOfPoints;
        }

        set
        {
            listOfPoints = value;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public float DistanceToPlayer
    {
        get
        {
            return distanceToPlayer;
        }
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
    }

    public bool IsGrumble
    {
        get
        {
            return isGrumble;
        }

        set
        {
            isGrumble = value;
        }
    }

    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }


    /*public float smoothValue;
    Ray ray;
    RaycastHit hit;
    public Vector3 tempPos;
    public Vector3 tempWorldPos;*/
    
    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void FixedUpdate()
    {
        PathFinder();
        AttackPlayer();
        OnTouch();
    }

    /*void TouchControl()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        switch (Input.GetTouch(0).phase)
        {
            case TouchPhase.Began:
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var temp = hit.collider.gameObject.GetComponent<PetManager>();
                    if (temp != null)
                    {
                        Handheld.Vibrate();
                    }
                }
                break;
                //case TouchPhase.Moved:
                //    tempPos = Input.GetTouch(0).position;
                //    tempWorldPos = Camera.main.ScreenToWorldPoint(tempPos);
                //    if (isAwake)
                //        transform.position = Vector3.Lerp(transform.position,
                //            new Vector3(tempWorldPos.x, tempWorldPos.y, transform.position.z), Time.deltaTime * smoothValue);
                //    break;
        }

        //if (Equals(new Vector3(Mathf.Round(tempWorldPos.x), Mathf.Round(tempWorldPos.y), transform.position.z),
        //    new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z)))
        //{
        //    print("hit the player");
        //}
    }*/

    void PathFinder()
    {
        if (!isAttacking)
        {  
            if (listOfPoints.Count > 0)
            {
                var closestPoint = listOfPoints[0];

                foreach (var item in listOfPoints)
                {
                    if (Vector3.Distance(transform.position, item.position)
                        < Vector3.Distance(transform.position, closestPoint.position)
                        && closestPoint.position.x > transform.position.x)
                    {
                        closestPoint = item;
                    }
                }

                if (closestPoint != transform)
                    transform.position = Vector3.MoveTowards(transform.position, closestPoint.position, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, closestPoint.position) <= 0f)
                {
                    listOfPoints.Remove(closestPoint);
                }
            }           
        }
    }

    void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, playerManager.transform.position) <= distanceToPlayer 
            || transform.position.x > playerManager.transform.position.x)
        {
            isAttacking = true;
            Debug.Log("Attacking");
            transform.position = Vector3.MoveTowards(transform.position, playerManager.transform.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, playerManager.transform.position) > distanceToPlayer)
        {
            isAttacking = false;
        }
    }

    public void OnTouch()
    {
        if (Vector3.Distance(transform.position, playerManager.transform.position) <= killingDistance)
        {
            PlayerManager.KillPlayer();
        }
    }
}
