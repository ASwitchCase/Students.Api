using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Patterns;
using Students.Api.Entities;
using Students.Api.Repositories;

namespace Students.Api.Endpoints;

public static class StudentsEndpoints 
{
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes){
        var group = routes.MapGroup("/students");

        group.MapGet("/", async (IStudentsRepository repository) =>{
            return await repository.GetAllAsync();
        });

        group.MapGet("/{id}", async (IStudentsRepository repository, Guid id) =>{
            Student? student = await repository.GetAsync(id);
            return student is not null ? Results.Ok(student) : Results.NotFound();
        });

        group.MapPut("/{id}", async (IStudentsRepository repository, Guid id, Student newStudent) =>{
            Student? exsistingStudent = await repository.GetAsync(id);
            if(exsistingStudent is null){
                return Results.NotFound();
            }

            exsistingStudent.FirstName = newStudent.FirstName;
            exsistingStudent.LastName = newStudent.LastName;
            exsistingStudent.Email = newStudent.Email;
            exsistingStudent.Gpa = newStudent.Gpa;
            exsistingStudent.Major = newStudent.Major;

            await repository.UpdateAsync(exsistingStudent);
            return Results.Ok(newStudent);
        });

        group.MapPost("/",async (IStudentsRepository repository, Student newStudent)=>{
            Student student = new Student(){
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Email = newStudent.Email,
                Gpa = newStudent.Gpa,
                Major = newStudent.Major,
            };

            await repository.CreateAsync(student);
            return Results.Ok(newStudent);
        });

        group.MapDelete("/{id}", async (IStudentsRepository repository, Guid id) =>{
            Student? exsistingStudent = await repository.GetAsync(id);
            if(exsistingStudent is not null){
                await repository.DeleteAsync(id);
            }
            return Results.NoContent();
        });

        return group;
    }
}