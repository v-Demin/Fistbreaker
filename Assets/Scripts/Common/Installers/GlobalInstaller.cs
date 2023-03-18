using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private SkillsGlobalContainer skillsGlobalContainer;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SkillsGlobalContainer>()
            .FromInstance(skillsGlobalContainer)
            .AsSingle();
    }
}