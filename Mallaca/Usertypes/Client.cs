namespace Mallaca.Usertypes
{
    public class Client : User
    {
        public override UserType UserType
        {
            get
            {
                return UserType.Client;
            }
        }
        public decimal Lenght { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get { return Weight / (Lenght * Lenght);} }

        public Client()
        { 
        
        }
    }
}
