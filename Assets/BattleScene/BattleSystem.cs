using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

enum BattlePhase
{
    Player,
    Enemy,
    Count
}
public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    BattlePhase phase;

    [SerializeField]
    ICharacter[] combatants;

    [SerializeField]
    float WaitTime = 3;

    public UnityEvent<ICharacter> onCharacterTurnBegin;
    public UnityEvent<string> onCharacterTurn;
    //public TextBoxAnimator textAnimator;
    bool TurnInProgress = false;
    bool BattleCompleted = false;

    // Start is called before the first frame update
    void Start()
    {

        foreach(ICharacter character in combatants)
        {
            character.onAbilityUsed.AddListener(CharacterUsedAbilityHandler);
            character.SetStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceTurn()
    {
        for (int i = 0; i < 2; i++)
        {
            if (combatants[0].hp <= 0)
            {
                BattleCompleted = true;
                onCharacterTurn.Invoke("You Lost! Opponent Won!");
                //SceneManager.LoadScene("GameOver");
            }
            else if(combatants[1].hp <= 0)
            {
                BattleCompleted = true;
                onCharacterTurn.Invoke("Player Won The Battle!");
            }
        }
        if(BattleCompleted)
        {
            // Do Nothing, because the battle is over!
        }
        else if (TurnInProgress && !BattleCompleted)
        {
            Debug.Log("Invalid Action! It is " + combatants[(int)phase].name + "'s turn!");
        }
        else
        {
            phase++;
            if (phase >= BattlePhase.Count)
            {
                phase = 0;
            }

            ICharacter whoseTurnItIs = combatants[(int)phase];
            Debug.Log("It is " + combatants[(int)phase].name + "'s turn!");
            whoseTurnItIs.TakeTurn();
            onCharacterTurnBegin.Invoke(whoseTurnItIs);
        }

    }

    private void OnDestroy()
    {
        foreach (ICharacter character in combatants)
        {
            character.onAbilityUsed.RemoveListener(CharacterUsedAbilityHandler);
        }
    }

    public void CharacterUsedAbilityHandler(ICharacter caster, Ability ability)
    {
        if (!TurnInProgress && !BattleCompleted)
        {
            TurnInProgress = true;

            ICharacter target = null;
            // Targets the User who isnt in Turn
            target = combatants[((int)phase + 1) % (int)BattlePhase.Count];
            ability.ApplyEffects(caster, target);
            StartCoroutine(CurrentTurnLog(1.0f, caster, ability));
        }
        
    }

    IEnumerator SwapTurnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        AdvanceTurn();
    }

    IEnumerator CurrentTurnLog(float time, ICharacter caster, Ability ability)
    {
        yield return new WaitForSeconds(time);

        onCharacterTurn.Invoke(caster.name + " used " + ability.abilityType + "!");
        yield return new WaitForSeconds(time);

        TurnInProgress = false;
        AdvanceTurn();
    }

}
