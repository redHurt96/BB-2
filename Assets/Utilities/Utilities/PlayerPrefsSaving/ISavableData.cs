namespace RH.Utilities.Saving
{
    /// <summary>
    /// Inheritors class must implement attribute [Serializable]
    /// </summary>
    public interface ISavableData
    {
        string Key { get; }
    }
}