using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ClassifyTodoItem
    {
        public long Id { get; set; }
        public int TodoItemId { get; set; }
        public string Name { get; set; }
        public string classification { get; set; }

    }
}
