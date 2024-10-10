using Top.Scorers.Domain.Interfaces;

namespace Top.Scorers.Domain.Services
{
    public class CsvHandler : ICsvHandler
    {
        string filePath;
        public CsvHandler(string filePath)
        {
            this.filePath = filePath?? throw new FileNotFoundException("The specified file was not found.", filePath);
        }

        public IEnumerable<string> Read()
        {
            List<string> result = new List<string>();
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        if (ValidateLine(line))
                        result.Add(line);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        private bool ValidateLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            return true;
        }
    }
}
