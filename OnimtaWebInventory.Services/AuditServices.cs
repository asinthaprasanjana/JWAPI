using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
    public class AuditServices : IAuditServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public AuditServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AuditVM>> GetAllAuditDetails(int pageId)
        {
            IEnumerable<AuditVM> auditVM;


            
            using (_unitOfWork)
            {


                try
                {
                auditVM = await  _unitOfWork.AuditRepository.GetAllAuditDetails(pageId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return auditVM;
        }

        public async Task<IEnumerable<AuditTypeDetailsVM>> GetAllAuditTypeDetails()
        {
            IEnumerable<AuditTypeDetailsVM> auditTypeDetailsVM;
            using (_unitOfWork)
            {


                try
                {
                 auditTypeDetailsVM = await  _unitOfWork.AuditRepository.GetAllAuditTypeDetails();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


           

            return auditTypeDetailsVM;
        }

        public async Task<IEnumerable<AuditVM>> GetAuditDetailsById(string referenceNo1)
        {
            IEnumerable<AuditVM> auditVM;

            using (_unitOfWork)
            {


                try
                {
                   auditVM = await  _unitOfWork.AuditRepository.GetAuditDetailsById(referenceNo1);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           

            return auditVM;
        }

        public async Task<IEnumerable<AuditVM>> SearchAuditTypeDetails(int userId, int auditTypeId, string auditName)
        {
            IEnumerable<AuditVM> auditVM;

            using (_unitOfWork)
            {


                try
                {
                  auditVM = await  _unitOfWork.AuditRepository.SearchAuditTypeDetails(userId, auditTypeId, auditName);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            

            return auditVM;
        }
    }
}
