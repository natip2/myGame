using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Test
{
    public class GameFactory
    {

        Dictionary<string, Type> _playerType;

        public GameFactory()
        {
            _playerType = new Dictionary<string, Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type item in assembly.GetTypes())
            {

                RegisterPlayerInFactoryAttribute attrp = item.GetCustomAttribute<RegisterPlayerInFactoryAttribute>();
                if (attrp != null)
                {
                    RegisterPlayerType(attrp.InterfaceType, item);
                    continue;
                }

            }
        }



        public void RegisterPlayerType(Type interfaceType, Type playerType)
        {
            _playerType.Add(interfaceType.Name, playerType);
        }


        public IPlayer CreatePlayer(Type interfaceType, params object[] optionalCtorParameter)
        {
            IPlayer retVal = null;
            //Add support for invalid empType
            Type empClass = _playerType[interfaceType.Name];
            retVal = (IPlayer)
                Activator.CreateInstance(empClass, optionalCtorParameter); 
            return retVal; 
        }

        internal IPlayer CreateDecorator(Type classType, IPlayer player)
        {
            Type empClass = _playerType[classType.Name];
            return (IPlayer) Activator.CreateInstance(empClass, player);
        }
    }
}
