using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using UnityEngine.UI;

public class SpellRecognition : MonoBehaviour
{
    //Variables
    private KeywordRecognizer kr;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public Spell[] spells;
    private Sprite[] spellImages;
    public Image latestSpellImage;


    public void Start()
    {
        //Adding spells
        spellImages = new Sprite[spells.Length];
        kr = new KeywordRecognizer(GetSpellNames());
        kr.OnPhraseRecognized += recognizedSpell;

    }


    string[] GetSpellNames()
    {
        string[] sn = new string[spells.Length];
        int amount = spells.Length;
        for (int i = 0; i < amount; i++)
        {
            sn[i] = spells[i].spell;
        }
        return sn;
    }

    private void Update()
    {

        //Rise wand
        if (Input.GetKeyDown(KeyCode.Q))
        {
            kr.Start();
        }
        else if (Input.GetKeyUp(KeyCode.Q) && kr.IsRunning)
        {
            kr.Stop();
        }
    }

    private void recognizedSpell(PhraseRecognizedEventArgs args)
    {
        if(args.text != String.Empty)
        {
            Spell s = Array.Find(spells, item => item.spell == args.text);
            latestSpellImage.sprite = s.image;
            Debug.Log(s.spellInfo());
        }
    }
}
