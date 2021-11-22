using UnityEngine;

public class Interacteble : MonoBehaviour
{
    public float radius = 3f; //Distance for the player to interact with the object.

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
