using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt
{
    public String argument;
    public UiLangNDiff.Difficulty difficulty;
    public int localeId;

    public Prompt()
    {
         
    }
    public Prompt(string argument, UiLangNDiff.Difficulty difficulty, int localeId)
    {
        this.argument = argument;
        this.difficulty = difficulty;
        this.localeId = localeId;
    }
}
