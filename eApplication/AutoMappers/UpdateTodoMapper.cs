using eApplication.Entities;
using eApplication.Models;
using Mapster;

namespace eApplication.AutoMappers;

public static class UpdateTodoMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<UpdateTodoRequest, Todo>.NewConfig();
    }
}