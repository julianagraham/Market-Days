using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilManager : MonoBehaviour
{
    public Tilemap soilTilemap;
    public TileBase soilTile;

    private HashSet<Vector3Int> hoedCells = new HashSet<Vector3Int>();

    public void HoeCell(Vector3Int cellPosition)
    {
        // Don't hoe the same cell twice.
        if (hoedCells.Contains(cellPosition))
        {
            return;
        }

        // Remember that this cell has been hoed.
        hoedCells.Add(cellPosition);

        // Place the soil Rule Tile.
        soilTilemap.SetTile(cellPosition, soilTile);
    }
}