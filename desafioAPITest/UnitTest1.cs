using NUnit.Framework;


namespace desafioAPITest
{
    public class Tests
    {

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
            user.getUsuarios();
            Assert.Pass();
        }
        [Test]
        public void deleteUser()
        {
            user.deleteUsuarios();
            Assert.Pass();
        }
        [Test]
        public void editarUser()
        {
            user.putUsuarios();
            Assert.Pass();
        }
        [Test]
        public void buscarUsuario()
        {
            user.getUsuarioEspecifico();
            Assert.Pass();
        }
    }
}