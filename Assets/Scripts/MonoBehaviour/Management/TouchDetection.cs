using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDetection : MonoBehaviour
{
    private static Ray ray;
    private static RaycastHit hit;
    private static Vector3 currentPos;

    private PlayerManager pm;

    public PlayerManager Pm
    {
        get
        {
            return pm;
        }

        set
        {
            pm = value;
        }
    }

    public Vector3 CurrentPos
    {
        get
        {
            return currentPos;
        }

        set
        {
            currentPos = value;
        }
    }

    void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {

    }

    public bool MouseInteractionDetection()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            return true;
        return false;
    }

    public bool TouchInteractionDetection()
    {
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved
                || Input.GetTouch(0).phase == TouchPhase.Stationary)
                return true;
        return false;
    }

    public Vector3 returnMousePos()
    {
        if (MouseInteractionDetection())
            return Input.mousePosition;
        return Vector3.zero;
    }

    public RaycastHit ReturnHit()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
            return hit;
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            currentPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100f))
                return hit;
        }
#endif
        return new RaycastHit();
    }

    public Collider ReturnHit(Vector3 pos)
    {
        //currentPos = Camera.main.ScreenToWorldPoint(pos);
        ray = Camera.main.ScreenPointToRay(pos);

        if (Physics.Raycast(ray, out hit, 100f))
            return hit.collider;

        return null;
    }
}
