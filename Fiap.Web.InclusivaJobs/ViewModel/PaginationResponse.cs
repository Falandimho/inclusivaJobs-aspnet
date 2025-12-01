namespace Fiap.Web.InclusivaJobs.ViewModels
{
	public class PaginationResponse<T>
	{
		public IEnumerable<T> Data { get; set; }
		public PaginationInfo Pagination { get; set; }

		public PaginationResponse(IEnumerable<T> data, int totalCount, int pageNumber, int pageSize)
		{
			Data = data;
			Pagination = new PaginationInfo
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalCount = totalCount,
				TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
				HasPrevious = pageNumber > 1,
				HasNext = pageNumber < (int)Math.Ceiling(totalCount / (double)pageSize)
			};
		}
	}

	public class PaginationInfo
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
		public int TotalPages { get; set; }
		public bool HasPrevious { get; set; }
		public bool HasNext { get; set; }
	}
}