namespace Exemplo.Dominio
{
    public class UserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public void AtualizarCPF(string cpf){
            //busco usuarios
            //if(naoachou)
            // atualizar usuario
            //
        }
    }
}