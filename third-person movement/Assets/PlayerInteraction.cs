using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Camera cam;

    public Interacteble focus;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
              Interacteble interacteble = hit.collider.GetComponent<Interacteble>();

                if (interacteble != null) 
                {
                    SetFocus(interacteble);
                }
            }
        }
    }
    void SetFocus (Interacteble newFocus) 
    {
        focus = newFocus;
    }

    void RemoveFocus()
    {
        focus = null;
    }
}
