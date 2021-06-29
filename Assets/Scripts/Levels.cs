using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level",menuName = "Level")]
public class Levels : ScriptableObject
{
    public GameObject Pig;
    public GameObject Cow;
    public GameObject Chicken;
    public Animals vurulmasıGereken;
    public Sprite targetAnimalIcon;

    public int vurulmasıGerekenSayı;
    public int pigCount;
    public int cowCount;
    public int chickenCount;
}

public enum Animals
{
    Cow,Chicken,Pig
}
