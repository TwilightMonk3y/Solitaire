using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardMaterialAutomation : MonoBehaviour
{
    [ContextMenuItem(nameof(CreateMaterials), nameof(CreateMaterials))]
    public Material PrefabBase;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMaterials()
    {
        
        string[] Suits = new string[]
        {
            "Joker", "Spade", "Heart", "Diamond", "Club"
        };
        string[] Cards = new string[]
        {
            "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Jack", "Queen", "King"
        };
        materials = new Material[Suits.Length * Cards.Length];
        for(int suit = 1; suit < Suits.Length; suit++)
        {
            for(int card = 0; card < Cards.Length; card++)
            {
                Debug.Log(Suits[suit] + " " + Cards[card]);
                string name = Suits[suit] + Cards[card];
                
                try
                {
                    Material copy = new Material(PrefabBase);
                    copy.mainTextureOffset = new Vector2(card / 13f, suit / 5f);
                    AssetDatabase.CreateAsset(copy, "Assets/_Solitaire/Materials/Cards/" + name + ".mat");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    int index = suit * Cards.Length + card;
                    Debug.Log(index);
                    materials[index] = copy;
                } 
                catch(Exception ex) 
                {
                    Debug.LogWarning(ex);
                }
            }
        }
    }
}

/*
  width = 3; height = 4;
0 r0 c0
1 r0 c1
2 r0 c2 row * width + column
3 r1 c0
4 r1 c1
5 r1 c2
6 r2 c0
7 r2 c1
8 r2 c2
9 r3 c0
10 r3 c1
11 r3 c2
12 r3 c3
 */
