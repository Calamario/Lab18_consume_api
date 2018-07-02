using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class TodoList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TodoItem> Items { get; set; }
    }
}
