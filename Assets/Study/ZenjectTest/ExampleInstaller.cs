using UnityEngine;
using Zenject;

public class ExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IExample>() // Inject�A�g���r���[�g�����Ă���IExample�^�̃t�B�[���h��
            .To<Example>() // Example�N���X�̃C���X�^���X�𒍓�����
            .AsTransient();
        //���ꁪ��Scope�ƌĂ΂����́B�Ώۂ̃C���X�^���X��DI�R���e�i�ɂėv�����ꂽ�Ƃ��ɁA
        //�V������������̂��A�������̂��g���܂킵��Inject����̂����w�肷�郁�\�b�h�炵��
    }
}