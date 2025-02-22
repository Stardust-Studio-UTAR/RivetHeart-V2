﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour, IPickup
{
    [SerializeField]
    private float maxCastDistance = 1f;
    [SerializeField]
    private LayerMask layerMask;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, maxCastDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * maxCastDistance, Color.cyan);

        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Execute();
                }
            }
        }
    }

    public void PickUpItem(ItemPickupSO pickupSO)
    {
        InventoryManager.instance.AddNewItem(pickupSO);
    }
}
