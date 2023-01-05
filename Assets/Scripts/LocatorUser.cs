using UnityEngine;

namespace ProductionReady
{
    public class LocatorUser : MonoBehaviour
    {
        [SerializeField] private string _userName = "Production Ready";
        
        private void Start()
        {
            IUserNameService userNameService = new FixedUserNameService(_userName);
            //IUserNameService userNameService = new RandomUserNameService();
                
            // Bind
            Global.Locator.Bind<IUserNameService>(userNameService);

            // Get
            IUserNameService instance = Global.Locator.Get<IUserNameService>();
            Debug.Log(instance.GetUserName());    
            
            // Unbind
            Global.Locator.Unbind<IUserNameService>();
        }
    }
}
