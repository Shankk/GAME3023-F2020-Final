using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    [SerializeField]
    ICharacter PlayerCharacter;

    new int hp;

    // Start is called before the first frame update
    void Start()
    {
        DetermineType();
    }

    void DetermineType()
    {
        var TypeRange = Random.Range(0, 100);
        if (TypeRange < 33)
        {
            MyRhetoricType = RhetoricTypeChart.Type.Fun;
        }
        else if ( TypeRange >= 33 && TypeRange < 66)
        {
            MyRhetoricType = RhetoricTypeChart.Type.Emotional;
        }
        else if (TypeRange >= 66)
        {
            MyRhetoricType = RhetoricTypeChart.Type.Logical;
        }
    }

    override public void TakeTurn()
    {
        int OpponentsTypeID = (int)PlayerCharacter.MyRhetoricType;
        int WeightedRange = Random.Range(0, 100);
        int AbilityID = 0, minValue = 33, maxValue = 66;

        //

        // Determining what abilities to use against our Opponent
        if (OpponentsTypeID == 0) // Our Opponenet Equals Fun Type
        {
            minValue = 25; maxValue = 75;
        }
        else if (OpponentsTypeID == 1) // Our Opponenet Equals Logi Type
        {
            minValue = 50; maxValue = 75;
        }
        else if (OpponentsTypeID == 2) // Our Opponenet Equals Emo Type
        {
            minValue = 25; maxValue = 50;
        }

        // Percent Chances of Using Our Abilitys
        if (WeightedRange < minValue) // 1st Ability Fun
        {
            AbilityID = 1;
        }
        else if(WeightedRange >= minValue && WeightedRange < maxValue) // 2nd Ability Emo
        {
            AbilityID = 2;
        }
        else if( WeightedRange >= maxValue) // 3rd Ability Logi
        {
            AbilityID = 3;
        }
        else // 4th Ability
        {
            AbilityID = 0;
        }

        Debug.Log("Weighted Range: " + WeightedRange);
        if(abilities[AbilityID] != null)
        {
           
            UseAbility(AbilityID);

        } else
        {
            
        }
    }
}
