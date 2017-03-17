using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagManager : MonoBehaviour
{
    private TouchDetection td;

    public TouchDetection Td
    {
        get
        {
            return td;
        }

        set
        {
            td = value;
        }
    }
    
    void Start ()
    {
        td = FindObjectOfType<TouchDetection>();
	}
	
	void Update ()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        if (td.MouseInteractionDetection())
            HandleInteractions();
        else if (Input.GetMouseButtonUp(0))
        {
            if (FindObjectOfType<LevelManager>() != null)
                FindObjectOfType<LevelManager>().HasPlayerStarted = false;
            if (FindObjectOfType<PlayerManager>() != null)
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                {
                    if (SceneManager.GetActiveScene().name == "CurrentLevel")
                        PlayerManager.KillPlayer();
                }
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (td.TouchInteractionDetection())
                HandleInteractions();
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (FindObjectOfType<LevelManager>() != null)
                    FindObjectOfType<LevelManager>().HasPlayerStarted = false;
                if (FindObjectOfType<PlayerManager>() != null)
                    if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                    {
                        if (SceneManager.GetActiveScene().name == "CurrentLevel")
                            PlayerManager.KillPlayer();
                    }
            }
        }
#endif
    }

    public string ReturnTag()
    {
        if (td != null)
        {
            RaycastHit hit = td.ReturnHit();
            if (hit.collider != null)
                return hit.collider.gameObject.tag;
        }
        return null;
    }

    public void HandleInteractions()
    {
        switch (ReturnTag())
        {
            case "Obstacle":
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                    PlayerManager.KillPlayer();
                break;
            case "Pet":
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                    PlayerManager.KillPlayer();
                break;
            case "Wall":
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                    Debug.Log("Wall");
                break;
            case "Goal":
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().isVisible)
                    SceneManager.LoadScene("WinningScreen");
                break;
            case "Portal":
                SceneManager.LoadScene("LevelSelection");
                break;
            case "Start":
                Time.timeScale = 1;
                if (FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>() != null)
                {
                    FindObjectOfType<PlayerManager>().GetComponent<SpriteRenderer>().enabled = true;
                    FindObjectOfType<PlayerManager>().transform.position = new Vector3(td.CurrentPos.x, td.CurrentPos.y, 1f);
                }
                if (FindObjectOfType<LevelManager>() != null)
                    FindObjectOfType<LevelManager>().HasPlayerStarted = true;
                break;
            case "Player":
                FindObjectOfType<LevelManager>().HasPlayerStarted = true;
                break;
            default:
                break;
        }
    }
}
