namespace BricksFx.Demo.CommunicationModule.Implementation
{
    internal class Communicator : ICommunicator
    {
        private readonly ISaySmth _saySmth;

        public Communicator(ISaySmth saySmth)
        {
            _saySmth = saySmth;
        }

        public string Comunicate()
        {
            return _saySmth.Say();
        }
    }
}