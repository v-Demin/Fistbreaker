using System.Collections.Generic;
using UnityEngine;

public class ParticleVisualObject : AbstractVoidVisualObject
{
    [SerializeField] private List<ParticleSystem> _particles;

    protected override void ShowInner(bool fast = false)
    {
        _particles.ForEach(particle => particle.Play());
    }

    protected override void HideInner(bool fast = false)
    {
        _particles.ForEach(particle => particle.Stop());
    }
}
