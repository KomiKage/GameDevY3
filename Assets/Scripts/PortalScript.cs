using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : Interactible
{
    public FPSShooter player;

    void enterPortal()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public override string GetDescription()
    {
        return "Press <color=blue>[E]</color> to go to the Walt Disney World Resort in Orlando, FLorida.";
    }

    public override void Interact()
    {
        enterPortal();
    }
}
