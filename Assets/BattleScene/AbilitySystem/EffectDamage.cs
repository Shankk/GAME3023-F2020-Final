using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Effect", menuName = "Effects/Damage")]
public class EffectDamage : Effect
{
    [SerializeField]
    int power;
    [SerializeField]
    TargetType target;

    public override void Apply(ICharacter caster, ICharacter target, RhetoricTypeChart.Type abilityType)
    {
        target.TakeDamage(power, abilityType);
        
    }
}
