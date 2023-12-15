// Implementing Interface for future improvemnents to shorten and simplify the code

namespace WindowsFormsApp1
{
    public interface ICSVable<T>
    {
        string ToCSVString();
        T FromCSVString(string CSVstring);
    }
}

        

    

