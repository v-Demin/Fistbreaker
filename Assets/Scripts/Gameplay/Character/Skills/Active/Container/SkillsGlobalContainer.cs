using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using Zenject;

[CreateAssetMenu]
public class SkillsGlobalContainer : ScriptableObject
{
    [Inject] private readonly DiContainer _container;
    [SerializeField] private List<ActiveSkill> _activeSkills;
    [SerializeField] private List<PassiveSkill> _passiveSkills;

    private readonly string _folderPath = "Assets/Resources/Skills";

    public void Add(AbstractSkill skill)
    {
        if (skill is ActiveSkill activeSkill)
        {
            _activeSkills.Add(activeSkill);
        }
        
        if (skill is PassiveSkill passiveSkill)
        {
            _passiveSkills.Add(passiveSkill);
        }
    }

    [Button(nameof(FindAllSkills))]
    private void FindAllSkills()
    {
        _activeSkills.Clear();
        _passiveSkills.Clear();

        string[] assetGuids = AssetDatabase.FindAssets("t:AbstractSkill", new[] { _folderPath });
        foreach (string guid in assetGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            AbstractSkill yourObject = AssetDatabase.LoadAssetAtPath<AbstractSkill>(assetPath);
            if (yourObject != null)
            {
                Add(yourObject);
            }
        }
    }
}
