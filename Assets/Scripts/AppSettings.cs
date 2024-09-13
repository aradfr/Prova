using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AppSettings : ScriptableObject
{

    
    public Question question;
    public String argument;
    public UiLangNDiff.Difficulty difficulty;
    public int localId;


}
