using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApps.Persistence;
using MovieApps.Controllers.Resources;
using MovieApps.Models;

namespace MovieApps.Controllers
{
    public class FeaturesController : Controller
  {
    private readonly MovieAppsDBContext context; 
    private readonly IMapper mapper;
    public FeaturesController(MovieAppsDBContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context; 
    }

    [HttpGet("/api/features")]
    public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
    {
      var features = await context.Features.ToListAsync();      
      return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features); 
    }
  }
}