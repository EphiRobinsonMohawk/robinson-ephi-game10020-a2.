using UnityEngine;

public class Pickup : MonoBehaviour, EventInterface
{
    public bool isPickedUp = false;

    public void OnInteract(PlayerController player)
    {
        if (isPickedUp == false)
        {
            
            Debug.Log(player.name + " picked up " + gameObject.name);

            transform.SetParent(player.transform); //Parent object to player

            transform.localPosition = Vector3.zero; //Reset position

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.simulated = false;
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            player.areaChecker.itemHolding = this;
            isPickedUp = true;

        }

        else
        {

            Debug.Log(player.name + " dropped " + gameObject.name);

            transform.SetParent(null); //Parent object to player

            transform.localPosition = new Vector3 (player.rb2d.position.x - 0.8f, player.rb2d.position.y); //Reset position

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true;
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            player.areaChecker.itemHolding = null;
            isPickedUp = false;
        }
        
    }
}
