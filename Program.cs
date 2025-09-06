// Criando o construtor da aplica��o.
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyInvest.Context;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// -- Configura servi�os com o constutor da aplica��o (inje��o de depend�ncia). -- 

/*Minha aplica��o vai usar autentica��o baseada em Bearer Token JWT,ou seja, 
quando um cliente mandar um token JWT esse token ser� usado para autentica��o.*/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// Aqui come�a a configura��o de como o token ser� validado.
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Verifica se o Issuer (quem emitiu o token) � confi�vel.
            ValidateAudience = true, // Verifica se o Audience (para quem o token foi emitido) � v�lido.
            ValidateLifetime = true, // Confere se o token ainda est� dentro do prazo de validade
            ValidateIssuerSigningKey = true, // Valida a assinatura do token, para ter certeza de que ele n�o foi alterado por algu�m.
            ValidIssuer = "yourdomain.com", // Define os valores esperados para Issuer e Audience (S� aceita tokens que foram emitidos pelo "yourdomain.com" e destinados a "yourdomain.com").
            ValidAudience = "yourdomain.com", // Define os valores esperados para Issuer e Audience (S� aceita tokens que foram emitidos pelo "yourdomain.com" e destinados a "yourdomain.com").
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key")) // Define a chave secreta usada para validar a assinatura do token (Aqui est� usando uma chave sim�trica (mesma chave para assinar e validar).
        };
    });

builder.Services.AddAuthorization();

// Faz a API "saber" que possui endpoints.
builder.Services.AddControllers();

// Habilita a descoberta autom�tica de endpoints para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Adiciona o gerador de documenta��o Swagger/OpenAPI.
builder.Services.AddSwaggerGen();

// Obtendo a string de conex�o do Banco de Dados.
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

// Registro da classe de contexto, nesse caso 'ApplicationDbContext', no container de inje��o de depend�ncia.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// -------------------------------------------------------------------------------

// Pega todas as configura��es feitas (servi�os, middlewares) e cria a aplica��o final.
var app = builder.Build();

// Verifica se a aplica��o est� num ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger.
    app.UseSwagger();

    //Adiciona a interface gr�fica do Swagger para testes.
    app.UseSwaggerUI();
}

// For�a a API a redirecionar de HTTP para HTTPS.
app.UseHttpsRedirection();

// Ativa a verifica��o de permiss�es (ex.: endpoints que s� usu�rios logados podem acessar).
// OBS: Para funcionar, voc� precisa configurar autentica��o tamb�m.
app.UseAuthorization();

// Faz o link entre as rotas HTTP e os controllers criados.
app.MapControllers();

// Inicia o servidor web (Kestrel) e fica esperando requisi��es.
app.Run();

