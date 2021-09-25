using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Data.DTO;
using HospitalManagent.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Business
{
    public class ErrorService : IErrorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IContainer container;

        public ErrorService(IUnitOfWork unitOfWork, IContainer container)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
        }


        public ErrorDto CreateError(string userId, string errorMessage)
        {
            if(userId == "")
            {
                userId = "system user";
            }
            return new ErrorDto {
                Id = Guid.NewGuid(),
                IssueDate = DateTime.UtcNow,
                UserId = userId,
                ErrorMessage = errorMessage
            };
        }

        public void Insert(ErrorDto error)
        {
            this.container.Repository<ErrorDto>().Insert(error);
            unitOfWork.Save();
        }
    }
}
