using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelEditor : MonoBehaviour
{
    private object[] sprites;

    private TouchDetection td;

    public bool isLevelEditMode;

	void Start ()
    {
        td = FindObjectOfType<TouchDetection>();

        isLevelEditMode = false;
    }
	
	void Update ()
    {
        if (isLevelEditMode)
            DrawTiles();
	}

    private void DrawTiles()
    {
        if (td.ReturnHit(new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), 0)) == null)
        {
            GameObject tempGO = Instantiate(new GameObject("tile")) as GameObject;
            SpriteRenderer tempRenderer = tempGO.AddComponent<SpriteRenderer>();
            tempRenderer.sprite = (Sprite)sprites[0];
        }
    }
}
