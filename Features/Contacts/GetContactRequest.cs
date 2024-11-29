﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace MMLib.Fri.MinimalAPI.Features.Contacts;

public static class GetContactRequest
{
    public static IEndpointConventionBuilder MapContactGet(this IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/{id}", OnGet)
            .WithDescription("Get a contact by id");

    private static async Task<Results<Ok<Contact>, NotFound>> OnGet(int id, IContactRepository repository)
    {
        await Task.Delay(1000);
        var contact = repository.GetById(id);
        return contact is null ? TypedResults.NotFound() : TypedResults.Ok(contact);
    }
}