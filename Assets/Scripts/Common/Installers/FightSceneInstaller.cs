using UnityEngine;
using Zenject;

public class FightSceneInstaller : MonoInstaller
{
    [SerializeField] private InputTaker _inputTaker;
    [SerializeField] private GameCycleController _cycleController;
    [SerializeField] private BattleController _battleController;
    [SerializeField] private SPTimer _timer;
    [SerializeField] private RythmGameplayController _rythmController;
    
    public override void InstallBindings()
    {
        Container.Bind<InputTaker>()
            .FromInstance(_inputTaker);
        
        Container.Bind<GameCycleController>()
            .FromInstance(_cycleController);
        
        Container.Bind<BattleController>()
            .FromInstance(_battleController);
        
        Container.Bind<SPTimer>()
            .FromInstance(_timer);
        
        Container.Bind<RythmGameplayController>()
            .FromInstance(_rythmController);
    }
}