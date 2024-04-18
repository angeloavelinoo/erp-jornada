using Flunt.Validations;

namespace Erp_Jornada.Contracts
{
    public class ContractName : Contract<string>
    {
        public ContractName(string firstName = "")
        {
            Requires()
                .IsNotNullOrWhiteSpace(firstName, nameof(firstName), "Nome é requirido")
                    .IsGreaterThan(firstName?.Length ?? 0, 3, nameof(firstName), "Nome deve ter ao menos 3 caracteres");
        }
    }
}
