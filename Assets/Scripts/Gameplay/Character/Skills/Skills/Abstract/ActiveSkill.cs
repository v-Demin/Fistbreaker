using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/ActiveSkill")]
public class ActiveSkill : AbstractSkill
{
    [SerializeField] private List<RoundInfo> _rounds;

    public void Action(Character owner, Character enemy)
    {
        //[Todo]: выбор подходящего раунда
        _rounds.First().Action(owner, enemy);
    }

    private void OnValidate()
    {
        _rounds.ForEach(r => r.Rename(_rounds.IndexOf(r)));
    }

    [System.Serializable]
    private class RoundInfo
    {
        [SerializeField] [HideInInspector] private string _name;
        [SerializeField] private List<AbstractActiveSkillAction> _actions;

        public void Action(Character owner, Character enemy)
        {
            _actions.ForEach(action => action.Execute(owner, enemy));
        }

        public void Rename(int roundNumber)
        {
            _name = $"Round {roundNumber + 1}";
        }
    }
}
