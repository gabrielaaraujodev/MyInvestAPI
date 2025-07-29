// Criando o construtor da aplica��o.
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// -- Configura servi�os com o constutor da aplica��o (inje��o de depend�ncia). -- 

// Faz a API "saber" que possui endpoints.
builder.Services.AddControllers();

// Habilita a descoberta autom�tica de endpoints para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Adiciona o gerador de documenta��o Swagger/OpenAPI.
builder.Services.AddSwaggerGen();

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

