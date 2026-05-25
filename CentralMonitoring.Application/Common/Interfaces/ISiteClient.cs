using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CentralMonitoring.Application.DTOs;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Application.Common.Interfaces
{
    public interface ISiteClient
    {
        Task<IEnumerable<MonitoringConfigInfo>> GetMonitoringConfigsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<Building>> GetBuildingsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<Floor>> GetFloorsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<Floorplan>> GetFloorplansAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<MaskedArea>> GetMaskedAreasAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<FloorplanDevice>> GetFloorplanDevicesAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<LatestPosition>> GetLatestPositionsAsync(
            string baseUrl, 
            TrackingAnalyticsFilter filter,
            string? apiKey = null,
            CancellationToken cancellationToken = default);
    }
}
