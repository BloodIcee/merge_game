using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : AnimalEntity
{
    [HideInInspector] public int health = 30;
    [HideInInspector] public int maxHealth = 30;

    private void Awake()
    {
        health = animalConfig.GetHealth;
        maxHealth = animalConfig.GetHealth;
    }

    public override void Start()
    {
        base.Start();
    }
}
