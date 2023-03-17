using Zenject;

public class PlayerSideAttributesView : AbstractAttributesView
{
    [Inject] private readonly BattleController _battle;
    protected override BattleSide SideToCheck => _battle.PlayerSide;
}
