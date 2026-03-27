using UnityEngine;

public class CellFollower : MonoBehaviour, EventInterface
{
    public Transform target;
    public float speed = 5f;
    public bool isIncorperated = false;
    public AreaInteract areaInteract;
    public float distanceToTarget;
    public float minDistance;

    private void Start()
    {
        target = GameMan.player.transform;
    }
    void Update()
    {
        if (isIncorperated)
        {
            distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget > minDistance) 
            {
                transform.position = Vector2.MoveTowards
                (
                transform.position,
                target.position,
                speed * Time.deltaTime
                );
            }
        }
        
    }

    public void OnInteract(PlayerController player)
    {
        if (!isIncorperated)
        {
            isIncorperated = true;
            PlayerController.cellCount += 1;
            player.cellsIncorperated.Add(gameObject);
            areaInteract.enabled = false;
            tag = "Untagged";
            player.areaChecker.interactTarget = null;
            minDistance *= player.cellsIncorperated.Count; //make the cells get a bit further for each existing cell making a chain
        }
    }
}