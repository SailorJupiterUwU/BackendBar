namespace BackendBar.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //ponerle en clase heredada para que sea especifico para otros roles
        //public string Password { get; set; }
        //hash de sesion para otros usuarios
        //public string SesionHash { get; set; }
        public int RoleId { get; set; }
    }
}

