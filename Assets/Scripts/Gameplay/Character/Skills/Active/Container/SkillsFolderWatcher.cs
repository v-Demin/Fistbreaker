using UnityEditor;
using System.IO;
using Zenject;

public class SkillsFolderWatcher : IInitializable
{
    [Inject] private readonly SkillsGlobalContainer _skillsGlobalContainer;

    private readonly string _folderPath = "Assets/Resources/Skills";

    public void Initialize()
    {
        string[] subFolders = Directory.GetDirectories(_folderPath, "*", SearchOption.AllDirectories);
        foreach (string subFolder in subFolders)
        {
            if (subFolder != _folderPath)
            {
                string[] assetGuids = AssetDatabase.FindAssets("t:AbstractSkill", new[] { subFolder });
                foreach (string guid in assetGuids)
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                    AbstractSkill yourObject = AssetDatabase.LoadAssetAtPath<AbstractSkill>(assetPath);
                    if (yourObject != null)
                    {
                        _skillsGlobalContainer.Add(yourObject);
                    }
                }
            }
        }
    }
}
