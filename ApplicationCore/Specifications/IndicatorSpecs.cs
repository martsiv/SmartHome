using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class IndicatorSpecs
	{
		public class ByName : Specification<Indicator>
		{
			public ByName(string indicatorName)
			{
				Query.Where(x => x.Name.ToLower().Trim() == indicatorName.ToLower().Trim());
			}
		}
	}
}
