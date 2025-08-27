using UnityEngine;

public interface IFreezable
{
    public void ToggleFreeze(Vector2 position);

    public int GetNumFrozenObjects();
}
