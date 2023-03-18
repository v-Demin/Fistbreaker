using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Skill/Active/ActiveSkill")]
public class ActiveSkill : AbstractSkill
{
    [SerializeField] private List<ComboInfo> _combos = new();

    public void Action(Character owner, int ownerCombo, Character enemy)
    {
        _combos.LastOrDefault(combo => combo.AvailableAtCombo <= ownerCombo)?.Action(owner, enemy);
    }

    private void OnValidate()
    {
        _combos.ForEach(r => r.Rename(_combos.IndexOf(r)));
    }

    [System.Serializable]
    private class ComboInfo
    {
        [SerializeField] [HideInInspector] private string _name;
        [field: SerializeField] public int AvailableAtCombo { get; set; }
        [SerializeField] private List<AbstractActiveSkillAction> _actions;

        public void Action(Character owner, Character enemy)
        {
            _actions.ForEach(action => action.Execute(owner, enemy));
        }

        public void Rename(int comboNumber)
        {
            _name = $"ComboLevel: {comboNumber + 1} - {AvailableAtCombo}";
        }
    }
}
