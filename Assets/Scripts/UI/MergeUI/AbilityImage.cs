using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum AbilityType { SmartBomb, Bomb, Heal }
public class AbilityImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private AbilityController abilityController;

    private Transform originalParent;
    private Vector3 originalPosition;
    [SerializeField] private AbilityType abilityType;

    private int bombAbilityPrice = 10;
    private int smartBombAbilityPrice = 20;
    private int healAbilityPrice = 15;
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
        if(abilityType == AbilityType.SmartBomb || abilityType == AbilityType.Bomb)
            CheckForBombAbility(result);

        if (abilityType == AbilityType.Heal)
        {
            if (PlayerManager.Instance.CurrentPlayerGold < healAbilityPrice)
                return;
            abilityController.UseHealAbilityOnLane(Int32.Parse(result.gameObject.name) - 1);
        }

    }

    private void CheckForBombAbility(RaycastResult result)
    {
        bool isSmart = false;

        if (abilityType == AbilityType.SmartBomb)
            isSmart = true;

        if (isSmart)
        {
            if (PlayerManager.Instance.CurrentPlayerGold < smartBombAbilityPrice)
                return;

            PlayerManager.Instance.CurrentPlayerGold -= smartBombAbilityPrice;
        }
        else
        {
            if (PlayerManager.Instance.CurrentPlayerGold < bombAbilityPrice)
                return;

            PlayerManager.Instance.CurrentPlayerGold -= bombAbilityPrice;
        }

        abilityController.UseBombAbilityOnLane(Int32.Parse(result.gameObject.name) - 1, isSmart);
        return;
    }
}
