using eApplication.Entities;
using eApplication.Models;
using Mapster;

namespace eApplication.AutoMappers;

public static class CreateTodoMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateTodoRequest, Todo>.NewConfig();
    }
}