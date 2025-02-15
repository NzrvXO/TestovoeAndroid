using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public FloatingJoystick joystick;

    public override void InstallBindings()
    {
        Container.BindInstance(joystick).AsSingle();
        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
    }
}
