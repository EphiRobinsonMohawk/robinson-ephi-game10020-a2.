using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    public PlayerController player;

    [field: SerializeField] private bool inInteractRange = false;
    [field: SerializeField]  public AreaInteract interactTarget { get; private set; } = null;

    public Pickup itemHolding = null;

    private void Update()
    {
        gameObject.transform.position = player.gameObject.transform.position;

        //Interact Logic
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inInteractRange && interactTarget.GetComponent<Pickup>() != null && itemHolding != null)
            {
                AreaInteract interact = itemHolding.GetComponent<AreaInteract>();
                interact.TriggerSwitch(player);
            }
            else if (inInteractRange && interactTarget != null)
            {
                interactTarget.TriggerSwitch(player);
            }
            else if (itemHolding != null)
            {
                AreaInteract interact = itemHolding.GetComponent<AreaInteract>();
                interact.TriggerSwitch(player);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact != null)
            {
                inInteractRange = true;
                interactTarget = interact;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            Debug.Log("Left Interact Range");
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact != null && interact == interactTarget)
            {
                inInteractRange = false;
                interactTarget = null;
            }

        }
    }
}
