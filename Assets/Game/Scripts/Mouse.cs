using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    public static float MouseYCoord = 0.2f;

    public static Vector3 WorldPosition()
    {
        Camera mainCamera = Camera.main;
        Vector3 mouse3DWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float mouseXCoord = mouse3DWorldPosition.x;
        float mouseZCoord = mouse3DWorldPosition.z;
        Vector3 mouse2DWorldPosition = new Vector3(mouseXCoord, MouseYCoord, mouseZCoord);

        return mouse2DWorldPosition;
    }
}
