using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public Highlighter[] Tiles = new Highlighter[0];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        foreach (Highlighter tile in Tiles)
        {
            if (tile.GetComponent<Collider>().Raycast(ray, out hit, 1000))
            {
                tile.Highlight(true);
            }
            else
            {
                tile.Highlight(false);
            }
        }
    }

    Highlighter GetPointedTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        foreach (Highlighter tile in Tiles)
        {
            if (tile.GetComponent<Collider>().Raycast(ray, out hit, 1000))
            {
                return tile;
            }
        }
        return null;
    }
}
