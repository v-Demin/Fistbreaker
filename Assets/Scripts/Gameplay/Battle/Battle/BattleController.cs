using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public BattleSide PlayerSide { get; private set; }
    public Combo PlayerSideCombo { get; private set; }
    public BattleSide EnemySide { get; private set; }
    public Combo EnemySideCombo { get; private set; }
    
    [SerializeField] private List<Character> _playerCharacters;
    [SerializeField] private List<Character> _enemyCharacters;

    public Action OnSideDefeated;
    
    //[Todo]: загрузка нужных персонажей в нужном количестве

    private void Start()
    {
        PlayerSide = new BattleSide(_playerCharacters);
        EnemySide = new BattleSide(_enemyCharacters);
        
        PlayerSideCombo = new Combo();
        EnemySideCombo = new Combo();
    }

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
