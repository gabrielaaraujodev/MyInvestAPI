// Criando o construtor da aplicação.
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyInvest.Context;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// -- Configura serviços com o constutor da aplicação (injeção de dependência). -- 

/*Minha aplicação vai usar autenticação baseada em Bearer Token JWT,ou seja, 
quando um cliente mandar um token JWT esse token será usado para autenticação.*/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// Aqui começa a configuração de como o token será validado.
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Verifica se o Issuer (quem emitiu o token) é confiável.
            ValidateAudience = true, // Verifica se o Audience (para quem o token foi emitido) é válido.
            ValidateLifetime = true, // Confere se o token ainda está dentro do prazo de validade
            ValidateIssuerSigningKey = true, // Valida a assinatura do token, para ter certeza de que ele não foi alterado por alguém.
            ValidIssuer = "yourdomain.com", // Define os valores esperados para Issuer e Audience (Só aceita tokens que foram emitidos pelo "yourdomain.com" e destinados a "yourdomain.com").
            ValidAudience = "yourdomain.com", // Define os valores esperados para Issuer e Audience (Só aceita tokens que foram emitidos pelo "yourdomain.com" e destinados a "yourdomain.com").
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key")) // Define a chave secreta usada para validar a assinatura do token (Aqui está usando uma chave simétrica (mesma chave para assinar e validar).
        };
    });

builder.Services.AddAuthorization();

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

