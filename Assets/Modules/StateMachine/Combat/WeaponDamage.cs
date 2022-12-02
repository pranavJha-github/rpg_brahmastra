using BlazeAISpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider selfCollider;
    private List<Collider> alreadyCollideWith = new List<Collider>();

    public int damage = 20;
    private float knockback;
    HitStateBehaviour hitState;
    public bool inEnemyHands = false;
    private void OnEnable()
    {
        alreadyCollideWith.Clear();
    }
    private void OnTriggerExit(Collider other)
    {
        alreadyCollideWith.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Targeter>(out Targeter targeter))  { return;  }
        if (other == selfCollider) { return; }
        if (alreadyCollideWith.Contains(other)) { return; }

        // If self is enemy and other is also enemy, do not hit
        other.TryGetComponent<BlazeAI>(out BlazeAI blazeAI);
        if (inEnemyHands && blazeAI) { return; }

        other.TryGetComponent<EnemyStateMachine>(out EnemyStateMachine enemyTarget);
        if (inEnemyHands && enemyTarget) { return; }


        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - selfCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }

        if (other.TryGetComponent<CharacterHealth>(out CharacterHealth health))
        {
            alreadyCollideWith.Add(other);

            if (blazeAI)
            {
                hitState = blazeAI.transform.GetComponent<HitStateBehaviour>();
                blazeAI.Hit();
            }
            health.DealDamage(damage);
        }
    }

    public void SetAttack(int damage, float knockback = 0)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
