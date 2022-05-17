using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickScript : MonoBehaviour
{
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotation = Mouse.WorldPosition() - transform.position;
        Vector3 directionToFace = new Vector3(rotation.x, 0, rotation.z);

        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}

