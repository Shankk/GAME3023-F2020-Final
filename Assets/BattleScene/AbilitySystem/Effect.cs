using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void Apply(ICharacter caster, ICharacter target, RhetoricTypeChart.Type abilityType);
}
