namespace desafioFrontTest.Testes_de_Compras
{
    public class Compras
    {
        public string nome = "Enzo";
        public string sobrenome = "Giacomelli";
        public string postalCode = "987654321";
        public string valorVenda = "";

        public Compras vendaCompleta()
        {
            Compras compra = new Compras();
            compra.valorVenda = "Total: $140.34";
            return compra;
        }

        public Compras vendaParcial()
        {
            Compras compra = new Compras();
            compra.valorVenda = "Total: $97.17";
            return compra;
        }
    }
}
