using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 0)]
#region Comments
//CreateAssetMenu = Maak een nieuwe "Create" optie in het CreateAssetMenu
//Filename = Hoe gaat de file heetten als je hem aanmaakt
//MenuName = Hoe heet het menu waar je deze nieuwe asset kan vinden. "ScriptableObjects" = Overkoepelende menu naam. "Bullet" = type ScriptableObject dat je gaat maken
//Order = Op welke plaats in de lijst komt dit onderdeel te staan (dit is een array dusde eerste plaats is 0)
#endregion
public class BulletScriptableObjects : ScriptableObject
    //IPV MonoBehaviour komt de Inheritance van dit script uit "ScriptableObject. Hierover leren jullie volgend jaar meer
{
    //Hier maak je SerializeFields voor ALLE variabelen die alle verschillende bullets hebben
    [SerializeField]
    private string bulletName;

    [SerializeField] 
    private int bulletDamage;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField] 
    private float bulletLiveTime;

    [SerializeField] 
    private Material bulletMaterial;


    //COMMENT GET RETURN
    //Normaal gesproken geven we een waarde aan een variabel door het in te vullen bovenaan het script of in de Editor. De "get" functie zorgt ervoor dat het variabel
    //wordt ingevuld met de waarde van het variabel hierboven. De "return" stopt de statement.

    public string bName { get { return bulletName; } }
    public int bDamage { get { return bulletDamage; } }
    public float bSpeed { get { return bulletSpeed; } }
    public float bLiveTime { get { return bulletLiveTime; } }
    public Material bMaterial { get { return bulletMaterial; } }
}
