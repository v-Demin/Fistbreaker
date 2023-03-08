using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRoundPhase
{
    public Action OnEndPhase;
    
    public abstract void StartPhase();

    public virtual void EndPhase()
    {
        $"Фаза {GetType()} завершилась".Log(Color.cyan);

        OnEndPhase?.Invoke();
    }
}
