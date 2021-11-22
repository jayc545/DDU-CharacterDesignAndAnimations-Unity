using UnityEngine;
using UnityEngine.UI;

public class CollisionCode : MonoBehaviour
{
    public bool PlayerColli = false;

    public MeshRenderer text;


    public MeshRenderer eBotten;

    public TextMesh EBut;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Thing")
        {
            eBotten.enabled = true;
        }

        if (other.gameObject.tag == "Thing" && Input.GetKey(KeyCode.E))
        {
            PlayerColli = true;
            print("I Love Lexi");
            text.enabled = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Thing")
        {
            PlayerColli = false;
            eBotten.enabled = false;
        }
    }

    private void Update()
    {

    }
}
