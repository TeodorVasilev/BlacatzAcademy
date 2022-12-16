namespace _2.Struct
{
    public class OnlineStore : Website, IOnlineStore
    {
        public OnlineStore()
        {
            this.Objects = new List<object>();
        }

        public List<object> Objects { get; set; }
    }
}
