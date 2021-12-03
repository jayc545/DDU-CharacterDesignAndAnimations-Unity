using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public void OpenDoor()
    {
        if (gameObject.tag == "door")
        {
            delete();
        }
    }

    void delete()
    {
        Destroy(gameObject);
    }
}
