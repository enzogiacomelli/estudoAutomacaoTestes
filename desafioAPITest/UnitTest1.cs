using NUnit.Framework;


namespace desafioAPITest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void cadastro()
        {
            Usuarios user = new Usuarios();
            user.postUsuario();
            Assert.Pass();
        }
        [Test]
        public void listarUsers()
        {
            Usuarios user = new Usuarios();
            user.getUsuarios();
            Assert.Pass();
        }
        [Test]
        public void deleteUser()
        {
            Usuarios user = new Usuarios();
            user.deleteUsuarios();
            Assert.Pass();
        }
        [Test]
        public void editarUser()
        {
            Usuarios user = new Usuarios();
            user.putUsuarios();
            Assert.Pass();
        }
        [Test]
        public void buscarUsuario()
        {
            Usuarios user = new Usuarios();
            user.getUsuarioEspecifico();
            Assert.Pass();
        }
    }
}