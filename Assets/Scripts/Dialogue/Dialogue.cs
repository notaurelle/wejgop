using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string characterName;
    public Sprite characterSprite;
    [TextArea]
    public string dialogue;
}
