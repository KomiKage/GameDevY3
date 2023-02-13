using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJerma : Interactible
{
    public GameObject jerma;
    public bool isOn;

    private void Start()
    {
        //JermaSpawn();
    }

    void JermaSpawn()
    {
        Debug.Log("Peep the horror!");
    }

    public override string GetDescription()
    {
        return "Press <color=blue>[E]</color> to spawn a Jerma.";
    }

    public override void Interact()
    {
        JermaSpawn();
    }
}
