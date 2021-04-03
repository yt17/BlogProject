using Entities.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Results
{
    public class LayerResults<T> where T:class
    {
        public List<MessageProcess> Errors { get; set; }
        public T Result { get; set; }
        public LayerResults()
        {
            Errors = new List<MessageProcess>();
        }
        public void AddError(Messages code,string Message) {
            Errors.Add(new MessageProcess() { Code=code,Message=Message});
        }
    }
}
