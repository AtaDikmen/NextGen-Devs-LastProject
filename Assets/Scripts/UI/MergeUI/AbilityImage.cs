using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum AbilityType { SmartBomb, Bomb, Heal }
public class AbilityImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform originalParent;
    private Vector3 originalPosition;
    [SerializeField] private AbilityType abilityType;
    void Start()
    {
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
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
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var result in raycastResults)
        {
            if (result.gameObject != gameObject && result.gameObject.CompareTag("Lane"))
            {
                Debug.Log(abilityType + " Deployed to lane!");
                DeployAbilityOnLane(result);
                break;
            }
        }
        transform.localPosition = originalPosition;
    }

    private void DeployAbilityOnLane(RaycastResult result)
    {
        //Handle lane case
        switch (result.gameObject.name)
        {
            case "Lane 1":
                break;
            case "Lane 2":
                break;
            case "Lane 3":
                break;
            case "Lane 4":
                break;
            case "Lane 5":
                break;
            default:
                break;
        }
    }
}
