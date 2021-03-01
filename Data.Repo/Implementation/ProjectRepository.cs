using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(Context context):base(context)
        {

        }
        public override async Task<Project> FindById(string id)
        {
            return await DoQuery().Filter(m => m.ProjectId == id).SingleResultAsync();
        }
    }
}
