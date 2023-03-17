using Zenject;

public class EnemySideAttributesView : AbstractAttributesView
{
    [Inject] private readonly BattleController _battle;
    protected override BattleSide SideToCheck => _battle.EnemySide;
}
