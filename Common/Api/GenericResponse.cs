using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class GenericResponse<T>
    {
        public bool Status { get; set; }
        public List<string> ErrorMessages { get; set; }
        public T Obj { get; set; }

        public GenericResponse()
        {
            Status = false;
            ErrorMessages = null;
        }
        public GenericResponse(T obj)
        {
            Status = false;
            ErrorMessages = null;
            this.Obj = obj;
        }

        public GenericResponse(List<string> messages)
        {
            Status = true;
            ErrorMessages = messages;
        }
        public GenericResponse(string error)
        {
            Status = true;
            ErrorMessages = new List<string>();
            ErrorMessages.Add(error);
        }
    }
}
