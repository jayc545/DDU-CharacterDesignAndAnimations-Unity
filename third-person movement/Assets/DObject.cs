using UnityEngine;

public class DObject : MonoBehaviour
{
    public Animator RagAim;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            print("It worked Dude");
        }

        if (other.tag == "RagDoll")
        {
            RagAim.enabled = false;
        }
    }
}
