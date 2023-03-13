using UnityEngine;

public class LogVisualObject : AbstractVoidVisualObject
{
    protected override void ShowInner(bool fast = false)
    {
        $"Объект {name}: ShowInner".Log(Color.green);
    }

    protected override void HideInner(bool fast = false)
    {
        $"Объект {name}: HideInner".Log(Color.red);
    }
}
