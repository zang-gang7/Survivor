using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    private const int TileScale = 3; // 가로,세로에 있는 타일 갯수
    private const int TileSize = 20; // 타일 사이즈
    public List<GameObject> tileMapListHorizontalLeft = new List<GameObject>();
    public List<GameObject> tileMapListHorizontalCenter = new List<GameObject>();
    public List<GameObject> tileMapListHorizontalRight = new List<GameObject>();

    public List<GameObject> tileMapListVerticalUp = new List<GameObject>();
    public List<GameObject> tileMapListVerticalCenter = new List<GameObject>();
    public List<GameObject> tileMapListVerticalDown = new List<GameObject>();
    public GameObject centerTile;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitEvent(GameObject tile_)
    {
        if(tileMapListHorizontalLeft.Contains(tile_))
        {
            var dummy = new List<GameObject>(tileMapListHorizontalLeft);
            tileMapListHorizontalLeft.Clear();
            foreach (var obj in tileMapListHorizontalRight)
            {
                obj.transform.position -= new Vector3(TileSize * (TileScale), 0, 0);
                tileMapListHorizontalLeft.Add(obj);
            }

            tileMapListHorizontalRight.Clear();
            foreach (var obj in tileMapListHorizontalCenter)
                tileMapListHorizontalRight.Add(obj);

            tileMapListHorizontalCenter.Clear();
            foreach (var obj in dummy)
                tileMapListHorizontalCenter.Add(obj);

        }
        else if (tileMapListHorizontalRight.Contains(tile_))
        {
            var dummy = new List<GameObject>(tileMapListHorizontalRight);
            tileMapListHorizontalRight.Clear();
            foreach (var obj in tileMapListHorizontalLeft)
            {
                obj.transform.position += new Vector3(TileSize * (TileScale), 0, 0);
                tileMapListHorizontalRight.Add(obj);
            }

            tileMapListHorizontalLeft.Clear();
            foreach (var obj in tileMapListHorizontalCenter)
                tileMapListHorizontalLeft.Add(obj);

            tileMapListHorizontalCenter.Clear();
            foreach (var obj in dummy)
                tileMapListHorizontalCenter.Add(obj);
        }
        else if (tileMapListVerticalDown.Contains(tile_))
        {
            var dummy = new List<GameObject>(tileMapListVerticalDown);
            tileMapListVerticalDown.Clear();
            foreach (var obj in tileMapListVerticalUp)
            {
                obj.transform.position -= new Vector3(0, TileSize * (TileScale), 0);
                tileMapListVerticalDown.Add(obj);
            }

            tileMapListVerticalUp.Clear();
            foreach (var obj in tileMapListHorizontalCenter)
                tileMapListVerticalUp.Add(obj);

            tileMapListVerticalCenter.Clear();
            foreach (var obj in dummy)
                tileMapListVerticalCenter.Add(obj);
        }
        else if (tileMapListVerticalUp.Contains(tile_))
        {
            var dummy = new List<GameObject>(tileMapListVerticalUp);
            tileMapListVerticalUp.Clear();
            foreach (var obj in tileMapListVerticalDown)
            {
                obj.transform.position += new Vector3(0, TileSize * (TileScale), 0);
                tileMapListVerticalUp.Add(obj);
            }

            tileMapListVerticalDown.Clear();
            foreach (var obj in tileMapListHorizontalCenter)
                tileMapListVerticalDown.Add(obj);

            tileMapListVerticalCenter.Clear();
            foreach (var obj in dummy)
                tileMapListVerticalCenter.Add(obj);
        }

    }
}
