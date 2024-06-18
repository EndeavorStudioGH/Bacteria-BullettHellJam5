using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = -16; x < _width * 5; x++)
        {
            for (int y = -9; y < _height * 5; y++)
            {

                Tile tile = Instantiate(_tilePrefab, new Vector3(x - 16, y - 9), Quaternion.identity);
                tile.name = $"Tile {x} - {y}";

                var isOffset = (x % 2 == 0 && y%2 != 0) || (x % 2 != 0 && y % 2 == 0);
                tile.Init(isOffset);
                //tile.transform.position = new Vector2(_cam.transform.position.x, _cam.transform.position.y);
            }
        }
    }
}
