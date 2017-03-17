using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, float> levelsBestScore;  //int id, float score

    public Dictionary<int, float> LevelsBestScore
    {
        get
        {
            return levelsBestScore;
        }

        set
        {
            levelsBestScore = value;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
