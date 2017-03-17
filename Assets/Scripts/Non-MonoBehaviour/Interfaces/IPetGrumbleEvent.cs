using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPetGrumbleEvent
{
    void OnPetGrumble(Transform parent, Transform child);
}
