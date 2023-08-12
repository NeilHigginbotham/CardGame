using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}