using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private CueStickScript CueStick;
    [SerializeField]
    private float strikeForce = 10f;

    private float afterStrikeDelay = 0.5f;
    private float timeOfLastStrike;

    private bool hasBeenStruck = false;

    private void Update()
    {
        HandleInput();

        if (hasStoped())
        {
            ShowCueStick();
            hasBeenStruck = false;
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && !hasBeenStruck)
        {
            Strike();
            HideCueStick();
            hasBeenStruck = true;
        }
    }

    private void Strike()
    {
        Vector3 directionToStrike = Mouse.WorldPosition() - transform.position;
        directionToStrike = directionToStrike.normalized;
        rb.AddForce(directionToStrike * strikeForce, ForceMode.Impulse);
        timeOfLastStrike = Time.time;
    }

    private bool hasStoped()
    {
        bool enoughTimeElapsed = (Time.time - timeOfLastStrike) > afterStrikeDelay;
        return enoughTimeElapsed && hasBeenStruck && rb.velocity.magnitude < 0.05;
    }

    private void HideCueStick()
    {
        CueStick.gameObject.SetActive(false);
    }

    private void ShowCueStick()
    {
        CueStick.gameObject.SetActive(true);
    }
}
