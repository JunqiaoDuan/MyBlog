using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsValid { get; set; }
        public string? ReasonOfInvalid { get; set; }

        public Guid? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTimeOffset? CreationDate { get; set; }

        public Guid? ModBy { get; set; }
        public string? ModByName { get; set; }
        public DateTimeOffset? ModDate { get; set; }

        public void PrepareForCreate(Guid? userId = null, string? userName = null)
        {
            Id = NewId.NextSequentialGuid();

            IsValid = true;
            ReasonOfInvalid = "";

            CreatedBy = userId;
            CreatedByName = userName;
            CreationDate = DateTime.Now;

            ModBy = null;
            ModByName = null;
            ModDate = null;
        }

        public void PrepareForEdit(Guid? userId = null, string? userName = null)
        {
            ModBy = userId;
            ModByName = userName;
            ModDate = DateTime.Now;
        }

        public void PrepareForDelete(string reasonOfInvalid, Guid? userId = null, string? userName = null)
        {
            IsValid = false;
            ReasonOfInvalid = reasonOfInvalid;

            ModBy = userId;
            ModByName = userName;
            ModDate = DateTime.Now;
        }

    }
}
