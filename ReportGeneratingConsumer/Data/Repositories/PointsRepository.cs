using ReportGeneratingConsumer.Infrastructure;
using Common.Requests;
using Common.Model;

namespace ReportGeneratingConsumer.Data.Repositories
{
    public class PointsRepository
    {
        private readonly MyDbContext _context;

        public PointsRepository()
        {
            _context = new MyDbContext();
        }

        public IEnumerable<Point> GetPoints(GeneratePointsReportRequest? request)
        {
            if (request is not null) 
            {
                return _context.Points.Where(x => 
                    (x.B1 == request.B1 || request.B1 == null) &&
                    (x.B2 == request.B2 || request.B2 == null) &&
                    (x.B3 == request.B3 || request.B3 == null) &&
                    (x.Element == request.Element || request.Element == null) &&
                    (x.PointType == request.PointType || request.PointType == null) 
                    ) 
                .ToList();
            }
            else 
            {
                return _context.Points.ToList();
            }
        }
    }
}