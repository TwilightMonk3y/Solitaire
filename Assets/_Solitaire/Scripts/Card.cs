using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //face up or face down state
    //position in tableau, foundation pile, draw pile, discard pile
    public enum FaceState
    {
        None, FaceDown, FaceUp
    }
    public enum BoardPosition
    {
        None, Tableau, Foundation, Draw, Discard
    }
    public enum Rank
    {
        None, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Count
    }
    public enum Suit
    {
        None, Spade, Heart, Diamond, Club, Count
    }
    private bool _moveable;
    public FaceState faceState = FaceState.None;
    public BoardPosition boardPosition = BoardPosition.None;
    public Rank rank = Rank.None;
    public Suit suit = Suit.None;
    
    public bool Moveable { 
        get { return _moveable; } 
        set
        {
            _moveable= value;
            Debug.Log("new value " + value);
            if(Moveable)
            {
                MakeMoveable();
            }
            else
            {
                MakeImmovable();
            }
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeMoveable()
    {
        CardMovementManager.Instance.Cards.Add(gameObject);
    }
    public void MakeImmovable()
    {
        CardMovementManager.Instance.Cards.Remove(gameObject);
    }
}
