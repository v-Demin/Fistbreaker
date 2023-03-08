using System;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [field: SerializeField] public BattleSide PlayerSide { get; private set; }
    [field: SerializeField] public BattleSide EnemySide { get; private set; }

    public Action OnSideDefeated;
    
    //[Todo]: загрузка нужных персонажей в нужном количестве
    
    public Character GetEnemyFor(Character character)
    {
        if (PlayerSide.Contains(character))
        {
            return EnemySide.CurrentBattleCharacter;
        }

        if (EnemySide.Contains(character))
        {
            return PlayerSide.CurrentBattleCharacter;
        }

        throw new ArgumentException("Данный персонаж не состоит ни в одной стороне данный битвы");
    }
}