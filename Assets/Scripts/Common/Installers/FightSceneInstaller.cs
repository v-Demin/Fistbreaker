using UnityEngine;
using Zenject;

public class FightSceneInstaller : MonoInstaller
{
    [SerializeField] private InputTaker _inputTaker;
    public override void InstallBindings()
    {
        Container.Bind<InputTaker>()
            .FromInstance(_inputTaker);
    }
}