using Zenject;

public class PlayerComboView : AbstractComboView
{
    [Inject] private readonly BattleController _battle;
    protected override Combo ComboToCheck => _battle.PlayerSideCombo;
}
