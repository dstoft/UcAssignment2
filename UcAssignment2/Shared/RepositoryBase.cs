using System.Collections.Generic;
using System.Linq;

namespace InterstellarLogistic.Shared
{
    public abstract class RepositoryBase<TItem> : IRepository<TItem>
        where TItem : IAggregateRoot<TItem>
    {
        protected readonly Dictionary<string, TItem> Items = new Dictionary<string, TItem>();

        public void Save(TItem item)
        {
            Save(new[] {item});
        }

        public void Save(IEnumerable<TItem> items)
        {
            foreach (var item in items) Items.Add(item.ToKey(), item);
        }

        public TItem ItemOfId(string itemId)
        {
            return ItemOfId(new[] {itemId}).Single();
        }

        public IList<TItem> ItemOfId(IEnumerable<string> itemIds)
        {
            if (Items.Count == 0)
                throw new NotFoundException($"One or more aggregates of type '{(object) typeof(TItem)}' was not found");

            var fetchedItems = itemIds.Where(id => Items.ContainsKey(id)).Select(id => Items[id]).ToList();
            if (fetchedItems.Count != itemIds.Count())
                throw new NotFoundException($"One or more aggregates of type '{(object) typeof(TItem)}' was not found");

            return fetchedItems;
        }

        public void Delete(string itemId)
        {
            Delete(new[] {itemId});
        }

        public void Delete(IEnumerable<string> itemIds)
        {
            itemIds.Where(id => Items.ContainsKey(id)).All(id => Items.Remove(id));
        }

        public IList<TItem> List()
        {
            return Items.Values.ToList();
        }
    }
}