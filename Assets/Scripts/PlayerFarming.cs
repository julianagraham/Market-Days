using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFarming : MonoBehaviour
{
    public Tilemap groundTilemap;
    public SoilManager soilManager;
    public Transform hoeTarget;

    public bool hoeEquipped = false;

    void Update()
    {
        // Press 1 to equip or put away the hoe.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hoeEquipped = !hoeEquipped;
        }

        // Only show the target square when the hoe is equipped.
        hoeTarget.gameObject.SetActive(hoeEquipped);

        // Only allow hoeing when the hoe is equipped.
        if (hoeEquipped)
        {
            UpdateHoeTarget();

            if (Input.GetKeyDown(KeyCode.E))
            {
                HoeGround();
            }
        }
    }

    void UpdateHoeTarget()
    {
        // Find the position of Zoe's feet.
        Vector3 feetPosition = transform.position + new Vector3(0, -0.25f, 0);

        // Find the grid cell Zoe is standing on.
        Vector3Int targetCell = groundTilemap.WorldToCell(feetPosition);

        // Move the target square to that cell.
        hoeTarget.position = groundTilemap.GetCellCenterWorld(targetCell);
    }

    void HoeGround()
    {
        // Find the position of Zoe's feet.
        Vector3 feetPosition = transform.position + new Vector3(0, -0.25f, 0);

        // Find the grid cell Zoe is standing on.
        Vector3Int targetCell = groundTilemap.WorldToCell(feetPosition);

        // Only hoe if there is ground on this cell.
        if (groundTilemap.HasTile(targetCell))
        {
            soilManager.HoeCell(targetCell);
        }
    }
}