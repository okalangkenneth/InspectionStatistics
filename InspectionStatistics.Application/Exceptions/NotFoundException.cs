using System;

namespace InspectionStatistics.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string inspectionType, object key)
            : base($"{inspectionType} ({key}) is not found")
        {
        }
    }
}
