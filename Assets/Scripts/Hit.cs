using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Hit : MonoBehaviour
{

    [SerializeField] GameObject hitMarkPrefab;

    [SerializeField] AudioClip leftClickSound;

    Vector3 targetPos = Vector3.zero;

    bool isRightDown = false;

    public static event Action<bool> OnFireBeam;


    public void MouseMove(InputAction.CallbackContext context)
    {
        Vector3 mousePos = context.ReadValue<Vector2>(); // Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit mouseHit;

        if (Physics.Raycast(ray, out mouseHit))
        {
            targetPos = mouseHit.point;
        }
    }


    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && targetPos != Vector3.zero)
        {
            Instantiate(hitMarkPrefab, targetPos, Quaternion.identity);
            AudioFX.instance.Play(leftClickSound);
        }
    }


    public void MouseRightClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnFireBeam?.Invoke(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            OnFireBeam?.Invoke(false);
        }
    }


}
