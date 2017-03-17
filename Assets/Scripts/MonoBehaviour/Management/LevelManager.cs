using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Transform initPlayerPos;
    private Vector3 currentPlayerPos;
    [SerializeField]
    private bool isGameStarted;
    private bool hasPlayerStarted;
    private Collider2D trigger;
    private float currentTime;
    [SerializeField]
    private float deltaTime;
    private static float bestTime; //for leaderboard
    private int starCount;
    [SerializeField]
    private bool isTimeAttack;
    private Camera cam;

    public Transform InitPlayerPos
    {
        get
        {
            return initPlayerPos;
        }
    }

    public Vector3 CurrentPlayerPos
    {
        set
        {
            currentPlayerPos = value;
        }
    }

    public bool IsGameStarted
    {
        get
        {
            return isGameStarted;
        }

        set
        {
            isGameStarted = value;
        }
    }

    public Collider2D Trigger
    {
        set
        {
            trigger = value;
        }
    }

    public float CurrentTime
    {
        get
        {
            return currentTime;
        }
    }

    public float DeltaTime
    {
        set
        {
            deltaTime = value;
        }
    }

    public static float BestTime
    {
        get
        {
            return bestTime;
        }

        set
        {
            bestTime = value;
        }
    }

    public int StarCount
    {
        get
        {
            return starCount;
        }

        set
        {
            starCount = value;
        }
    }

    public bool IsTimeAttack
    {
        get
        {
            return isTimeAttack;
        }
    }

    public Camera Cam
    {
        get
        {
            return cam;
        }

        set
        {
            cam = value;
        }
    }

    public bool HasPlayerStarted
    {
        get
        {
            return hasPlayerStarted;
        }

        set
        {
            hasPlayerStarted = value;
        }
    }

    void Awake()
    {
        
    }

    void Start()
    {
        cam = Camera.main;
        cam.orthographicSize = 1;

        hasPlayerStarted = false;
    }

    void Update()
    {
        if (hasPlayerStarted)
            ManageCameraZoom();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void UpdateStars()
    {

    }

    public static void LoadGameScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadCurrentScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void RebuildLevel()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void ManageCameraZoom()
    {
        if (hasPlayerStarted)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5f, .1f);
        if (cam.orthographicSize >= 4.9f)
            cam.orthographicSize = 5;
    }
}
