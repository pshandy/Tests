using System;
using NUnit.Framework;
using NSubstitute;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.Sample
{
    class SampleNSubstituteTests
    {

        [Test]
        public void Returns_ParticularArg_Works()
        {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("valid.nmd").Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("valid.nmd");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);

        }

        [Test]
        public void Returns_ArgAny_Works()
        {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("anyfile.txt");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

    }
}
