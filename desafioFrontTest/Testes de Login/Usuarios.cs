namespace desafioFrontTest.Testes_de_Login
{
    public class Usuarios
    {
        public string nomeDeUsuario = "";
        public string senha = "";


        public Usuarios usuarioCorreto()
        {
            Usuarios user = new Usuarios();
            user.nomeDeUsuario = "standard_user";
            user.senha = "secret_sauce";
            return user;
        }

        public Usuarios usuarioIncorreto()
        {
            Usuarios user = new Usuarios();
            user.nomeDeUsuario = "locked_out_user";
            user.senha = "secret_sauce";
            return user;
        }
    }
}
