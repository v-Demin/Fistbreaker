using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private SkillsGlobalContainer _skillsGlobalContainer;
    [SerializeField] private NameGenerator _nameGenerator;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SkillsGlobalContainer>()
            .FromInstance(_skillsGlobalContainer)
            .AsSingle();
        
        Container.Bind<NameGenerator>()
            .FromInstance(_nameGenerator)
            .AsSingle();
    }
}