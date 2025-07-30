// Criando o construtor da aplicação.
using Microsoft.EntityFrameworkCore;
using MyInvest.Context;

var builder = WebApplication.CreateBuilder(args);

// -- Configura serviços com o constutor da aplicação (injeção de dependência). -- 

// Faz a API "saber" que possui endpoints.
builder.Services.AddControllers();

// Habilita a descoberta automática de endpoints para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Adiciona o gerador de documentação Swagger/OpenAPI.
builder.Services.AddSwaggerGen();

// Obtendo a string de conexão do Banco de Dados.
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

// Registro da classe de contexto, nesse caso 'ApplicationDbContext', no container de injeção de dependência.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// -------------------------------------------------------------------------------

// Pega todas as configurações feitas (serviços, middlewares) e cria a aplicação final.
var app = builder.Build();

// Verifica se a aplicação está num ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger.
    app.UseSwagger();

    //Adiciona a interface gráfica do Swagger para testes.
    app.UseSwaggerUI();
}

// Força a API a redirecionar de HTTP para HTTPS.
app.UseHttpsRedirection();

// Ativa a verificação de permissões (ex.: endpoints que só usuários logados podem acessar).
// OBS: Para funcionar, você precisa configurar autenticação também.
app.UseAuthorization();

// Faz o link entre as rotas HTTP e os controllers criados.
app.MapControllers();

// Inicia o servidor web (Kestrel) e fica esperando requisições.
app.Run();

