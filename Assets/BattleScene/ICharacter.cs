using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ICharacter : MonoBehaviour
{
    [SerializeField]
    public RhetoricTypeChart.Type MyRhetoricType;

    public int hp = 10;

    [SerializeField]
    private int hpMax = 10;

    [SerializeField]
    protected Ability[] abilities = new Ability[4];

    public UnityEvent<ICharacter, int> onDamageTaken;
    public UnityEvent<ICharacter, Ability> onAbilityUsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        onAbilityUsed.RemoveAllListeners();
        onDamageTaken.RemoveAllListeners();
    }

    public void UseAbility(int id)
    {
        onAbilityUsed.Invoke(this, abilities[id]);
    }

    public virtual void TakeTurn()
    {

    }

    public void TakeDamage(int baseDamage, RhetoricTypeChart.Type type)
    {
        float advantageMultiplier = RhetoricTypeChart.GetMultiplier(MyRhetoricType, type);

        int damageTaken = (int)(baseDamage * advantageMultiplier);
        hp -= damageTaken;
        onDamageTaken.Invoke(this, damageTaken);
    }
}
