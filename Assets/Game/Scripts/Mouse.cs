using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mouse
{
    public static Vector3 GetWorldPosition(float mouseY = 0.2f)
    {
        Camera mainCamera = Camera.main;
        Vector3 mouse3DWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mouse3DWorldPosition.x;
        float mouseZ = mouse3DWorldPosition.z;
        Vector3 mouse2DWorldPosition = new Vector3(mouseX, mouseY, mouseZ);

        return mouse2DWorldPosition;
    }
}
