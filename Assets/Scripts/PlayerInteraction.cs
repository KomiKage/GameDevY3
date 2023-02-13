using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
        
    public TMPro.TextMeshProUGUI interactionText;
    public UnityEngine.UI.Image interactionProgress;
    public GameObject interactionHoldGo;

    public Camera cam;

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactible interactible = hit.collider.GetComponent<Interactible>();

            if(interactible != null)
            {
                HandleInteraction(interactible);
                interactionText.text = interactible.GetDescription();
                successfulHit = true;

                interactionHoldGo.SetActive(interactible.it == Interactible.InteractionType.Hold);
            }
        }

        if (!successfulHit) interactionText.text = "";
    }

    void HandleInteraction (Interactible interactible)
    {
        KeyCode key = KeyCode.E;
        switch (interactible.it)
        {
            case Interactible.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactible.Interact();
                }
                break;
            case Interactible.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactible.IncreaseHoldTime();
                    if (interactible.GetHoldTime() > 1f)
                    {
                        interactible.Interact();
                        interactible.ResetHoldTime();
                    }
                }
                else { interactible.ResetHoldTime();}
                interactionProgress.fillAmount = interactible.GetHoldTime();
                break;
            default:
                throw new System.Exception("Unsupported type of interactible.");
        }
    }
}
