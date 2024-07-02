using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryCheck : MonoBehaviour
{
    public SettingSO settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            if (other.GetComponent<MeshRenderer>().enabled)
            {
                settings.FailCount += 1;
            }         
        }
    }
}
