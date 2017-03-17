using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    [SerializeField]
    private List<IItem> listOfItems;

    public List<IItem> ListOfItems
    {
        get
        {
            return listOfItems;
        }

        set
        {
            listOfItems = value;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void UpdateItemList()
    {

    }
}
