using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Counter : BasePlatform
{

    [SerializeField]private InteractableObjectSO interactableObjectSO;



    public override void Interact(Player2 player2)
    {
        if (!HasInteractableObject())
        {
            if (player2.HasInteractableObject())
            {
                player2.GetInteractableObject().SetInteractableObjectParent(this);
                player2.ClearInteractableObject();  // <-- Make sure to clear it
            }
        }
        else
        {
            if (!player2.HasInteractableObject())
            {
                GetInteractableObject().SetInteractableObjectParent(player2);
            }
        }
    }



}
