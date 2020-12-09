using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Ability", menuName = "Ability/Basic Ability")]
public class Ability : ScriptableObject
{
    [SerializeField]
    public RhetoricTypeChart.Type abilityType;

    [SerializeField]
    List<Effect> effects;

    public void ApplyEffects(ICharacter caster, ICharacter target)
    {
        foreach(Effect effect in effects)
        {
            effect.Apply(caster, target, abilityType);
            
        }
        Debug.Log( abilityType + " was used!" + " Your Health: " + caster.hp + " Opponent Health: " + target.hp);
    }
}
