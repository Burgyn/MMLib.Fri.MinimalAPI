using FluentValidation;
using MMLib.Fri.MinimalAPI.Features.Contacts;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<UpdateContactRequest.UpdateContactValidator>();
builder.Services.AddOpenApi();

builder.Services.AddContacts();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapContacts();

app.Run();