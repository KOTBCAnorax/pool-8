using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public GUIScript gui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CueBallScript>() != null)
        {
            return;
        }

        Destroy(other.gameObject);
        gui.UpdateScore();
    }
}
