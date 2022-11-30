using System;
using UnityEngine;

public class UI_Container : Debuggable
{
    protected event Action<bool> ContainerToggled;

    protected GameObject container;
    protected GameObject canvas;

    public GameObject Container => container;
    public GameObject Canvas => canvas;

    protected void Awake() => GetObjects();

    public bool ToggleContainer(bool active)
    {
        if (container == null || canvas == null)
            GetObjects();

        container.SetActive(active);
        ContainerToggled?.Invoke(Container.activeInHierarchy);
        return container.activeInHierarchy;
    }

    private void GetObjects()
    {
        canvas = transform.Find("canvas").gameObject;
        container = canvas.transform.Find("container").gameObject;
    }
}
