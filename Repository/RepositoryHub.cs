using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryHub : IRepositoryHub
    {
        private DataContext _context;
        private IBusinessRepository _business;
        private IEnforcementAgencyRepository _agency;
        private IGuidelineRepository _guideline;
        private IInspectionGuidelineRepository _inspectionGuideline;
        private IInspectionRepository _inspection;
        private IInspectionTypeRepository _inspectionType;


        public RepositoryHub(DataContext context)
        {
            _context = context;
        }

        public IBusinessRepository Business
        {
            get
            {
                if (_business == null)
                {
                    _business = new BusinessRepository(_context);
                }
                return _business;
            }
        }

        public IEnforcementAgencyRepository EnforcementAgency
        {
            get
            {
                if (_agency == null)
                {
                    _agency = new EnforcementAgencyRepository(_context);
                }
                return _agency;
            }
        }

        public IGuidelineRepository Guideline
        {
            get
            {
                if (_guideline == null)
                {
                    _guideline = new GuidelineRepository(_context);
                }
                return _guideline;
            }
        }

        public IInspectionGuidelineRepository InspectionGuideline
        {
            get
            {
                if (_inspectionGuideline == null)
                {
                    _inspectionGuideline = new InspectionGuidelineRepository(_context);
                }
                return _inspectionGuideline;
            }
        }

        public IInspectionRepository Inspection
        {
            get
            {
                if(_inspection == null)
                {
                    _inspection = new InspectionRepository(_context);
                }
                return _inspection;
            }
        }

        public IInspectionTypeRepository InspectionType
        {
            get
            {
                if(_inspectionType == null)
                {
                    _inspectionType = new InspectionTypeRepository(_context);
                }
                return _inspectionType;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
