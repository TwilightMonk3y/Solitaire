using NonStandard;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CardMovementManager : MonoBehaviour
{
    public List<GameObject> Cards;
    public GameObject Selected;
    public Camera MyCamera;
    public Plane CardPlane;
    public static bool CardIsInGoodPlace;
    public Vector3 CardOriginalPosition;
    public Material ValidCard;
    public Material InvalidCard;
    private static CardMovementManager _instance;
    public static CardMovementManager Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        MyCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (CardIsInGoodPlace)
        {
            if(Selected != null)
            {
                Selected.GetComponentInChildren<Renderer>().material.color = ValidCard.color;
            }
            
        }
        else
        {
            if (Selected != null)
            {
                Selected.GetComponentInChildren<Renderer>().material.color = InvalidCard.color;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectObject();
        }
        //drag the mouse
        if(Selected != null)
        {
            //we need the position of the mouse because it is moving
            Ray mousePosition3D = MyCamera.ScreenPointToRay(Input.mousePosition);
            //card follows mouse
            //get new position of mouse in 3D, through a ray
            float distanceToCardPlane;
            CardPlane.Raycast(mousePosition3D, out distanceToCardPlane);
            Selected.transform.position = mousePosition3D.GetPoint(distanceToCardPlane);
            //when mouse stops dragging, card stops following
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (!CardIsInGoodPlace)
                {
                    Selected.transform.position = CardOriginalPosition;
                }
                else
                {
                    Selected.transform.position = PlaceableArea.CurrentPlaceableArea.transform.position;
                }
                Selected = null;
                Debug.Log("released card");
            }
        }
    }

    private bool IsCard(GameObject obj)
    {
        for(int i = 0; i < Cards.Count; i++)
        {
            if(obj == Cards[i])
            {
                return true;
            }
        }
        //return System.Array.IndexOf(Cards, obj) >= 0;
        return false;
    }

    private void SelectObject()
    {
        Ray mousePosition3D = Camera.main.ScreenPointToRay(Input.mousePosition);
        int CardLayer = LayerMask.GetMask("Card");
        if (!Physics.Raycast(mousePosition3D, out RaycastHit hitInfo, 100, CardLayer))
        {
            return;
        }
        GameObject obj = hitInfo.collider.gameObject;
        if (IsCard(obj))
        {
            CardOriginalPosition = obj.transform.position;
            Debug.Log("found card");
            //Wires.Make("Mouse Position").Arrow(mousePosition3D, Color.red);
            //Wires.Make("Mouse Position").Arrow(mousePosition3D.origin,
                //mousePosition3D.GetPoint(hitInfo.distance), Color.red);
            Selected = obj;
            CardPlane = new Plane(MyCamera.transform.forward,
                Selected.transform.position);
            //Wires.Make("Card Plane").Circle(CardPlane.ClosestPointOnPlane(Vector3.zero), 
                //CardPlane.normal, Color.red);
        }
    }
}
