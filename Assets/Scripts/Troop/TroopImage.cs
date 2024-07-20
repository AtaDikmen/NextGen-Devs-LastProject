using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TroopImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private TroopType type;
    private int tier;
    private Transform originalParent;
    private Image troopImage;

    void Awake()
    {
        troopImage = GetComponent<Image>();
    }
    public void Initialize(TroopType troopType)
    {
        type = troopType;
        tier = 1;
        UpdateTroopSprite();
    }
    private void UpdateTroopSprite()
    { //Using color for prototype
        switch (type)
        {
            case TroopType.LaserSword:
                troopImage.color = Color.white;
                break;
            case TroopType.LaserPistol:
                troopImage.color = Color.cyan;
                break;
            case TroopType.LaserRifle:
                troopImage.color = Color.red;
                break;
            case TroopType.GranadeLauncher:
                troopImage.color = Color.yellow;
                break;
            case TroopType.TankRobot:
                troopImage.color = Color.black;
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(type + " " + tier);
        originalParent = transform.parent;
        troopImage.raycastTarget = false; // Disable raycast target
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        troopImage.raycastTarget = true; // Re-enable raycast target

        // Perform raycast to detect the object under the pointer
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = eventData.position
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        GameObject hitObject = null;
        foreach (var result in raycastResults)
        {
            if (result.gameObject != gameObject)
            {
                hitObject = result.gameObject;
                break;
            }
        }

        if (hitObject != null && hitObject.CompareTag("TroopImage"))
        {
            TroopImage otherTroop = hitObject.GetComponent<TroopImage>();
            if (otherTroop != null && otherTroop.type == type && otherTroop.tier == tier)
            {
                MergeWith(otherTroop);
            }
        }
        else if (hitObject != null && hitObject.CompareTag("Lane"))
        {
            Debug.Log("Deployed to lane!");
        }

        UpdateGridLayout();
    }

    private void MergeWith(TroopImage otherTroop)
    {
        Debug.Log(otherTroop.type + " " + otherTroop.tier);
        Destroy(gameObject);
        otherTroop.tier++;
        // Update the troop's appearance to reflect the new tier
    }
    private void UpdateGridLayout()
    {
        // Ensure the grid layout updates after troop is merged or moved
        LayoutRebuilder.ForceRebuildLayoutImmediate(originalParent.GetComponent<RectTransform>());
    }
}
