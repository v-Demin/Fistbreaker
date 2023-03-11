using Zenject;

public class EnemyComboView : AbstractComboView
{
    [Inject] private readonly BattleController _battle;
    protected override Combo ComboToCheck => _battle.EnemySideCombo;
}
