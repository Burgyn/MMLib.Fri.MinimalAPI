using FluentValidation;

namespace MMLib.Fri.MinimalAPI.Features.Contacts;

public static class Setup
{
    public static IServiceCollection AddContacts(this IServiceCollection services)
    {
        services.AddSingleton<IContactRepository, ContactRepository>();
        services.AddScoped<IValidator<UpdateContactRequest.UpdateContact>, UpdateContactRequest.UpdateContactValidator>();
        services.AddScoped<IValidator<CreateContactRequest.CreateContact>, CreateContactRequest.CreateContactValidator>();

        return services;
    }

    public static IEndpointConventionBuilder MapContacts(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/contacts")
            .WithTags("Contacts");

        group.MapContactsGet();
        group.MapContactGet();
        group.MapContactPost();
        group.MapContactPut();
        group.MapContactDelete();

        return group;
    }
}
