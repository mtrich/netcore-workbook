using System;
using System.Collections.Generic;
using ToDoApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ToDoApp.Services
{
    public class Repository
    {
        public static readonly Dictionary<int, Status> status = new Dictionary<int, Status>
        {
            { 1, new Status { Id = 1, Value = "Not Started" } },
            { 2, new Status { Id = 2, Value = "In Progress" } },
            { 3, new Status { Id = 3, Value = "Done" } }
        };

        public static List<ToDo> list = new List<ToDo>
        {
            new ToDo { Id = 1, Title = "My First ToDo", Description = "Get the app working", Status = status[2] }
        };

        public static ToDo GetToDoById(int id)
        {
            var todo = list.SingleOrDefault(t => t.Id == id);

            return todo;
        }

        public static void SaveToDo(int id, ToDo toDo)
        {
            //get the curent todo based on id
            var index = list.FindIndex(x => x.Id == id);
            //overwrite each property with values from collection
            list.RemoveAt(index);
            list.Insert(index, toDo);
            //return saved todo
        }

        public static void CreateToDo(ToDo toDo)
        {
            list.Add(toDo);
        }

        public static void DeleteToDo(int id)
        {
            var todo = list.FindIndex(x => x.Id == id);
            list.RemoveAt(todo);
        }
    }
}
