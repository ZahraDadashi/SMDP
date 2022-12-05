namespace SMDP
{
    public class Userr
    {
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
    }
}
