using UnityEngine;

public class RedZone : MonoBehaviour
{
    public SpriteRenderer thisSprite;
    public bool playerPresent;
    public PlayerController playerController;
    public float damageTimer;
    public float damageTimerMax = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player enters red");
            playerPresent = true;
            playerController = collision.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player leaves red");
            playerPresent = false;
            damageTimer = 0;
            playerController = null;
        }
    }

    private void Update()
    {
        //remove one cell every (damageTimerMax) seconds
        if (playerPresent) damageTimer += Time.deltaTime;
        if (damageTimer > damageTimerMax) 
        {
            CheckOrDamage();
            damageTimer = 0;
        }
    }

    private void CheckOrDamage()
    {
        Color playerColor = GameMan.player.gameObject.GetComponent<SpriteRenderer>().color;
        Color zoneColor = thisSprite.color;

        float rDiff = Mathf.Abs(playerColor.r - zoneColor.r); //compare each r g b value individually
        float gDiff = Mathf.Abs(playerColor.g - zoneColor.g);
        float bDiff = Mathf.Abs(playerColor.b - zoneColor.b);

        if (rDiff > 0.2f || gDiff > 0.2f || bDiff > 0.2f)
        {
            if (playerController.cellsIncorperated.Count >= 1)
            {
                //destroy the last cell in the list and decrement cell count
                GameObject lastCell = playerController.cellsIncorperated[playerController.cellsIncorperated.Count - 1];

                Destroy(lastCell);
                playerController.cellsIncorperated.RemoveAt(playerController.cellsIncorperated.Count - 1);
                playerController.cellCount -= 1;
            }
        }
    }
}
