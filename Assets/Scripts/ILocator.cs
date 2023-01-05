namespace ProductionReady
{
    public interface ILocator
    {
        /// <summary>
        /// Returns the bound instance of the bindingType if available.
        /// </summary>
        /// <returns>Instance if available or null</returns>
        TBindingType Get<TBindingType>();
        
        /// <summary>
        /// Registers an instance for a certain type. Afterwards the instance can be retrieved via the bindingType.
        /// </summary>
        /// <param name="instance">Instance of the binding which must derive from bindingType.</param>
        void Bind<TBindingType>(TBindingType instance);
        
        /// <summary>
        /// Removes the binding if available.
        /// If the instance implements IDisposable, Dispose is called. 
        /// </summary>
        void Unbind<TBindingType>();
    }
}