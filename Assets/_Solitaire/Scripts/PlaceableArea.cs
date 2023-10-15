using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableArea : MonoBehaviour
{
    public static GameObject CurrentPlaceableArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject + " Entered" + name);
        //check if the object is card
        //if it is, check if the card is in the valid place when the mouse is let go
        //if it is, leave card where it is
        //if it is not, put card back to original position
        CardMovementManager.CardIsInGoodPlace = true;
        CurrentPlaceableArea = this.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject + " Exited" + name);
        if(CurrentPlaceableArea != this.gameObject) 
        {
            return;
        }
        else
        {
            CardMovementManager.CardIsInGoodPlace = false;
        }
    }
}
