using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private bool isHit;
    [SerializeField]
    private ParticleSystem playerIndicator; //use current player indicator from the GameSettings
    [SerializeField]
    private float maxDistanceDelta;
    private TouchDetection td;

    public PlayerManager(bool isHit, ParticleSystem playerIndicator)
    {
        this.IsHit = isHit;
        this.PlayerIndicator = playerIndicator;
    }

    public bool IsHit
    {
        get
        {
            return isHit;
        }

        set
        {
            isHit = value;
        }
    }

    public ParticleSystem PlayerIndicator
    {
        get
        {
            return playerIndicator;
        }

        set
        {
            playerIndicator = value;
        }
    }

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

    void Start()
    {
        td = FindObjectOfType<TouchDetection>();
    }

    void FixedUpdate()
    {
        UpdatePlayerPosition();
    }

    public void UpdatePlayerPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(td.CurrentPos.x, td.CurrentPos.y, transform.position.z), 
            maxDistanceDelta * Time.deltaTime);
    }

    public static void KillPlayer()
    {
        Debug.Log("Dead");
        LevelManager.LoadGameScene(5);
    }
}
