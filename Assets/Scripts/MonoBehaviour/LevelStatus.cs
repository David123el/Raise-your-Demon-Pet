using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatus : MonoBehaviour
{
    [SerializeField]
    private bool isAccessable;
    [SerializeField]
    private int levelID;

    public LevelStatus(bool isAccessable, int levelID)
    {
        this.IsAccessable = isAccessable;
    }

    public bool IsAccessable
    {
        get
        {
            return isAccessable;
        }

        set
        {
            isAccessable = value;
        }
    }

    public int LevelID
    {
        get
        {
            return levelID;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    //if level is accessable get level ID
    public void AccessLevel()
    {

    }
}
