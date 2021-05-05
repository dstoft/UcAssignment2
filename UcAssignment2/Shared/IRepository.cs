using System.Collections.Generic;

namespace InterstellarLogistic.Shared
{
    public interface IRepository<TItem>
        where TItem : IAggregateRoot<TItem>
    {
        void Save(TItem item);
        void Save(IEnumerable<TItem> items);
        TItem ItemOfId(string itemId);
        IList<TItem> ItemOfId(IEnumerable<string> itemIds);
        void Delete(string itemId);
        void Delete(IEnumerable<string> itemIds);
        IList<TItem> List();
    }
}