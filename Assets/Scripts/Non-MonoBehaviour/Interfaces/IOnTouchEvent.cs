using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnTouchEvent
{
    Manual Manual{get;} //updates the manual when the player meets a new item

    void OnTouch();
}
