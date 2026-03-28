using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    public PlayerController player;

    [field: SerializeField] private bool inInteractRange = false;
    [field: SerializeField]  public AreaInteract interactTarget = null;

    private void Update()
    {
        //make sure area bubble follows player
        gameObject.transform.position = player.gameObject.transform.position;

        //Interaction Logic
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inInteractRange && interactTarget != null)
            {
                interactTarget.TriggerSwitch(player);
            }
        }
    }


    //Detect when something is in range to interact with
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

    //Detect when something has left interaction range
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
