using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public Sprite cardBorder;

    public int manaCost;
    public int attack;
    public int health;

    public void Print()
    {
        Debug.Log(name + ": " + description + "This card costs: " + manaCost);
    }
}
