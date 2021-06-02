
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace CursoMVC.Models.Users
{
    public class UserModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Key]
        public string Cedula { get; set; }

        public string Email { get; set; }

        public string Perfil { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class UserDBContext : DbContext
    {
        public UserDBContext() { }

        public DbSet<UserModel> Users { get; set; }

    }
}