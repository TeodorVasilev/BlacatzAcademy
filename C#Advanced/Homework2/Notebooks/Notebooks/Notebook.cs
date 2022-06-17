namespace Notebooks
{
    public class Notebook
    {
        private string[] pages { get; set; }

        public Notebook()
        {
            this.pages = new string[100];
        }

        public void Write(string text, int page)
        {
            if (page >= 0 && page <= 100)
            {
                this.pages[page] = text;
            }
            else
            {
                throw new Exception("The notebook has only 100 pages");
            }
        }

        public string Read(int page)
        {
            if (page >= 0 && page <= 100)
            {
                return this.pages[page];
            }
            else
            {
                return "The notebook has only 100 pages";
            }
        }
    }
}
