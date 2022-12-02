using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject character;
    private int health;
    private bool isInvunerable;


    public event Action OnTakeDamage;
    public bool IsDead => health <= 0;
    private bool isBlaze = false;
    private BlazeAI blazeAI;
    public event Action OnDie;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        character.TryGetComponent<BlazeAI>(out BlazeAI blazeAI);
        this.blazeAI = blazeAI;
        if (blazeAI) isBlaze = true;
    }

    public void SetInvunerable(bool isInvunerable)
    {
        this.isInvunerable = isInvunerable;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        Debug.Log("Dealing damage " + damage + " to " + character);
        if (isInvunerable) { return; }
        //if (IsDead) return;
        health = Mathf.Max(health - damage, 0);
        OnTakeDamage?.Invoke();
        if (health <= 0)
        {
            Debug.Log(character + " died");
            OnDie?.Invoke();
            Die();
        }
    }

    private void Die()
    {
        if (isBlaze)
        {
            blazeAI.Death();
            blazeAI.disableBlazeOnDeath = true;
            blazeAI.SetState(BlazeAI.State.death);
            Destroy(blazeAI);
            return;
        }
        //else
        //{
        //    Destroy(character);
        //}
    }

    public int getHealth()
    {
        return health;
    }
}
