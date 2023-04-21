using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hit : MonoBehaviour
{

    [SerializeField] GameObject hitMarkPrefab;

    Vector3 targetPos = Vector3.zero;


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
        }
    }
}
