namespace BricksFx.Demo.Module.Implementation
{
    internal class Comunicator : IComunicator
    {
        private readonly ISaySmth _saySmth;

        public Comunicator(ISaySmth saySmth)
        {
            _saySmth = saySmth;
        }

        public string Comunicate()
        {
            return _saySmth.Say();
        }
    }
}