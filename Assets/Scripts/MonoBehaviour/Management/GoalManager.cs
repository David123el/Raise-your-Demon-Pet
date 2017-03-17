using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GoalManager : MonoBehaviour, IOnTouchEvent
{
    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    //need to find a way to implement OnTriggerEnter in here
    public void OnTouch()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var temp = collision.gameObject.GetComponent<PlayerManager>();
        if (temp != null)
        {
            //Load next level (gotta change the index to +1 in the future)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
