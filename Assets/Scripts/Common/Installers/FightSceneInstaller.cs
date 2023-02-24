using UnityEngine;
using Zenject;

public class FightSceneInstaller : MonoInstaller
{
    [SerializeField] private InputTaker _inputTaker;
    [SerializeField] private GameCycleController _cycleController;
    
    public override void InstallBindings()
    {
        Container.Bind<InputTaker>()
            .FromInstance(_inputTaker);
        
        Container.Bind<GameCycleController>()
            .FromInstance(_cycleController);
    }
}