using BLL.Data.DataContext;
using BLL.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : Controller
    {
            private readonly Context _context;

            public TreeController(Context context)
            {
                _context = context;
            }

            [HttpGet("tree")]
            public async Task<IActionResult> GetTree()
            {
                var departments = await _context.Departments
                    .Include(d => d.Children)
                    .ToListAsync();

                var tree = BuildTree(departments);

                return Ok(tree);
            }

            private List<Node> BuildTree(List<Department> flatData)
            {
                var lookup = flatData.ToDictionary(d => d.Id, d => new Node
                {
                    key = d.Id.ToString(),
                    title = $"{d.Name} ({d.EnumDepartment})",
                    folder = d.Children != null && d.Children.Any(),
                    children = new List<Node>()
                });

                var rootNodes = new List<Node>();

                foreach (var dept in flatData)
                {
                    if (dept.ParentUnitId != null && lookup.ContainsKey(dept.ParentUnitId.Value))
                        lookup[dept.ParentUnitId.Value].children.Add(lookup[dept.Id]);
                    else
                        rootNodes.Add(lookup[dept.Id]);
                }

                return rootNodes;
            }

            public class Node
            {
                public string key { get; set; }
                public string title { get; set; }
                public bool folder { get; set; }
                public List<Node> children { get; set; } = new();
            }
        

    }
}
