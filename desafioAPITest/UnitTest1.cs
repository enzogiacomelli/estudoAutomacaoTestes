using NUnit.Framework;


namespace desafioAPITest
{
    public class Tests
    {
        string baseUrl = "https://serverest.dev/usuarios/";
        Usuarios user;

        [SetUp]
        public void Setup()
        {
            user = new Usuarios();
        }
        
        [Test]
        public void cadastro()
        {
            user.postUsuario();
            Assert.Pass();
        }
        [Test]
        public void listarUsers()
        {
            user.getUsuarios(baseUrl);
            Assert.Pass();
        }
        [Test]
        public void deleteUser()
        {
            user.deleteUsuarios(user.getID());
            Assert.Pass();
        }
        [Test]
        public void editarUser()
        {
            user.putUsuarios(user.getID());
            Assert.Pass();
        }
        [Test]
        public void buscarUsuario()
        {
            user.getUsuarioEspecifico(user.getID());
            Assert.Pass();
        }

        [Test]
        public void teste()
        {
            user.getID();
            Assert.Pass();
        }
    }
}