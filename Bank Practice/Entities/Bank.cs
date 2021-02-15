using Bank_Practice.Inside_Bank;

namespace Bank_Practice.Entities
{
    public partial class Bank
    {
        public string Name { get; set; }
        public CEO CEO { get; }

        private Manager[] _managers;
        private Worker[] _workers;
        private Credit[] _creditClients;       

        public Bank()
        {

        }
        public Bank(in string name, in CEO ceo, in Manager[] managers, in Worker[] workers, in Credit[] creditedClients)
        {
            Name = name;            
            CEO = ceo;
            _managers = managers;
            _workers = workers;
            _creditClients = creditedClients;
        }
    }
}