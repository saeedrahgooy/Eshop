using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class OperationResult
    {
        public string Operation { get; set; }
        public DateTime OperationDate { get;private set; }
        public bool Success { get;private set; }
        public int RecordID { get; set; }
        public string Message { get; set; }

        public OperationResult(string operation, int recordId)
        {
            Operation = operation;
            OperationDate = DateTime.Now;
            Success = false;
            RecordID = recordId;
        }
        public OperationResult(string operation)
        {
            Operation = operation;
            OperationDate = DateTime.Now;
            Success = false;            
        }
        public OperationResult Failed(string message, int? recordId)
        {
            this.Message = message;
            this.Success = false;
            if(recordId != null)
            {
                this.RecordID = recordId.Value;
            }
            return this;
        }
        public OperationResult Succeed(string message, int? recordId)
        {
            this.Message = message;
            this.Success = true;
            if (recordId != null)
            {
                this.RecordID = recordId.Value;
            }
            return this;
        }
    }
}
