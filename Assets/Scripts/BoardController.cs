using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;

public class BoardController : MonoBehaviour
{
    public GameObject PawnPrefab;
    public GameObject DronePrefab;
    public GameObject QueenPrefab;

    public GameObject[] Tiles = new GameObject[8 * 4];

    Board _board;
    void Start()
    {
        _board = new Board();
        for (int row = 0; row < _board.Lines; row++)
        {
            for (int col = 0; col < _board.Columns; col++)
            {
                Tile tile = _board.Tiles[row, col];
                if (tile.HasPiece())
                {
                    SetUpPiece(tile.GetPiece().GetPieceType(), (row, col));
                }
            }
        }

    }

    void SetUpPiece(Piece.Type pieceType, (int x, int y) tilePosition)
    {
        GameObject prefab;
        switch (pieceType)
        {
            case (Piece.Type.Pawn):
                prefab = PawnPrefab;
                break;
            case (Piece.Type.Drone):
                prefab = DronePrefab;
                break;
            case (Piece.Type.Queen):
                prefab = QueenPrefab;
                break;
            default:
                throw new System.Exception("Invalid piece type");
        }
        GameObject piece = GameObject.Instantiate(prefab);
        PlacePieceOnTile(piece, GetTile(tilePosition));
    }

    void PlacePieceOnTile(GameObject piece, GameObject tile)
    {
        piece.transform.SetParent(tile.transform, true);
        piece.transform.localPosition = new Vector3(0, 0, 0);
    }

    GameObject GetTile((int x, int y) tilePosition)
    {
        return Tiles[(tilePosition.x * 4) + tilePosition.y];
    }
}
