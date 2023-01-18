using UnityEngine;
using Zenject;

public class ExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IExample>() // InjectアトリビュートがついているIExample型のフィールドに
            .To<Example>() // Exampleクラスのインスタンスを注入する
            .AsTransient();
        //これ↑はScopeと呼ばれるもの。対象のインスタンスがDIコンテナにて要求されたときに、
        //新しく生成するのか、同じものを使いまわしてInjectするのかを指定するメソッドらしい
    }
}