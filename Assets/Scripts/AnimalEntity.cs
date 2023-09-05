using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEntity : MonoBehaviour
{
    public Animal animalConfig;

    public Animator animator;

    public virtual void Start()
    {
        animator.SetBool("Move", true);
    }

    public void ActivateDust()
    {

    }
}
