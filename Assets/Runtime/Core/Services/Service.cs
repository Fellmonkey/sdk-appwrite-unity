namespace Appwrite
{
    public abstract class Service
    {
        protected readonly Client _client;

        public Service(Client client)
        {
            _client = client;
        }
    }
}
