using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private static float mouse_y = 0.2f;

    public static Vector3 WorldPosition()
    {
        Camera mainCamera = Camera.main;
        Vector3 mouse3DWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float mouse_x = mouse3DWorldPosition.x;
        float mouse_z = mouse3DWorldPosition.z;
        Vector3 mouse2DWorldPosition = new Vector3(mouse_x, mouse_y, mouse_z);

        return mouse2DWorldPosition;
    }
}
