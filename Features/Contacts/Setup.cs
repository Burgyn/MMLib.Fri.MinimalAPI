namespace MMLib.Fri.MinimalAPI.Features.Contacts;

public static class Setup
{
    public static IServiceCollection AddContacts(this IServiceCollection services)
    {
        services.AddSingleton<IContactRepository, ContactRepository>();

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
