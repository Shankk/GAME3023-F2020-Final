using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ICharacter : MonoBehaviour
{
    [SerializeField]
    public RhetoricTypeChart.Type MyRhetoricType;

    public float hp = 10;

    [SerializeField]
    private float hpMax = 10;

    [SerializeField]
    protected Ability[] abilities = new Ability[4];

    [SerializeField]
    protected  Slider HealthBar;

    [SerializeField]
    protected TMPro.TextMeshProUGUI healthText;
    [SerializeField]
    protected TMPro.TextMeshProUGUI playerInfoText;

    public UnityEvent<ICharacter, int> onDamageTaken;
    public UnityEvent<ICharacter, Ability> onAbilityUsed;

    // Start is called before the first frame update
    void Start()
    {
        playerInfoText.text = gameObject.name + " - " + MyRhetoricType;
        HealthBar.value = hp / 10;
        healthText.text = hp + "/10";
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

    public void SetStats()
    {
        playerInfoText.text = gameObject.name + " - " + MyRhetoricType;
        HealthBar.value = hp / 10;
        healthText.text = hp + "/10";
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
        HealthBar.value = hp / 10;
        healthText.text = hp + "/10";
    }
}
