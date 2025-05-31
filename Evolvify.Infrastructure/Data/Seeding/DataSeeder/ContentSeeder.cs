using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Data.Seeding.DataSeeder
{
    public class ContentSeeder
    {
        public static async Task<List<Content>> GetContents()
        {

            var filePath = @"..\Evolvify.Infrastructure\Data\Seeding\DataSeed\Contents.json";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Contents data file not found", filePath);
            }

            var typesData = File.ReadAllText(filePath);
            // Deserialize the JSON data into a list of Content objects
            var contents =  JsonConvert.DeserializeObject<List<Content>>(typesData);

            if (contents == null || !contents.Any())
            {
                throw new NotFoundException("Contents not found");
            }
            return contents;
        }
    }
}
