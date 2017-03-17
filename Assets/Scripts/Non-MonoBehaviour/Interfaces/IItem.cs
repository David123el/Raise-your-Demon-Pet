using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    int ID { get; }
    ItemType ItemType { get; set; }
    Sprite Sprite { get; }
    bool IsUnlocked { get; set; }
    Text Name { get; }
    Text Description { get; }
}
