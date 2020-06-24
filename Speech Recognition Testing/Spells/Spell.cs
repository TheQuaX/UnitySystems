using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private string casterName;

    [Header("Ressources")]
    public Sprite image;

    [Header("Settings")]
    public string spell;
    public SpellType type;
    public int manaCosts;

    public string spellInfo()
    {
        string s;
        s = string.Format("Casting {0} of Type {1} | Manacosts: {2}", spell, type, manaCosts);
        return s;
    }
}

public enum SpellType
{
    Attack,
    Defence,
    CrowdControl,
    Misc
};
