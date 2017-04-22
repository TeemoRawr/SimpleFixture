﻿namespace SimpleFixture.Tests.Classes
{
    public class ImportSomeInterface
    {
        private readonly ISomeInterface _someInterface;

        public ImportSomeInterface(ISomeInterface someInterface)
        {
            _someInterface = someInterface;
        }

        public int SomeValue => _someInterface.SomeIntMethod();
    }
}
