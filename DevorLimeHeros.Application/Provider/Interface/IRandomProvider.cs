namespace DevoraLimeHeros.Application.Provider.Interface
{
    public interface IRandomProvider
    {
        double GetDoubleValue();

        int GetIntValue(int maxValue);
    }
}
