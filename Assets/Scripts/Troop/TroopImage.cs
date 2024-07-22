using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TroopImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Spawner spawner;

    private TroopType type;
    private Transform originalParent;
    private Renderer troopRenderer;
    private GameObject childObject;

    void Awake()
    {
        troopRenderer = GetComponentInChildren<Renderer>();
        childObject = transform.GetChild(0).gameObject;
    }

    public void Initialize(TroopType troopType)
    {
        spawner = FindObjectOfType<Spawner>();
        type = troopType;
        UpdateTroopObject();
        DeactivateChild();
    }

    private void UpdateTroopObject()
    {
        // Destroy the current child object if it exists
        if (childObject != null)
        {
            Destroy(childObject);
        }

        // Instantiate the appropriate prefab based on the troop type
        GameObject prefab = GridManager.Instance.troopImagePrefabs[(int)type];
        childObject = Instantiate(prefab, transform);
        childObject.transform.localPosition = Vector3.zero;
        childObject.transform.localRotation = Quaternion.identity;

        // Update the troop renderer reference
        troopRenderer = childObject.GetComponent<Renderer>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen position to world position for UI elements
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)originalParent, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Convert screen position to world position for UI elements
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)originalParent, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        transform.localPosition = localPoint;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        TroopImage otherTroop = null;
        foreach (var result in raycastResults)
        {
            if (result.gameObject != gameObject && result.gameObject.CompareTag("TroopImage"))
            {
                otherTroop = result.gameObject.GetComponent<TroopImage>();
                break;
            }
            else if (result.gameObject != gameObject && result.gameObject.CompareTag("Lane"))
            {
                DeployTroopOnLane(result);
                Debug.Log("Deployed to lane!");
                break;
            }
            else if (result.gameObject != gameObject)
            {
                AudioClip declineMergeSFX = Resources.Load<AudioClip>("Decline2");
                AudioManager.Instance.PlaySFX(declineMergeSFX);
                break;
            }

        }

        if (otherTroop != null && otherTroop.type == type && otherTroop.type != TroopType.TankRobot)
        {
            MergeWith(otherTroop);
        }

        UpdateGridLayout();
    }

    private void DeactivateTroopImage()
    {
        type = 0;
        UpdateTroopObject();
        DeactivateChild();
    }
    private void DeployTroopOnLane(RaycastResult result)
    {
        switch (result.gameObject.name)
        {
            case "Lane 1":
                spawner.SpawnTroop(type, 0);
                break;
            case "Lane 2":
                spawner.SpawnTroop(type, 1);
                break;
            case "Lane 3":
                spawner.SpawnTroop(type, 2);
                break;
            case "Lane 4":
                spawner.SpawnTroop(type, 3);
                break;
            case "Lane 5":
                spawner.SpawnTroop(type, 4);
                break;
            default:
                break;
        }
        DeactivateTroopImage();
    }

    private void MergeWith(TroopImage otherTroop)
    {
        if (otherTroop.GetChildObject().activeSelf && childObject.activeSelf)
        {
            DeactivateTroopImage();
            // Update the other troop's appearance to reflect the new tier
            otherTroop.type += 1;
            otherTroop.UpdateTroopObject();
            AudioClip mergeSFX = Resources.Load<AudioClip>("MergeLvl" + (int)otherTroop.type);
            AudioManager.Instance.PlaySFX(mergeSFX,1f);
        }
    }

    private void UpdateGridLayout()
    {
        // Ensure the grid layout updates after troop is merged or moved
        LayoutRebuilder.ForceRebuildLayoutImmediate(originalParent.GetComponent<RectTransform>());
    }

    public GameObject GetChildObject()
    {
        return childObject;
    }
    public void ActivateChild()
    {
        childObject.SetActive(true);
    }
    public void DeactivateChild()
    {
        childObject.SetActive(false);
    }
}