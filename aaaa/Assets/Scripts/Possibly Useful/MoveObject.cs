using UnityEngine;

public class MoveObject : MonoBehaviour, EventInterface
{
    public GameObject PairedHole;
    public bool isMirror = false;
    public ParticleSystem portalParticles;

    public void OnInteract(PlayerController player)
    {
        if (player.areaChecker.itemHolding == null) return;

        Pickup pickup = player.areaChecker.itemHolding.GetComponent<Pickup>();
        if (pickup != null)
        {
           //pickup.SendThroughHole(PairedHole, player);
            portalParticles.Play();
            MoveObject Pairedhol = PairedHole.gameObject.GetComponent<MoveObject>();
            Pairedhol.portalParticles.Play();
        }
    }
}
