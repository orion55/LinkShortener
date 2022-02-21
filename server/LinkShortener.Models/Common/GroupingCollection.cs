using System.Collections.Generic;
using System.Linq;

namespace LinkShortener.Models.Common
{
	// this is temporary solution, for manual grouping elements by categories
	public class GroupingCollection<TKey, TElement>
	{
		public GroupingCollection(TKey key, List<TElement> collection)
		{
			Key = key;
			Elements = collection;
		}

		public List<TElement> Elements { get; }

		public TKey Key { get; }
	}
}
