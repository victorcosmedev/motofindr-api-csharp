namespace MotoFindrAPI.Utils
{
    public static class ApiDoc
    {
        // MotoController
        public const string MotoSummary = "Operações relacionadas a motos";
        public const string MotoDescription = "Endpoint para gerenciamento completo do ciclo de vida das motos";

        public const string SalvarMotoSummary = "Cadastra uma nova moto";
        public const string SalvarMotoDescription = "Recebe os dados da moto e persiste no sistema";

        public const string BuscarMotoSummary = "Busca moto por ID";
        public const string BuscarMotoDescription = "Retorna os detalhes completos de uma moto específica";

        public const string AtualizarMotoSummary = "Atualiza dados de uma moto";
        public const string AtualizarMotoDescription = "Atualiza todas as informações de uma moto existente";

        public const string DeletarMotoSummary = "Remove uma moto do sistema";
        public const string DeletarMotoDescription = "Exclui permanentemente o registro de uma moto";

        // PatioController
        public const string PatioSummary = "Operações relacionadas a pátios";
        public const string PatioDescription = "Endpoint para gerenciamento de pátios de estacionamento";

        public const string SalvarPatioSummary = "Cadastra um novo pátio";
        public const string SalvarPatioDescription = "Cria um novo registro de pátio com os dados fornecidos";

        public const string BuscarTodosPatiosSummary = "Lista todos os pátios";
        public const string BuscarTodosPatiosDescription = "Retorna uma lista completa de todos os pátios cadastrados";

        public const string BuscarPatioPorIdSummary = "Busca pátio por ID";
        public const string BuscarPatioPorIdDescription = "Retorna os detalhes completos de um pátio específico";

        public const string AtualizarPatioSummary = "Atualiza dados de um pátio";
        public const string AtualizarPatioDescription = "Atualiza as informações de um pátio existente";

        public const string DeletarPatioSummary = "Remove um pátio do sistema";
        public const string DeletarPatioDescription = "Exclui permanentemente o registro de um pátio";

        // SecaoController
        public const string SecaoSummary = "Operações relacionadas a seções";
        public const string SecaoDescription = "Endpoint para gerenciamento de seções dentro dos pátios";

        public const string SalvarSecaoSummary = "Cadastra uma nova seção";
        public const string SalvarSecaoDescription = "Cria um novo registro de seção em um pátio";

        public const string ObterSecaoPorIdSummary = "Busca seção por ID";
        public const string ObterSecaoPorIdDescription = "Retorna os detalhes completos de uma seção específica";

        public const string AtualizarSecaoSummary = "Atualiza dados de uma seção";
        public const string AtualizarSecaoDescription = "Atualiza as informações de uma seção existente";

        public const string DeletarSecaoSummary = "Remove uma seção do sistema";
        public const string DeletarSecaoDescription = "Exclui permanentemente o registro de uma seção";

        // VagaController
        public const string VagaSummary = "Operações relacionadas a vagas";
        public const string VagaDescription = "Endpoint para gerenciamento de vagas de estacionamento";

        public const string BuscarVagasPorSecaoSummary = "Lista vagas por seção";
        public const string BuscarVagasPorSecaoDescription = "Retorna todas as vagas pertencentes a uma seção específica";

        public const string BuscarVagasPorPatioSummary = "Lista vagas por pátio";
        public const string BuscarVagasPorPatioDescription = "Retorna todas as vagas pertencentes a um pátio específico";

        public const string BuscarVagaPorIdSummary = "Busca vaga por ID";
        public const string BuscarVagaPorIdDescription = "Retorna os detalhes completos de uma vaga específica";

        public const string SalvarVagaSummary = "Cadastra uma nova vaga";
        public const string SalvarVagaDescription = "Cria um novo registro de vaga em uma seção";

        public const string AtualizarVagaSummary = "Atualiza dados de uma vaga";
        public const string AtualizarVagaDescription = "Atualiza as informações de uma vaga existente";

        public const string DeletarVagaSummary = "Remove uma vaga do sistema";
        public const string DeletarVagaDescription = "Exclui permanentemente o registro de uma vaga";
    }
}
