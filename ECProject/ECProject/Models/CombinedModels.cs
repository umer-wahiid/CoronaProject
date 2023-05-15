using Microsoft.EntityFrameworkCore;

namespace ECProject.Models
{
	[Keyless]
	public class CombinedModels
	{
		public IEnumerable<Product> ProData { get; set; }
		public IEnumerable<Category> CatData { get; set; }
	}
}
