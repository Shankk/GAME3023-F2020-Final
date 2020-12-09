using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    bool IsEnemysTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        AdvanceTurn();

        foreach(ICharacter character in combatants)
        {
            character.onAbilityUsed.AddListener(CharacterUsedAbilityHandler);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceTurn()
    {
        if (IsEnemysTurn)
        {
            //ICharacter whoseTurnItIs = combatants[(int)phase];
            Debug.Log("Invalid Action! It is " + combatants[(int)phase].name + "'s turn!");
            //onCharacterTurnBegin.Invoke(whoseTurnItIs);
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

            if (phase == BattlePhase.Enemy)
            {
                //WaitTime = textAnimator.TextTime;
                //StartCoroutine(OpponentEndTurn(WaitTime));

            }
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

        ICharacter target = null;
        //foreach (ICharacter character in combatants)
        //{
        //    if(character != caster)
        //    {
        //        target = character;
        //        break;
        //    }
        //}
        // Targets the User who isnt in Turn
        target = combatants[((int)phase + 1) % (int)BattlePhase.Count];

        ability.ApplyEffects(caster, target);
        StartCoroutine(SwapTurnDelay(1.0f));
        
    }

    IEnumerator SwapTurnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        AdvanceTurn();
    }

    IEnumerator OpponentEndTurn(float time)
    {
        IsEnemysTurn = true;
        yield return new WaitForSeconds(time);

        onCharacterTurn.Invoke("Opponent Ended Turn!");
        yield return new WaitForSeconds(time);

        IsEnemysTurn = false;
        AdvanceTurn();
    }
}
