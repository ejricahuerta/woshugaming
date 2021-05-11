using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Data;
using Web.Data.Models;

namespace Web.Services
{
    public interface IDataService
    {
        Task<IEnumerable<StreamVideo>> GetStreamVideosAsync();
        Task AddNewStreamVideoAsync(string url);
    }
    public class DataService : IDataService
    {
        private const string WOSHUGAMING_ID = "104891724412489";
        private const string WOSHUGAMING_TXT = "woshugaming";
        private readonly WoshuDbContext context;

        public DataService(WoshuDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewStreamVideoAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("Invalid URL input");
            }


            if (url.Contains(WOSHUGAMING_ID) || url.Contains(WOSHUGAMING_TXT))
            {
                if (context.StreamVideos.Any(p => p.URL.Equals(url)))
                {
                    throw new ArgumentException($"'{url}' already exist.");
                }

                var newEntity = new StreamVideo
                {
                    URL = url.Contains(WOSHUGAMING_ID) ? url.Replace(WOSHUGAMING_ID,WOSHUGAMING_TXT) : url
                };
                await context.StreamVideos.AddAsync(newEntity);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"'{url}' is not a Woshu stream video.");
            }
        }

        public async Task<IEnumerable<StreamVideo>> GetStreamVideosAsync()
        {
            return await context.StreamVideos.ToListAsync();
        }
    }
}
