using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandPickup : Interactible
{
    public FPSShooter player;
    public Vector3 RotateAmount;
    public GameObject wand;

    private void Update()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }

    void pickupWand()
    {
        player.wandEnabled = true;
        wand.SetActive(true);
    }

    public override string GetDescription()
    {
        return "Press <color=blue>[E]</color> to pick up wand.";
    }

    public override void Interact()
    {
        pickupWand();
    }
}
