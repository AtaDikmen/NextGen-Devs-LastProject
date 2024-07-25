using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TroopImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Spawner spawner;

    private TroopType type;
    private Transform originalParent;
    private GameObject childObject;

    void Awake()
    {
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
        if (childObject != null)
        {
            Destroy(childObject);
        }

        GameObject prefab = GridManager.Instance.troopImagePrefabs[(int)type];
        childObject = Instantiate(prefab, transform);
        childObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
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
        foreach (var result in raycastResults)
        {
            if (result.gameObject != gameObject && result.gameObject.CompareTag("TroopImage"))
            {
                TroopImage otherTroop = result.gameObject.GetComponent<TroopImage>();
                if (otherTroop.GetChildObject() != null && otherTroop.type == type && otherTroop.type != TroopType.TankRobot)
                {
                    MergeWith(otherTroop);
                }
                else if (otherTroop.GetChildObject() != null && otherTroop.type != type)
                {
                    AudioClip declineMergeSFX = Resources.Load<AudioClip>("Decline2");
                    AudioManager.Instance.PlaySFX(declineMergeSFX, transform);
                }
                break;
            }
            else if (result.gameObject != gameObject && result.gameObject.CompareTag("Lane"))
            {
                DeployTroopOnLane(result);
                Debug.Log("Deployed to lane!");
                break;
            }

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
        AudioClip deploySFX = Resources.Load<AudioClip>("Metallic2");

        AudioManager.Instance.PlaySFX(deploySFX, transform);

        spawner.SpawnTroop(type, Int32.Parse(result.gameObject.name) - 1);
        
        DeactivateTroopImage();
    }

    private void MergeWith(TroopImage otherTroop)
    {
        if (otherTroop.GetChildObject().activeSelf && childObject.activeSelf)
        {
            DeactivateTroopImage();
            otherTroop.type += 1;
            otherTroop.UpdateTroopObject();
            ParticleSystem particle = otherTroop.GetComponentInChildren<ParticleSystem>();
            particle.Play();
            AudioClip mergeSFX = Resources.Load<AudioClip>("MergeLvl" + (int)otherTroop.type);
            AudioManager.Instance.PlaySFX(mergeSFX, transform, 1f);
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
        ParticleSystem particle = childObject.GetComponentInChildren<ParticleSystem>();
        particle.Play();
    }
    public void DeactivateChild()
    {
        childObject.SetActive(false);
    }
}